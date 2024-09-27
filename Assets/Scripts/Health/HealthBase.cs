using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float startLife = 10;
    private float _currentLife;
    private bool _isDead = false;
    public bool destroyOnKill = false;
    public float timeTillDie = 1f;

    private void Awake() {
        Init();
    }

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }


    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;
        Debug.Log("Life left: "+_currentLife);

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, timeTillDie);    
        }
    }
}
