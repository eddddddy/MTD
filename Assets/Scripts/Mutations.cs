using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutations : MonoBehaviour
{

    public GameObject AdditionMutation;
    public GameObject SubtractionMutation;
    public GameObject Multiplication2Mutation;
    public GameObject Division2Mutation;
    public int strength;
    public GameObject debris;
    public List<string> bulletList = new List<string>();

    private GameObject nextObject;
    private GameObject moneyDisplay;
    private ShowMoney showMoneyScript;

    void Start()
    {
        moneyDisplay = GameObject.FindWithTag("moneydisplay");
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
    }

    void Update()
    {
        if (bulletList.Count > 0)
        {
            if (bulletList.Count == 1)
            {
                if (bulletList[0] == "addition")
                {
                    nextObject = AdditionMutation;
                }
                else if (bulletList[0] == "subtraction")
                {
                    nextObject = SubtractionMutation;
                }
                else if (bulletList[0] == "multiplication")
                {
                    nextObject = Multiplication2Mutation;
                }
                else if (bulletList[0] == "division")
                {
                    nextObject = Division2Mutation;
                }
            }
            else if (bulletList.Count == 2)
            {
                // same operations:
                if (bulletList[0] == "addition" && bulletList[1] == "addition")
                {
                    nextObject = AdditionMutation.GetComponent<Mutations>().AdditionMutation;
                }
                else if (bulletList[0] == "subtraction" && bulletList[1] == "subtraction")
                {
                    nextObject = SubtractionMutation.GetComponent<Mutations>().SubtractionMutation;
                }
                else if (bulletList[0] == "multiplication" && bulletList[1] == "multiplication")
                {
                    nextObject = Multiplication2Mutation.GetComponent<Mutations>().Multiplication2Mutation;
                }
                else if (bulletList[0] == "division" && bulletList[1] == "division")
                {
                    nextObject = Division2Mutation.GetComponent<Mutations>().Division2Mutation;
                }
                // commutative operations:
                else if ((bulletList[0] == "addition" && bulletList[1] == "subtraction") || (bulletList[0] == "subtraction" && bulletList[1] == "addition"))
                {
                    nextObject = gameObject;
                }
                else if ((bulletList[0] == "multiplication" && bulletList[1] == "division") || (bulletList[0] == "division" && bulletList[1] == "multiplication"))
                {
                    nextObject = gameObject;
                }
                // other operations (tentative, since order of operations is arbitrary (does it have to be? this could be turned into a feature)):
                // edit: I'm going with this order of operations concept
                else if ((bulletList[0] == "addition" && bulletList[1] == "multiplication") || (bulletList[0] == "multiplication" && bulletList[1] == "addition"))
                {
                    nextObject = Multiplication2Mutation.GetComponent<Mutations>().AdditionMutation;
                }
                else if ((bulletList[0] == "addition" && bulletList[1] == "division") || (bulletList[0] == "division" && bulletList[1] == "addition"))
                {
                    nextObject = Division2Mutation.GetComponent<Mutations>().AdditionMutation;
                }
                else if ((bulletList[0] == "subtraction" && bulletList[1] == "multiplication") || (bulletList[0] == "multiplication" && bulletList[1] == "subtraction"))
                {
                    nextObject = Multiplication2Mutation.GetComponent<Mutations>().SubtractionMutation;
                }
                else if ((bulletList[0] == "subtraction" && bulletList[1] == "division") || (bulletList[0] == "division" && bulletList[1] == "subtraction"))
                {
                    nextObject = Division2Mutation.GetComponent<Mutations>().SubtractionMutation;
                }
            }
            else if (bulletList.Count == 3)
            {
                // finish later
            }

            if (nextObject == null)
            {
                showMoneyScript.currentMoney++;
                Instantiate(debris, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                GameObject newObject = Instantiate(nextObject, transform.position, Quaternion.identity);

                Track1Travel oldPathTravelScript = gameObject.GetComponent<Track1Travel>();
                Track1Travel newPathTravelScript = newObject.GetComponent<Track1Travel>();
                newPathTravelScript.direction = oldPathTravelScript.direction;

                showMoneyScript.currentMoney++;
                Instantiate(debris, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
