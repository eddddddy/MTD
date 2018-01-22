using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour
{
    public bool placerAlreadyCreated = false;
    private Vector3 initialLocation;
    GameObject moneyDisplay;
    ShowMoney showMoneyScript;

    void Start()
    {
        moneyDisplay = (GameObject.FindWithTag("moneydisplay"));
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
    }

    public void onButtonClick(Button clickedButton)
    {
        TowerPlacerCost makeScript = clickedButton.gameObject.GetComponent<TowerPlacerCost>();

        GameObject TowerPlacer = makeScript.TowerPlacer;
        int cost = makeScript.cost;
        if (cost <= showMoneyScript.currentMoney && !placerAlreadyCreated)
        {
            initialLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialLocation.z = transform.position.z;
            Instantiate(TowerPlacer, initialLocation, Quaternion.identity);
            placerAlreadyCreated = true;
        }
    }
}
