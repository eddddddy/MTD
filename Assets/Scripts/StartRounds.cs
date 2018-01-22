using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRounds : MonoBehaviour
{
    public List<GameObject> rounds;
    private int currentRoundNumber = 0;

    public bool roundInProgress;
    int numberOfRounds;
    GameObject currentRound;
    List<GameObject> enemiesOnRadar = new List<GameObject>();

    void Start()
    {
        numberOfRounds = rounds.Count;
        currentRound = rounds[currentRoundNumber];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            enemiesOnRadar.Add(other.gameObject);
            roundInProgress = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("attacker"))
        {
            enemiesOnRadar.Remove(other.gameObject);
            if (enemiesOnRadar.Count == 0)
            {
                roundInProgress = false;
            }
        }
    }

    public void OnClick()
    {
        if (!roundInProgress && currentRoundNumber < numberOfRounds)
        {
            Instantiate(currentRound, new Vector3(0, 0, 0), Quaternion.identity);
            roundInProgress = true;
            currentRoundNumber++;

            if (currentRoundNumber < numberOfRounds)
            {
                currentRound = rounds[currentRoundNumber];
            }
        }
    }
}
