using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region variables
    public GameObject[] Buttons = new GameObject[3];
    public GameObject[] harts = new GameObject[3];
    public Material BlueMaterial;
    public Material RedMaterial;

    public static int life = 2;
    #endregion
    #region must be static
    public static Material StaticBlueMaterial;
    public static Material StaticRedMaterial;
    public static GameObject[] StaticButtons = new GameObject[3];
    public static GameObject[] staticharts = new GameObject[3];
    public static int[] holder;
    #endregion

    // Use this for initialization
    void Start()
    {
        // Freez for a second
        System.Threading.Thread.Sleep(1000);
        holder = new int[2] { 0, -1 };
        life = 2;
        SetStaticMaterials();
        ChangeButtons();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void ChangeButtons()
    {
        // Paint all red
        foreach (GameObject Button in StaticButtons)
        {
            Button.GetComponent<Renderer>().material = StaticRedMaterial;
        }
        // Makes sure that the random don't repeat more then 3 times
        #region
        int rand = Random.Range(0, 3);
        while (holder[0] == rand || holder[1] <= 3)
        {
            rand = Random.Range(0, 3);
        }
        if (rand == holder[0])
        {
            holder[1]++;
        }
        else
        {
            holder[0] = rand;
            holder[1] = 0;
        }
        #endregion
        // Paint random one blue
        StaticButtons[rand].GetComponent<Renderer>().material = StaticBlueMaterial;
    }

    public static string GetMaterialColor(GameObject button)
    {
        if (button.transform.GetComponent<Renderer>().material.color == Color.red)
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
        if (life != 0)
        {
            bool a = PlayAnimation(staticharts[life]);
            staticharts[life].gameObject.SetActive(false);
            life--;
        }
        else if (life == 0)
        {
            EndGame();
        }
    }

    public static void EndGame()
    {
        GUIScoreScript.SaveHighScore();
        Application.LoadLevel("Menu");
        print("end game");
    }

    public static bool PlayAnimation(GameObject obj)
    {
        /* float startTime = Time.time;
         obj.transform.GetComponent<Animator>().enabled = true;
         WaitForSec(0.15f);
         while (Time.time<startTime+15)
         {

         }
         obj.transform.GetComponent<Animator>().enabled = false;*/
        return true;
    }

    public static void WaitForSec(float sec)
    {
        float startTime = Time.time;
        while (startTime + sec > Time.time)
        {

        }
    }

}
