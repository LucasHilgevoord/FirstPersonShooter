using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesManager : MonoBehaviour
{
    public static int lives;
    Text text;                      // Reference to the Text component.
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        lives = 3;
    }
    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Lives: " + lives;
    }
}