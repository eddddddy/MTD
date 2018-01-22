using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLives : MonoBehaviour
{

    GameObject livesDisplay;
    ShowLives showLivesScript;

    void Start()
    {
        livesDisplay = (GameObject.FindWithTag("livesdisplay"));
        showLivesScript = livesDisplay.GetComponent<ShowLives>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            showLivesScript.currentLives = Mathf.Max(showLivesScript.currentLives - other.gameObject.GetComponent<Mutations>().strength, 0);
            Destroy(other.gameObject);
        }
    }

}
