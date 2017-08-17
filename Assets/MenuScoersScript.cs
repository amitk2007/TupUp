using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScoersScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (this.transform.name == "HighScore")
        {
            this.GetComponent<TextMesh>().text = "High score: " + GUIScoreScript.GetHighScore();
        }
        else if (this.transform.name == "LastScore")
        {
            if (GUIScoreScript.GetLastScore() != -1)
            {
                this.GetComponent<TextMesh>().text = "Last score: " + GUIScoreScript.GetLastScore();
            }
            else
            {
                this.GetComponent<TextMesh>().text = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
