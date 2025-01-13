using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    

    public Button logoutBtn;

    private void OnEnable()
    {
        logoutBtn.onClick.AddListener(LogOutButtonClk);
    }

    private void Start()
    {
        if (FaceBookLogin.instance.FBLoginbool == true)
        {
            FBSignIn();
        }
       
    }

    

    void FBSignIn()
    {
        //
    }

    

    public void LogOutButtonClk()
    {
         if (FaceBookLogin.instance.FBLoginbool == true)
        {
            FaceBookLogin.instance.LogOut();
        }
       
    }

}
