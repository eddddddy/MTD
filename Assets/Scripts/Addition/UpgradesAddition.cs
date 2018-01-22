using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesAddition : MonoBehaviour
{
    public GameObject additionTower;
    public Sprite beaconImage;

    AdditionBase additionBaseScript;
    AdditionUpgrade1 additionUpgrade1Script;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        additionBaseScript = additionTower.GetComponent<AdditionBase>();
        additionUpgrade1Script = additionTower.GetComponent<AdditionUpgrade1>();
        spriteRenderer = additionTower.GetComponent<SpriteRenderer>();
    }

    public void onAttackSpeedClick()
    {
        additionBaseScript.reloadTime = 0.15f;
        additionUpgrade1Script.reloadTime = 0.15f;
        spriteRenderer.color = new Color(1, 114 / 255.0f, 17 / 255.0f, 1);
    }

    public void onAttackRangeClick()
    {
        additionTower.GetComponent<CircleCollider2D>().radius = 1 / (additionTower.transform.localScale.x * 8 / 15);
        additionTower.GetComponent<MenuAddition>().genericCircle.transform.localScale = new Vector3(1.25f, 1.25f, 1);
    }

    public void onAttackMultipleClick()
    {
        additionBaseScript.enabled = false;
        additionUpgrade1Script.enabled = true;
        spriteRenderer.sprite = beaconImage;

        additionTower.transform.localScale = new Vector3(1, 1, 0);
        additionTower.GetComponent<CircleCollider2D>().radius = additionTower.GetComponent<CircleCollider2D>().radius * 3 / 4;
        additionTower.transform.rotation = Quaternion.identity;
    }

}
