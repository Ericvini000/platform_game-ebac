using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    // public Player playerReference;
    public Vector2 direction;
    public float timeToDestroy = 2f;
    public float side = 1;
    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update() {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var healthReference = collision.gameObject.GetComponent<HealthBase>();

        if(healthReference != null)
        {
            healthReference.TakeDamage();
            Destroy(gameObject);
        }
    }
}
