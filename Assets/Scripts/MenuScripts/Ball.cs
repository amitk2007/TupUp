﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public GameObject[] buttons = new GameObject[3];
    bool useGravity = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0)
        {
            if (useGravity == false)
            {
                this.transform.GetComponent<Rigidbody>().useGravity = true;
                useGravity = true;
            }
            this.transform.position = Input.touches[0].position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            if (collision.gameObject == buttons[0])//Play Button
            {
                Application.LoadLevel("Game");
            }
            else if (collision.gameObject == buttons[1])//How to play Button
            {
                print("1");
            }
            else if (collision.gameObject == buttons[2])//Exit Button
            {
                Application.Quit();
            }
        }
    }
}