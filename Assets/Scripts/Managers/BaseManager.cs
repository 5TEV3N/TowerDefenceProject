using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BaseManager : MonoBehaviour
{
    // click on base (cookie clicker style) to get more points. points are used to buy more powerups(?)
    public static int playerResource;           // Keeps track of how much resources
    public bool isBaseAlive = true;             // Self explanatory
    public Text Score;                          // Reference to the Text component.

    void OnMouseDown()
    {
        if (isBaseAlive == true)
        {
            print("+1 Resouce");
            playerResource++;
            Score.text = "SCORE : " + playerResource;
        }
    }
}
