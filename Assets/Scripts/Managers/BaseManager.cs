﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BaseManager : MonoBehaviour
{
    // click on base (cookie clicker style) to get more points. points are used to buy more powerups(?)
    public int playerResource;                  // Keeps track of how much resources
    public bool isBaseAlive = true;             // Self explanatory
    public Text Score;                          // Reference to the Text Score component.

    void OnMouseDown()
    {
        if (isBaseAlive == true)
        {
            playerResource++;
            Score.text = "SCORE : " + playerResource;
        }
    }
}
