using System.Collections;
using System.Collections.Generic;
using Scripts.Core.Singleton;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Coins")]
    public int coins;
    public TextMeshProUGUI hudCoins;
    
    [Header("Weapons")]
    public string weapon;

    private void Start() 
    {
        Reset();
    }

    public void Reset() 
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateText();
    }

    public void UpdateText()
    {
        hudCoins.text = "X"+coins.ToString();
    }
}

