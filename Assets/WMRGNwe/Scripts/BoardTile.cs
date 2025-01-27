using UnityEngine;
using System.Collections;
using Photon.Pun;

public class BoardTile : MonoBehaviourPun {

    public bool completed;
    public GameObject UIclone;
    public BoardSlot currentslot;
    public string letter;
    public int score;
    public int DragSelectTile;
    public static BoardTile Instance;

    public void Awake()
    {
        Instance = this;
    }
    void OnMouseDown()
    {
        //GameController.data.targetBoardSlot = null;
        
        //KK = this.transform.gameObject;
        Debug.Log("Syed -OnMouseDown");
        if(currentslot != null && !completed)
        {

            currentslot.free = true;
            currentslot = null;
        }


        // +++++++++++++++++++++++++++            MULTI       ++++++++++++++++++++++++++++++++++++++


        


        // +++++++++++++++++++++++++++            MULTI       ++++++++++++++++++++++++++++++++++++++

    }



    void OnMouseDrag()
    {
        DragSelectTile = 0;
        DragSelectTile = Alphabet.data.TileGameObject.IndexOf(this.transform.parent.gameObject);
        Debug.Log("MasterResetTileInt" + DragSelectTile);
        if (completed)
            return;
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        UIclone.SetActive(true);
        UIclone.GetComponent<UITile>().dragging = true;
        UIclone.transform.position = cursorPos;
        GameController.data.letterDragging = true;
        gameObject.SetActive(false);
        

        GameController.data.ResetTileMaster(DragSelectTile);
    }
}
