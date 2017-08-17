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

    //go to the HitButton and HitWall actions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Button" && animationIsPlayed == false)
        {
            HitButton(collision);
        }
        if (collision.transform.tag == "Wall")
        {
            HitWall(collision);
        }
    }

    //nothing for now
    void HitWall(Collision collision)
    {
        // Vector3 force = this.transform.position - collision.gameObject.transform.position;
        // this.transform.GetComponent<Rigidbody>().AddForce(-force);
    }

    //when hit a button (if blue animation and score up) ( if red animation and life down)
    void HitButton(Collision collision)
    {
        if (GameManager.GetMaterialColor(collision.gameObject) == "blue")
        {
            animationIsPlayed = true;
            collision.transform.GetComponent<Animation>().Play();
            LastButton = collision.gameObject;
            GUIScoreScript.playerScore++;
        }
        else if (GameManager.GetMaterialColor(collision.gameObject) == "red")
        {
            animationIsPlayed = true;
            collision.transform.GetComponent<Animation>().Play();
            LastButton = collision.gameObject;
            GameManager.GetLifeDown();
        }
    }

    //mlayer movment according to phone acceleration
    void PlayerMovment()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * speed, 0, 0);
        //Jump when touch - not wanted
        //this.transform.GetComponent<Rigidbody>().AddForce(0, Input.touchCount, 0);
    }

    //stops the animation of the last animated button
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
