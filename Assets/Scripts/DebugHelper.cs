using UnityEngine;
using System.Collections;

public class DebugHelper : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void MoveBall(GameObject ball)
    {
        ball.transform.GetComponent<Rigidbody>().AddForce(10, 0, 0);
    }
}
