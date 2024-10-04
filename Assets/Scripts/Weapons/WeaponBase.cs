using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform shootPlace;
    public float timeBetweenBullets;
    private Coroutine _currentCoroutine;

    public Transform playerReference; 

    private void Update() {
        if(Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(Shooting());
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if(_currentCoroutine != null) StopCoroutine(_currentCoroutine); 
        }
    }

    IEnumerator Shooting()
    {
        while(true){
            Shoot();
            yield return new WaitForSeconds(timeBetweenBullets);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.side = playerReference.transform.localScale.x;
        projectile.transform.position = shootPlace.position; 
    }
}
