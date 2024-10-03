using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    // public Player playerReference;
    public Vector2 direction;
    public float timeToDestroy = 2f;
    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update() {
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collsion) {
        Destroy(gameObject);
    }
}
