using UnityEngine;
using System.Collections;

public class SensorManager : MonoBehaviour
{
    TowerController towerController; // Reff to the TowerController Script

    void Awake()
    {
        towerController = GameObject.FindGameObjectWithTag("T_Towers").GetComponent<TowerController>();
    }

    void OnTriggerStay(Collider other)
    {
        towerController.ShootOnSight();
    }
    
}
// When an object is in range, detect it and relay info to shoot > ontrigger enter/stay/exit