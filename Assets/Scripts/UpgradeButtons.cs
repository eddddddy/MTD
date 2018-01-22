using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour {

    public int cost;

    GameObject moneyDisplay;
    ShowMoney showMoneyScript;
    private bool alreadyBought = false;

    void Start()
    {
        moneyDisplay = (GameObject.FindWithTag("moneydisplay"));
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
    }

    public void onClick()
    {
        alreadyBought = true;
        GetComponent<Button>().image.color = new Color(43 / 255.0f, 233 / 255.0f, 27 / 255.0f, 1);
        GetComponent<Button>().interactable = false;
        showMoneyScript.currentMoney = showMoneyScript.currentMoney - cost;
    }

    void Update()
    {
        if (cost > showMoneyScript.currentMoney)
        {
            GetComponent<Button>().interactable = false;
        }
        else if (!alreadyBought)
        {
            GetComponent<Button>().interactable = true;
        }
    }

}
