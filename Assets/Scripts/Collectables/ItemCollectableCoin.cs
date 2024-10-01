using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ItemCollectableCoin : ItemCollectableBase
{
    public string tagToCompare = "Player";
    public ItemManager Instance;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected override void OnCollect()
    {
        ItemManager.Instance.AddCoins();
    }
}
