using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Speed Configurations")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed = 10f;
    public float speedRunning = 15f;
    public float jumpForce = 5f;

    [Header("Animation Configurations")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;

    [Header("Animation Player")]
    public string triggerBoolRun = "Run";
    public string triggerDeath = "Death";
    public float flipDuration = .1f;
    public float speedRunningAnimation = 1.5f;
}
