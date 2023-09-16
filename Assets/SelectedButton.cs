using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Selected");
        this.GetComponent<Button>().Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        return;
    }
}
