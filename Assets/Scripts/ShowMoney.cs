using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour {

    public int currentMoney;
    private Text moneyDisplay;

	void Start ()
    {
        moneyDisplay = GetComponent<Text>();
        moneyDisplay.text = "Money: $" + currentMoney.ToString();
	}
	
	void Update ()
    {
        moneyDisplay.text = "Money: $" + currentMoney.ToString();
	}
}
