using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class boardController : MonoBehaviourPun
{
    public static boardController Data;

    public PhotonView PV;

    public void Awake()
    {
        Data = this;
    }
}
