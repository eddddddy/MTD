using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAddition : MonoBehaviour
{
    public GameObject upgradePanel;
    GameObject backgroundPanel; // parent
    GameObject upgradeMenu;

    public GameObject genericCircle;

    private bool alreadyOpen = false;
    private float xStartComponentUI;

    void Start()
    {
        alreadyOpen = true;

        backgroundPanel = GameObject.FindGameObjectWithTag("panel");
        upgradeMenu = Instantiate(upgradePanel, backgroundPanel.transform.position, Quaternion.identity, backgroundPanel.transform);
        upgradeMenu.GetComponent<UpgradesAddition>().additionTower = gameObject;
        xStartComponentUI = upgradeMenu.transform.position.x - 1.44f;

        genericCircle = Instantiate(genericCircle, transform.position, Quaternion.identity);
        genericCircle.GetComponent<SpriteRenderer>().color = new Color(60 / 255.0f, 191 / 255.0f, 132 / 255.0f, 160 / 255.0f);
        genericCircle.transform.localScale = new Vector3(0.75f, 0.75f, 1);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((clickPosition.x >= transform.position.x - 0.36f) && (clickPosition.x <= transform.position.x + 0.36f) &&
                (clickPosition.y >= transform.position.y - 0.36f) && (clickPosition.y <= transform.position.y + 0.36f) &&
                !alreadyOpen)
            {
                alreadyOpen = true;
                upgradeMenu.transform.position = backgroundPanel.transform.position;
                genericCircle.transform.position = transform.position;
            }
            else if (alreadyOpen && clickPosition.x < xStartComponentUI)
            {
                alreadyOpen = false;
                upgradeMenu.transform.position = new Vector3(100000, 0, 0);
                genericCircle.transform.position = new Vector3(100000, 0, 0);
            }
        }
    }

}
