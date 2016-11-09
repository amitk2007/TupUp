using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    GameObject LastButton;
    public float speed = 4.2f;
    bool animationIsPlayed = false;
    // Use this for initialization
    void Start()
    {
        LastButton = null;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovment();
        EndAnimation();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Button" && animationIsPlayed == false)
        {
            if (GameManager.GetMaterialColor(collision.gameObject) == "blue")
            {
                animationIsPlayed = true;
                collision.transform.GetComponent<Animation>().Play();
                LastButton = collision.gameObject;
                GUIScoreScript.playerScore++;
            }
        }
    }

    void PlayerMovment()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * speed, 0, 0);
        this.transform.GetComponent<Rigidbody>().AddForce(0, Input.touchCount, 0);
    }

    void EndAnimation()
    {
        if (LastButton != null)
        {
            if (LastButton.transform.GetComponent<Animation>().isPlaying == false)
            {
                if (animationIsPlayed == true)
                {
                    this.transform.GetComponent<Rigidbody>().AddForce(0, 5, 0);
                    animationIsPlayed = false;
                    Debug.Log(GUIScoreScript.playerScore.ToString());
                    LastButton = null;
                    GameManager.ChangeButtons();
                }
            }
        }
    }
}
