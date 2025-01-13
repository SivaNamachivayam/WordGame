using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{

    [SerializeField] private GameObject parentobj;
    [SerializeField] private GameObject[] childobj;
    public GameObject tilePrefab;  
    public Transform boardParent;

    void Start()
    {
        LoadCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCells()
    {
        for(int i = 0; i < 225; i++)
        {
            Instantiate(childobj[i], parentobj.transform);
        }
       
    }

    void PlaceTileOnBoard(Vector3 position, char letter, int score)
    {
        // Instantiate the tile prefab at the specified position
        GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
        Tile tileScript = tile.GetComponent<Tile>();

        // Initialize the tile with the provided letter and score
        tileScript.Initialize(letter, score);

        // Optionally, you can attach this tile to the board (or specific cell)
        tile.transform.SetParent(boardParent);
    }
}
