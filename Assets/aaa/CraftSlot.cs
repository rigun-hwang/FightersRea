using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Image image = GetComponent<Image>();

            Color tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            Destroy(eventData.pointerDrag);
        }
    }
}
