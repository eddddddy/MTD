using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDescriptions : MonoBehaviour
{

    public GameObject descriptionText;
    GameObject description;

    void Start()
    {
        description = Instantiate(descriptionText, new Vector3(10000, 0, 0), Quaternion.identity, gameObject.transform);
    }

    public void OnMouseOver()
    {
        description.transform.position = gameObject.transform.position;
    }

    public void OnMouseExit()
    {
        description.transform.position = new Vector3(10000, 0, 0);
    }
}
