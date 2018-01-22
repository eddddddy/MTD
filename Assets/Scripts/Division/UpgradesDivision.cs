using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesDivision : MonoBehaviour
{
    public GameObject divisionTower;
    public Sprite beaconImage;

    DivisionBase divisionBaseScript;
    DivisionUpgrade1 divisionUpgrade1Script;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        divisionBaseScript = divisionTower.GetComponent<DivisionBase>();
        divisionUpgrade1Script = divisionTower.GetComponent<DivisionUpgrade1>();
        spriteRenderer = divisionTower.GetComponent<SpriteRenderer>();
    }

    public void onAttackSpeedClick()
    {
        divisionBaseScript.reloadTime = 0.2f;
        divisionUpgrade1Script.reloadTime = 0.2f;
        spriteRenderer.color = new Color(1, 114 / 255.0f, 17 / 255.0f, 1);
    }

    public void onAttackRangeClick()
    {
        divisionTower.GetComponent<CircleCollider2D>().radius = 1 / (divisionTower.transform.localScale.x * 2 / 3);
        divisionTower.GetComponent<MenuDivision>().genericCircle.transform.localScale = new Vector3(9 / 7, 9 / 7, 1);
    }

    public void onAttackMultipleClick()
    {
        divisionBaseScript.enabled = false;
        divisionUpgrade1Script.enabled = true;
        spriteRenderer.sprite = beaconImage;

        divisionTower.transform.localScale = new Vector3(1, 1, 0);
        divisionTower.GetComponent<CircleCollider2D>().radius = divisionTower.GetComponent<CircleCollider2D>().radius * 3 / 4;
        divisionTower.transform.rotation = Quaternion.identity;
    }
}
