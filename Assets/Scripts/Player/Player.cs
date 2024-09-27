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

    [Header("Animation Player")]
    public string triggerBoolRun = "Run";
    public Animator animator;
    public float flipDuration = .1f;
    public float speedRunningAnimation = 1.5f;
    private bool _isRunning;

    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        _isRunning = false;
    }
    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void isItRunning()
    {
        _isRunning = !_isRunning;
        if(_isRunning)
        {
            animator.SetBool(triggerBoolRun, true);
        }else {
            animator.SetBool(triggerBoolRun, false);
        }
    }

    private void HandleMovement() 
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRunning;
            animator.speed = speedRunningAnimation;
        }
        else {
            _currentSpeed = speed;
            animator.speed = 1;
        } 

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector2(_currentSpeed, rigidBody.velocity.y);
            FlipPlayer("Right");
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow)) isItRunning();

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-_currentSpeed, rigidBody.velocity.y);
            FlipPlayer("Left");
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) isItRunning();


        if(rigidBody.velocity.x > 0)
        {
            rigidBody.velocity += friction;
        }
        if(rigidBody.velocity.x < 0)
        {
            rigidBody.velocity -= friction;
        }
    }

    private void FlipPlayer(string direction)
    {
        string _currentDirection = direction.ToLower();
        if(_currentDirection == "right")
        {
            rigidBody.transform.DOScaleX(1, flipDuration);
        }
        if(_currentDirection == "left")
        {
            rigidBody.transform.DOScaleX(-1, flipDuration);
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
