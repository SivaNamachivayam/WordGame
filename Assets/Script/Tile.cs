using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public char letter;
    public int score;
    public Text letterText;
    public Text scoreText;

    // Set the letter and score for the tile
    public void Initialize(char letter, int score)
    {
        this.letter = letter;
        this.score = score;
        letterText.text = letter.ToString();
        scoreText.text = score.ToString();
        // You can also set the tile sprite based on the letter
    }
}
