using UnityEngine;
using System.Collections;

public class BaseManager : MonoBehaviour
{
    // click on base (cookie clicker style) to get more points. points are used to buy more powerups(?)
    public int playerResource;          // Keeps track of how much resources


    void OnMouseDown()
    {
        print("+1 Resouce");
        playerResource++;
    }
}
