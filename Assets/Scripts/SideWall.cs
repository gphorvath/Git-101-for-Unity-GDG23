using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Borrowed code from here: https://www.awesomeinc.org/tutorials/unity-pong/

public class SideWall : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            GameManager.Instance.Score(wallName);
            //hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
