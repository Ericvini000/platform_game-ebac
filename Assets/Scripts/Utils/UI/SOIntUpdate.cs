using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SOIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextCoins;

    private void Start() 
    {
        uiTextCoins.text = soInt.GetValue().ToString();   
    }

    public void Update()
    {
        uiTextCoins.text = "X"+soInt.GetValue().ToString();
    }
}
