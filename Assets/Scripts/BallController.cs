using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Borrowed code from here: https://www.awesomeinc.org/tutorials/unity-pong/

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Vector2 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _startingPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        Invoke("GoBall", 2);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            _rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            _rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void ResetBall()
    {
        _rb2d.velocity = Vector2.zero;
        transform.position = _startingPosition;
    }

    public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = _rb2d.velocity.x;
            vel.y = (_rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            _rb2d.velocity = vel;
        }
    }
}
