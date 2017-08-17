using UnityEngine;
using System.Collections;

public class HTPBallScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x * Time.deltaTime * 10, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            Application.LoadLevel("Game");
        }
    }
}
