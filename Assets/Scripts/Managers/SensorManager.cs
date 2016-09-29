using UnityEngine;
using System.Collections;

public class SensorManager : MonoBehaviour
{
    //This script detects when a drone comes by, then relays info the the tower controller

    TowerController towerController;        // Refference to the SensorManager
    public GameObject targetedEnemy;        // When a drone enters the trigger zone, mark them
    public bool targetAcquired;             // Checks if the targer is in the triggerzone

    void Awake()
    {
        towerController = GameObject.FindGameObjectWithTag("T_Towers").GetComponent<TowerController>();
    }

    void Update()
    {
        Fire();
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

    void OnTriggerEnter(Collider drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            targetAcquired = true;
            targetedEnemy = drones.gameObject;
            print("Target Acquired");
        }
    }

    void OnTriggerExit(Collider drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            targetAcquired = false;
            if (targetAcquired == false)
            {
                targetedEnemy = null;
            }
            print("Target Lost");
        }       
    }
}