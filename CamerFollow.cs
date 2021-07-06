using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    public GameObject player; //ตัวกล้องตาม
    public float xMin; //0
    public float xMax; //30.98
    public float yMin; //0
    public float yMax; //1.57

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }
}