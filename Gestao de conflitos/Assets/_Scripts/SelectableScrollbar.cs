using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableScrollbar : MonoBehaviour {

    public Scrollbar scrollbar;

    private void OnEnable()
    {
        scrollbar.Select();
    }
}
