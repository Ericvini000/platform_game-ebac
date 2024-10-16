using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableColoredCoin : ItemCollectableBase
{
    public SpriteRenderer coinSprite;
    public Color color = Color.red;
    public string tagToCompare = "Player";

    private void Awake() {
        if(!coinSprite)
        {
            coinSprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Update() {
        UpdateCoinColor(color);
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.CompareTag("Player"))
        {
            var spriteList = collider.gameObject.transform.GetComponentsInChildren<SpriteRenderer>();

            foreach(var sprite in spriteList)
            {
                sprite.color = color;
            }
            Collect();
        }

    }

    public void UpdateCoinColor(Color newColor)
    {
        coinSprite = GetComponent<SpriteRenderer>();
        coinSprite.color = newColor;
    }
}
