using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemDetection : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("PlayerGotClose");
    }
    
}
