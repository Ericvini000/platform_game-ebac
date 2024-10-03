using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int damage = 10;
    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Colision with "+ collision.transform.name);

        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.TakeDamage(damage);
        }
    }

    public void Dead()
    {
        Debug.Log("Morrer");
    }
}
