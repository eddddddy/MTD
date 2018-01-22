using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{

    public List<GameObject> roundAttackers;
    public List<float> timeOffsets;
    public int RoundReward;

    int numberAttackers;

    private int attackerPosition = 0;

    GameObject nextAttacker;
    float lastTime;
    float nextTimeOffset;
    GameObject moneyDisplay;
    GameObject startRoundButton;
    ShowMoney showMoneyScript;
    StartRounds startRoundsScript;

    void Start()
    {
        numberAttackers = timeOffsets.Count;
        lastTime = Time.time;
        nextAttacker = roundAttackers[attackerPosition];
        nextTimeOffset = timeOffsets[attackerPosition];

        moneyDisplay = GameObject.FindWithTag("moneydisplay");
        showMoneyScript = moneyDisplay.GetComponent<ShowMoney>();
        startRoundButton = GameObject.FindWithTag("startbutton");
        startRoundsScript = startRoundButton.GetComponent<StartRounds>();
    }

    void Update()
    {
        float currentTime = Time.time;
        if (currentTime - lastTime >= nextTimeOffset)
        {
            if (attackerPosition <= numberAttackers - 1)
            {
                Instantiate(nextAttacker, new Vector3(-9.2f, 2.03f, 0), Quaternion.identity);
            }

            attackerPosition++;
            
            if (attackerPosition >= numberAttackers)
            {
                if (!startRoundsScript.roundInProgress)
                {
                    showMoneyScript.currentMoney = showMoneyScript.currentMoney + RoundReward;
                    enabled = false;
                }
            }

            else
            {
                lastTime = currentTime;
                nextAttacker = roundAttackers[attackerPosition];
                nextTimeOffset = timeOffsets[attackerPosition];
            }
        }
    }
}
