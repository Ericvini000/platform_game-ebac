using System.Collections;
using System.Collections.Generic;
using Scripts.Core.Singleton;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Coins")]
    public SOInt coins;
    public TextMeshProUGUI hudCoins;

    private void Start() 
    {
        Reset();
    }

    public void Reset() 
    {
        coins.SetValue(0);
    }

    public void AddCoins(int amount = 1)
    {
        int totalCoins = amount + coins.GetValue();
        coins.SetValue(totalCoins);
        UpdateText();
    }

    public void UpdateText()
    {
        hudCoins.text = "X"+coins.GetValue().ToString();
    }
}

