using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayMouseOver : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
	public void OnSelect(BaseEventData eventData)
	{
		AudioManager.instance.PlayMouseOverSFX();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        AudioManager.instance.PlayMouseOverSFX();
    }
}
