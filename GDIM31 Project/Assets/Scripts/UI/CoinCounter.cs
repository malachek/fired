using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI CoinDisplay;

    private void Start()
    {
        SetCoinDisplay(0);
    }
    public void SetCoinDisplay(int coins)
    {
        CoinDisplay.text = "$" + coins;
    }
}
