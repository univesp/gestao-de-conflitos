using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyboardMenu : MonoBehaviour, ISelectHandler{

    public Selectable[] selectableObject;
    public Scrollbar scrollbar;

    public int index = 0;
    private bool isSelected;

    private void Update()
    {
        if(scrollbar.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Tab))
        {
            if(index == 0)
            {
                selectableObject[0].OnDeselect(null);
                selectableObject[1].Select();
                index = 1;
            }
            else
            {
                selectableObject[0].Select();
                selectableObject[1].OnDeselect(null);
                index = 0;
            }
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        //isSelected = true;
    }
}
