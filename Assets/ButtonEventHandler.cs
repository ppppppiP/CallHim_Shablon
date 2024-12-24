using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniversalMobileController;
public class ButtonEventHandler : MonoBehaviour
{
    SpecialButton SpButton;

    public static ButtonEventHandler instance;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        SpButton= GetComponent<SpecialButton>();
    }

    public void RemoveListener()
    {
        SpButton.onButtondown.RemoveAllListeners();
    }

    public void SetListener(Action action)
    {
        if(SpButton!= null)
        SpButton.onButtondown.AddListener(action.Invoke);
    }
}
