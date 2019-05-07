using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollbarController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isHovering;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isHovering = false;
    }
}
