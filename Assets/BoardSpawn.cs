using Photon.Pun;
using UnityEngine;


public class BoardSpawn : MonoBehaviourPun
{
    public GameObject BoardPrefab;    // Set the striker's spawn position
    public GameObject BoardPrefabGameObject;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnBoardFN();
        }
    }

    private void SpawnBoardFN()
    {
        // Instantiate the striker at the spawn point
        BoardPrefabGameObject = PhotonNetwork.Instantiate(BoardPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
