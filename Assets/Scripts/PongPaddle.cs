using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Borrowed code from here: https://www.awesomeinc.org/tutorials/unity-pong/

[RequireComponent(typeof(Rigidbody2D))]
public class PongPaddle : MonoBehaviour
{

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float topY = 2.25f;
    public float bottomY = -2.25f;
    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = _rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        _rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > topY)
        {
            pos.y = topY;
        }
        else if (pos.y < bottomY)
        {
            pos.y = bottomY;
        }
        transform.position = pos;
    }
}
