using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;  // Reference to the tile prefab
    public Transform rackParent;   // Parent transform for the player's rack (can be an empty GameObject)
    public int tilesToGenerate = 7; // Number of tiles to generate for the player's rack

    private List<char> availableLetters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    private List<int> letterScores = new List<int> { 1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10 };

    void Start()
    {
        GenerateTiles();
    }

    void GenerateTiles()
    {
        for (int i = 0; i < tilesToGenerate; i++)
        {
            // Pick a random letter and score
            int randomIndex = Random.Range(0, availableLetters.Count);
            char letter = availableLetters[randomIndex];
            int score = letterScores[randomIndex];

            // Instantiate the tile prefab
            GameObject newTile = Instantiate(tilePrefab, rackParent);

            // Initialize the tile with letter and score
            Tile tileComponent = newTile.GetComponent<Tile>();
            tileComponent.Initialize(letter, score);
        }
    }
}
