using UnityEngine;
using System.Collections;

public class SensorManager : MonoBehaviour
{
    TowerController towerController; // Reff to the TowerController Script
    private GameObject[] drones; //    This is the enemy that the sensor senses

    void Awake()
    {
        towerController = GameObject.FindGameObjectWithTag("T_Towers").GetComponent<TowerController>();
        drones = GameObject.FindGameObjectsWithTag("T_Drones");

        print(drones.Length);
    }

    void OnTriggerStay(Collider other)
    {
        towerController.ShootOnSight();
        print("Drone Entered Tower's Field");
    }
}