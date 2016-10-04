using UnityEngine;
using System.Collections;

public class HighlightSelection : MonoBehaviour
{
    TowerSpawnerManager towerSpawnerManager;    //Refference to the TowerSpawnerManager

    void Awake()
    {
        towerSpawnerManager = GameObject.FindGameObjectWithTag("T_TowerSpawnerManager").GetComponent<TowerSpawnerManager>();

    }
    void OnMouseOver()
    {
        if (towerSpawnerManager.canSpawnFirst == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (towerSpawnerManager.canSpawnMid == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (towerSpawnerManager.canSpawnLast == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else { return; }
    }
    
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
