using UnityEngine;
using System.Collections;

public class SensorManager : MonoBehaviour
{
    //This script detects when a drone comes by, then relays info the the tower controller

    TowerController towerController; // Reff to the TowerController Script
    public bool targetAcquired;

    private GameObject targetedEnemy;

    void Awake()
    {
        towerController = GameObject.FindGameObjectWithTag("T_Towers").GetComponent<TowerController>();
    }

    void OnTriggerStay(Collider drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            targetAcquired = true;
            targetedEnemy = drones.gameObject;
            print("Target Acquired");
            Fire();
            
        }
    }

    void OnTriggerExit(Collider drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            targetAcquired = false;
            print("Target Lost");
            if (targetAcquired == false)
            {
                targetedEnemy = null;
            }
        }       
    }

    void Fire()
    {
        if (targetedEnemy != null)
        {
            if (targetAcquired == true)
            {
                towerController.ShootOnSight();
            }
        }
    }
}