using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y <= -5)
        {
            Destroy(gameObject);
            Application.LoadLevel("Home");
        }
    }
}
