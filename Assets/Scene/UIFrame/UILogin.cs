using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class UILogin : UIBase
{
    public override UIManager.EUI eUI
    {
        get
        {
            return UIManager.EUI.UILogin;
        }
    }
    InputField usernameInput;
    InputField passwordInput;
    Button btnLogin;
    protected override void InitComponents()
    {
        usernameInput = UStaticFuncs.FindChildComponent<InputField>(transform, "username");
        passwordInput = UStaticFuncs.FindChildComponent<InputField>(transform, "username");
        btnLogin = UStaticFuncs.FindChildComponent<Button>(transform, "Login");

        btnLogin.onClick.AddListener(
            delegate()
            {
                string username = usernameInput.text;
                string password = passwordInput.text;
                //do login
            });
    }
}