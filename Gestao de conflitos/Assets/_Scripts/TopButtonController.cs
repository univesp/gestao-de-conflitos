using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopButtonController : MonoBehaviour {

    private int instance;
    public Button topButton;
    public Navigation topButtonNavigation;

    //MENU
    public Button startButton;
    public Button creditsButton;

    //OPÇÕES
    public Slider topSlider;
    public Slider bottomSlider;

    //CRÉDITOS
    public Scrollbar textBar;

    //Intro
    public Button introButton;

    /*
     1 - Menu principal
     2 - Opções
     3 - Créditos
     4 - Intro
         */
    public void SetInstance(int newInstance)
    {
        instance = newInstance;
        SetExplicitNavigation();
        topButton.Select();
    }

    private void SetExplicitNavigation()
    {
        switch(instance)
        {
            case 1:
                topButtonNavigation.selectOnUp = creditsButton;
                topButtonNavigation.selectOnDown = startButton;
                topButton.navigation = topButtonNavigation;
                break;

            case 2:
                topButtonNavigation.selectOnUp = topSlider;
                topButtonNavigation.selectOnDown = bottomSlider;
                topButton.navigation = topButtonNavigation;
                break;

            case 3:
                topButtonNavigation.selectOnUp = textBar;
                topButtonNavigation.selectOnDown = textBar;
                topButton.navigation = topButtonNavigation;
                break;

            case 4:
                topButtonNavigation.selectOnUp = introButton;
                topButtonNavigation.selectOnDown = introButton;
                topButton.navigation = topButtonNavigation;
                break;
        }
    }
}
