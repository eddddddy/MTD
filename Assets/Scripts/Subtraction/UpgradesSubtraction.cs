using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesSubtraction : MonoBehaviour
{
    public GameObject subtractionTower;
    public Sprite beaconImage;

    SubtractionBase subtractionBaseScript;
    SubtractionUpgrade1 subtractionUpgrade1Script;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        subtractionBaseScript = subtractionTower.GetComponent<SubtractionBase>();
        subtractionUpgrade1Script = subtractionTower.GetComponent<SubtractionUpgrade1>();
        spriteRenderer = subtractionTower.GetComponent<SpriteRenderer>();
    }

    public void onAttackSpeedClick()
    {
        subtractionBaseScript.reloadTime = 0.15f;
        subtractionUpgrade1Script.reloadTime = 0.15f;
        spriteRenderer.color = new Color(1, 114 / 255.0f, 17 / 255.0f, 1);
    }

    public void onAttackRangeClick()
    {
        subtractionTower.GetComponent<CircleCollider2D>().radius = 1 / (subtractionTower.transform.localScale.x * 8 / 15);
        subtractionTower.GetComponent<MenuSubtraction>().genericCircle.transform.localScale = new Vector3(1.25f, 1.25f, 1);
    }

    public void onAttackMultipleClick()
    {
        subtractionBaseScript.enabled = false;
        subtractionUpgrade1Script.enabled = true;
        spriteRenderer.sprite = beaconImage;

        subtractionTower.transform.localScale = new Vector3(1, 1, 0);
        subtractionTower.GetComponent<CircleCollider2D>().radius = subtractionTower.GetComponent<CircleCollider2D>().radius * 3 / 4;
        subtractionTower.transform.rotation = Quaternion.identity;
    }

}
