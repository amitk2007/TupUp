﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] Buttons = new GameObject[3];
    public GameObject[] harts = new GameObject[3];
    public Material BlueMaterial;
    public Material RedMaterial;

    public static int life = 2;

    #region must be static
    public static Material StaticBlueMaterial;
    public static Material StaticRedMaterial;
    public static GameObject[] StaticButtons = new GameObject[3];
    public static GameObject[] staticharts = new GameObject[3];
    #endregion

    // Use this for initialization
    void Start()
    {
        SetStaticMaterials();
        ChangeButtons();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void ChangeButtons()
    {
        foreach (GameObject Button in StaticButtons)
        {
            Button.GetComponent<Renderer>().material = StaticRedMaterial;
        }
        StaticButtons[Random.Range(0, 3)].GetComponent<Renderer>().material = StaticBlueMaterial;
    }

    public static string GetMaterialColor(GameObject button)
    {
        if (button.transform.GetComponent<Renderer>().material.color ==Color.red)
        {
            return "red";
        }
        if (button.transform.GetComponent<Renderer>().material.color == Color.blue)
        {
            return "blue";
        }
        return "no Material";
    }

    void SetStaticMaterials()
    {
        StaticBlueMaterial = BlueMaterial;
        StaticRedMaterial = RedMaterial;
        StaticButtons = Buttons;
        staticharts = harts;
    }

    public static void GetLifeDown()
    {
        if (life!=0)
        {
            staticharts[life].gameObject.SetActive(false);
            life--;
        }
        if (life==1)
        {
            EndGame();
        }
    }

    public static void EndGame()
    {
        Application.LoadLevel("Menu");
        print("end game");
    }
}
