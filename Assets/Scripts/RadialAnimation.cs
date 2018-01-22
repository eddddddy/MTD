using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialAnimation : MonoBehaviour
{

    public float maxRadius;
    public string hoopType;
    public GameObject debris;

    private int k = 0;
    private GameObject moneyDisplay;
    private ShowMoney showMoneyScript;
    private GameObject nextObject;
    private List<GameObject> immuneAttackers = new List<GameObject>();

    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        moneyDisplay = GameObject.FindWithTag("moneydisplay");
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker") && !immuneAttackers.Contains(other.gameObject))
        {
            Mutations mutationScript = other.gameObject.GetComponent<Mutations>();
            Track1Travel oldPathTravelScript = other.gameObject.GetComponent<Track1Travel>();

            if (hoopType == "subtraction") { nextObject = mutationScript.SubtractionMutation; }
            else if (hoopType == "addition") { nextObject = mutationScript.AdditionMutation; }
            else if (hoopType == "multiplication") { nextObject = mutationScript.Multiplication2Mutation; }
            else if (hoopType == "division") { nextObject = mutationScript.Division2Mutation; }

            if (nextObject == null)
            {
                showMoneyScript.currentMoney++;
                Instantiate(debris, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            else
            {
                GameObject newObject = Instantiate(nextObject, other.gameObject.transform.position, Quaternion.identity);
                immuneAttackers.Add(newObject);

                Track1Travel newPathTravelScript = newObject.GetComponent<Track1Travel>();
                newPathTravelScript.direction = oldPathTravelScript.direction;

                showMoneyScript.currentMoney++;
                Instantiate(debris, other.gameObject.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (k == 6)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = new Vector3(k * maxRadius / 8, k * maxRadius / 8, 0);
            k++;
        }
    }

}
