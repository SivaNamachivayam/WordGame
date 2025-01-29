using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyData : MonoBehaviour
{

    public GameType gametype;

    public static OnlyData Data { get; private set; }

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
    }
    public void PPMode()
    {
        gametype = GameType.pass;
    }

    public void MultiMode()
    {
        gametype = GameType.Multi;
    }


}
public enum GameType
{
    Multi,
    pass,
    None
}
