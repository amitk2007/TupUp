using UnityEngine;
using System.Collections;

public class GUIScoreScript : MonoBehaviour
{
    public static int playerScore = -1;
    public static int playerHighScore;
    // Use this for initialization
    void Start()
    {
        playerScore = 0;
        playerHighScore = PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void SaveHighScore()
    {
        PlayerPrefs.SetInt("highScore", Mathf.Max(playerHighScore, playerScore));
        playerHighScore = PlayerPrefs.GetInt("highScore");
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }
    public static int GetLastScore()
    {
        try
        {
            return playerScore;
        }
        catch (System.Exception)
        {

            return -1;
        }
    }
}
