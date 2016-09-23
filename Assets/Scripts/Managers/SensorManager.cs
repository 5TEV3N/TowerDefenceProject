using UnityEngine;
using System.Collections;

public class SensorManager : MonoBehaviour
{
    TowerController towerController; // Reff to the TowerController Script
    public GameObject drones; //    This is the enemy that the sensor senses

    void Awake()
    {
        towerController = GameObject.FindGameObjectWithTag("T_Towers").GetComponent<TowerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        towerController.ShootOnSight(drones);
        print("Drone Entered Tower's Field");
    }
}
// When an object is in range, detect it and relay info to shoot > ontrigger enter/stay/exit