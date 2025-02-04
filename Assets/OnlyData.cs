using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using System;
using System.Reflection;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class OnlyData : MonoBehaviourPun
{

    public GameType gametype;

    public static OnlyData Data { get; private set; }

    public bool AfterPlayedGame;

    void Awake()
    {
        if (Data == null)
        {
            Data = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //Data = this;

    }

    public void OnEnable()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
   
}

