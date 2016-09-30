using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //This script shoots out the bullets

    public GameObject targetedEnemy;        // When a drone enters the trigger zone, mark them
    public bool targetAcquired;             // Checks if the targer is in the triggerzone

    public GameObject bullets;              // Receives the bullets prefab
    public GameObject shootingArea;         // Where the bullet is shooting
    public Transform bulletExitPoint;       // The position of where the bullets exit from
    public float bulletShootingForce;       // The power of bullets that shoot out 

    private GameObject bulletShoot;         // Instantiated prefab bullet 
    private Vector3 shootingDirection;      // Where the bullet is shooting towards

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
                ShootOnSight();
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

    public void ShootOnSight()
    {
        bulletShoot = GameObject.Instantiate(bullets) as GameObject;
        bulletShoot.transform.position = bulletExitPoint.transform.position;

        shootingDirection = shootingArea.transform.position - bulletExitPoint.transform.position;
        shootingDirection.Normalize();
        bulletShoot.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletShootingForce, ForceMode.Impulse);
    }
}