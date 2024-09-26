using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [Header("Speed Configurations")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed = 10f;
    public float speedRunning = 15f;
    private float _currentSpeed;
    public float jumpForce = 5f;

    [Header("Animation Configurations")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement() 
    {
        if(Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRunning;
        else 
            _currentSpeed = speed;


        if(Input.GetKey(KeyCode.RightArrow))
        {
            // rigidBody.MovePosition(rigidBody.position + velocity * Time.deltaTime);
            rigidBody.velocity = new Vector2(_currentSpeed, rigidBody.velocity.y);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // rigidBody.MovePosition(rigidBody.position - velocity * Time.deltaTime);
            rigidBody.velocity = new Vector2(-_currentSpeed, rigidBody.velocity.y);
        }

        if(rigidBody.velocity.x > 0)
        {
            rigidBody.velocity += friction;
        }
        if(rigidBody.velocity.x < 0)
        {
            rigidBody.velocity -= friction;
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * jumpForce;
            rigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(rigidBody.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        rigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo);
        rigidBody.transform.DOScaleY(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo);
    }
}
