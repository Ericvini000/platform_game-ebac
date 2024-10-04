using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public int damage = 10;
    public string triggerToAttack = "Attack";
    public string triggerToDeath = "Death";
    public Animator animator;
    private HealthBase _healthReference;

    private void Awake() {
        if(_healthReference == null) {
            _healthReference = GetComponent<HealthBase>();
            _healthReference.OnKill += OnEnemyKill;
        };
    }
    private void OnCollisionEnter2D(Collision2D collision) {

        var playerHealth = collision.gameObject.GetComponent<HealthBase>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            AttackAnimation();
        }
    }

    public void AttackAnimation()
    {
        animator.SetTrigger(triggerToAttack);
    }

    public void OnEnemyKill()
    {
        _healthReference.OnKill -= OnEnemyKill;
        DeathAnimation();
    }

    public void DeathAnimation()
    {
        animator.SetTrigger(triggerToDeath);
    }
}
