using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action OnKill;
    public float startLife = 10;
    private float _currentLife;
    private bool _isDead = false;
    public bool destroyOnKill = false;
    public float timeTillDie = 1f;
    private FlashColor _flashColor; 


    private void Awake() {
        Init();

        if(_flashColor == null) 
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }


    public void TakeDamage(int damage = 1)
    {
        if (_isDead) return;

        _currentLife -= damage;
        Debug.Log("Life left: "+_currentLife);

        if (_currentLife <= 0)
        {
            Kill();
        }

        _flashColor.Flash();
    }

    private void Kill()
    {
        _isDead = true;
        OnKill?.Invoke();

        if (destroyOnKill)
        {
            Destroy(gameObject, timeTillDie);    
        }

    }
}
