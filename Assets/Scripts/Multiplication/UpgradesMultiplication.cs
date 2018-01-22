using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesMultiplication : MonoBehaviour
{
    public GameObject multiplicationTower;
    public Sprite beaconImage;

    MultiplicationBase multiplicationBaseScript;
    MultiplicationUpgrade1 multiplicationUpgrade1Script;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        multiplicationBaseScript = multiplicationTower.GetComponent<MultiplicationBase>();
        multiplicationUpgrade1Script = multiplicationTower.GetComponent<MultiplicationUpgrade1>();
        spriteRenderer = multiplicationTower.GetComponent<SpriteRenderer>();
    }

    public void onAttackSpeedClick()
    {
        multiplicationBaseScript.reloadTime = 0.2f;
        multiplicationUpgrade1Script.reloadTime = 0.2f;
        spriteRenderer.color = new Color(1, 114 / 255.0f, 17 / 255.0f, 1);
    }

    public void onAttackRangeClick()
    {
        multiplicationTower.GetComponent<CircleCollider2D>().radius = 1 / (multiplicationTower.transform.localScale.x * 2 / 3);
        multiplicationTower.GetComponent<MenuMultiplication>().genericCircle.transform.localScale = new Vector3(9 / 7, 9 / 7, 1);
    }

    public void onAttackMultipleClick()
    {
        multiplicationBaseScript.enabled = false;
        multiplicationUpgrade1Script.enabled = true;
        spriteRenderer.sprite = beaconImage;

        multiplicationTower.transform.localScale = new Vector3(1, 1, 0);
        multiplicationTower.GetComponent<CircleCollider2D>().radius = multiplicationTower.GetComponent<CircleCollider2D>().radius * 3 / 4;
        multiplicationTower.transform.rotation = Quaternion.identity;
    }
}
