using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarteUI : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler

    
{
    [SerializeField] Transform m_initialTransform;
    public bool m_IsDragged = false;
    [SerializeField] bool ShouldOpenLink;
    private GameManager _gameManager;
    public void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void Update()
    {
        if (!m_IsDragged)
        {
            transform.position = Vector3.Lerp(transform.position, m_initialTransform.position, Time.deltaTime*3);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        m_IsDragged = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.position.y > m_initialTransform.position.y + 350)
        {
            if(ShouldOpenLink) Application.OpenURL("https://brooklynbenites.wixsite.com/leandro-benites/copie-de-ebony");
            _gameManager.AnimatorCartes.SetBool("ShouldFade", true);
        }
        m_IsDragged = false;
    }
    public void RangeCardsSoumSoum()
    {
        _gameManager.AnimatorCamera.SetBool("ShouldZoomShadowBound", false);
        _gameManager.AnimatorCartes.SetBool("ShouldShow", false);
    }
    public void AfficheCardsSoumSoum()
    {
        _gameManager.InCombat = false;
        _gameManager.AnimatorCartes.SetBool("ShouldFade", false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!m_IsDragged)
        transform.localScale = new Vector3(3, 3, 3);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!m_IsDragged)
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }
}
