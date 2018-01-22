using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCreate : MonoBehaviour {

    public GameObject TowerToCreate;
    public int cost;

    private Vector3 locationTracker;
    GameObject moneyDisplay;
    ShowMoney showMoneyScript;
    Restraints restrainScript;
    CreateTower createTowerScript;

    void Start()
    {
        moneyDisplay = GameObject.FindWithTag("moneydisplay");
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
        restrainScript = GetComponent<Restraints>();
        createTowerScript = GameObject.FindWithTag("itemspanel").GetComponent<CreateTower>();
    }

    void Update ()
    {
        locationTracker = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        locationTracker.z = transform.position.z;

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            createTowerScript.placerAlreadyCreated = false;
        }

        if (Input.GetMouseButtonDown(0) && restrainScript.canCreate)
        {
            Instantiate(TowerToCreate, locationTracker, Quaternion.identity);
            showMoneyScript.currentMoney = showMoneyScript.currentMoney - cost;
            Destroy(gameObject);
            createTowerScript.placerAlreadyCreated = false;
        }
            
        transform.position = locationTracker;
	}
}
