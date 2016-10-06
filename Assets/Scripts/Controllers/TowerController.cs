using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //This script shoots out the bullets

    TowerSpawnerManager towerSpawnerManager;    // Refference to the towerSpawnerManager

    public GameObject targetedEnemy;            // When a drone enters the trigger zone, mark them
    public bool targetAcquired;                 // Checks if the targer is in the triggerzone
                                                
    public GameObject bullets;                  // Receives the bullets prefab
    public GameObject shootingArea;             // Where the bullet is shooting
    public Transform bulletExitPoint;           // The position of where the bullets exit from
    public float bulletShootingForce;           // The power of bullets that shoot out 
                                                
    private GameObject bulletShoot;             // Instantiated prefab bullet 
    private Vector3 shootingDirection;          // Where the bullet is shooting towards

    private float startTimer;                   // Resets the timer to this number
    private float timer;                        // Counts down for the next shot

    void Awake()
    {
        towerSpawnerManager = GameObject.FindGameObjectWithTag("T_TowerSpawnerManager").GetComponent<TowerSpawnerManager>();
        startTimer = 1f;
    }

    void Update()
    {
        if(targetedEnemy != null)
        {
            if (targetAcquired == true)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    ShootOnSight();
                    timer = startTimer;
                }
            }
        }
    }

    void OnCollisionEnter(Collision drones)
    {
        if (drones.gameObject.tag == "T_Drones" && gameObject.tag == "T_TowerFirst")
        {
            towerSpawnerManager.canSpawnFirst = true;
            Destroy(gameObject);
        }

        if (drones.gameObject.tag == "T_Drones" && gameObject.tag == "T_TowerMid")
        {
            towerSpawnerManager.canSpawnMid = true;
            Destroy(gameObject);
        }

        if (drones.gameObject.tag == "T_Drones" && gameObject.tag == "T_TowerLast")
        {
            towerSpawnerManager.canSpawnLast = true;
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            targetAcquired = true;
            targetedEnemy = drones.gameObject;
            ShootOnSight();
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