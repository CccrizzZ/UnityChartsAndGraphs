using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotsMouseEvent : MonoBehaviour, IPointerClickHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Indicator;

    void Start()
    {
        
    }


     
    public void OnPointerClick(PointerEventData eventData) // 3
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Indicator.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Indicator.SetActive(false);
        
    }
}
