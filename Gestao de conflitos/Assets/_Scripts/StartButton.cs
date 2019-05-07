using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, ISelectHandler, IDeselectHandler {
	Button thisButton;
	void Start () {
		thisButton = GetComponent<Button>();
	}
	
	void OnEnable() {
		thisButton = GetComponent<Button>();
		thisButton.Select();
	}


	void OnBecameVisible()
	{
		//thisButton.Select();
	}

    public void OnSelect(BaseEventData eventData)
    {
        thisButton.interactable = true;
    }

	public void OnDeselect(BaseEventData eventData)
    {
        thisButton.OnDeselect(null);
       // thisButton.interactable = false;
    }

}
