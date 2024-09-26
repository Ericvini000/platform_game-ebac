using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    // public Vector2 velocity;

    public float speed = 10f;

    private void Awake() {
        rigidBody = GetComponentInChildren<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            // rigidBody.MovePosition(rigidBody.position + velocity * Time.deltaTime);
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
        if(Input.GetKey(KeyCode.A))
        {
            // rigidBody.MovePosition(rigidBody.position - velocity * Time.deltaTime);
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        }
    }
}
