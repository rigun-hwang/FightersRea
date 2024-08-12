using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform trans;
    public CanvasGroup cg;
    private void Awake()
    {
        trans = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        

    }
    public void OnDrag(PointerEventData eventData)
    {
        trans.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        cg.alpha = 1f;

        cg.blocksRaycasts = true;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.alpha = .6f;
        cg.blocksRaycasts = false;
    }

}
