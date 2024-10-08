using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public SOPlayerSetup player;
    private HealthBase _healthReference;

    private float _currentSpeed;
    private bool _isRunning;
    private Animator _currentPlayer;


    private void Awake() {
        if(rigidBody == null) rigidBody = GetComponent<Rigidbody2D>();

        if(_healthReference == null)
        {
            _healthReference = GetComponent<HealthBase>();
            _healthReference.OnKill += OnPlayerDeath;
        }

        _currentPlayer = Instantiate(player.playerArt, transform);
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
            _currentPlayer.SetBool(player.triggerBoolRun, true);
        }else {
            _currentPlayer.SetBool(player.triggerBoolRun, false);
        }
    }

    private void HandleMovement() 
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = player.speedRunning;
            _currentPlayer.speed = player.speedRunningAnimation;
        }
        else {
            _currentSpeed = player.speed;
            _currentPlayer.speed = 1;
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
            rigidBody.velocity += player.friction;
        }
        if(rigidBody.velocity.x < 0)
        {
            rigidBody.velocity -= player.friction;
        }
    }

    private void FlipPlayer(string direction)
    {
        string _currentDirection = direction.ToLower();
        if(_currentDirection == "right")
        {
            rigidBody.transform.DOScaleX(1, player.flipDuration);
        }
        if(_currentDirection == "left")
        {
            rigidBody.transform.DOScaleX(-1, player.flipDuration);
        }
    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * player.jumpForce;
            rigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(rigidBody.transform);
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        rigidBody.transform.DOScaleY(player.jumpScaleY, player.animationDuration).SetLoops(2, LoopType.Yoyo);
        rigidBody.transform.DOScaleY(player.jumpScaleX, player.animationDuration).SetLoops(2, LoopType.Yoyo);
    }

    public void OnPlayerDeath()
    {
        _healthReference.OnKill -= OnPlayerDeath;
        _currentPlayer.SetTrigger(player.triggerDeath);
    }
}
