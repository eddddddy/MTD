using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLives : MonoBehaviour {

    public int currentLives;
    private Text livesDisplay;
	
	void Start()
    {
        livesDisplay = GetComponent<Text>();
        livesDisplay.text = "Lives: " + currentLives.ToString();
    }

    void Update()
    {
        livesDisplay.text = "Lives: " + currentLives.ToString();
    }
}
