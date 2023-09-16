using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset PlayerControls;
    private InputAction IAmove;
    private InputAction IAattack;
    private Vector2 moveDirection = Vector2.zero;
    private float attackValue = 0;
    public bool grounded = false;
    private GameManager _gameManager;

    private Rigidbody rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public BoxCollider SwordHitbox;
    public float moveSpeed = 8;
    public float jumpForce = 5;
    public bool KeepRunTuto=true;

    void Awake()
    {
        PlayerControls = this.GetComponent<PlayerInput>().actions;
    }

    private void OnEnable()
    {
        IAmove = PlayerControls.actionMaps[0].actions[0];
        IAmove.Enable();
        IAattack = PlayerControls.actionMaps[0].actions[1];
        IAattack.Enable();
        IAattack.performed += Attack; 
    }
    private void OnDisable()
    {
        IAmove.Disable();
        IAattack.Disable();
    }
    void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager.Player = gameObject;
        rb = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        if (KeepRunTuto)
        {
            IAmove.Disable();
            IAattack.Disable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameManager.InCombat)
        {
            if (KeepRunTuto)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                moveDirection = IAmove.ReadValue<Vector2>();
                rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
                if (grounded && moveDirection.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, moveDirection.y * jumpForce);

                }
                if (rb.velocity.x < 0)
                {
                    transform.localScale = Vector3.Scale(transform.localScale.Abs(), new Vector3(-1, 1, 1));
                }
                if (rb.velocity.x > 0)
                {
                    transform.localScale = transform.localScale.Abs();
                }
            }

        }
        animator.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetBool("Grounded", grounded);
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (!_gameManager.InCombat)
            animator.SetTrigger("Attack");
    }

    public void ActiveHitboxOnAttack()
    {
        SwordHitbox.enabled = true;
    }
    public void DisableHitboxOnAttack()
    {
        SwordHitbox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopRun")
        {
            IAmove.Enable();
            IAattack.Enable();
            KeepRunTuto = false;
        }
    }
}
