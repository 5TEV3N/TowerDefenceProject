using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //This script shoots out the bullets
    SensorManager sensorManager;            // Refference to the SensorManager

    public GameObject bullets;              // Receives the bullets prefab
    public Transform bulletExitPoint;       // The position of where the bullets exit from
    public float bulletShootingForce;       // The power of bullets that shoot out 
    public GameObject shootingArea;         // Where the bullet is shooting

    private GameObject bulletShoot;         // Instantiated prefab bullet 
    private Vector3 shootingDirection;      // Where the bullet is shooting towards

    void Awake()
    {
        sensorManager = GameObject.FindGameObjectWithTag("T_Sensor").GetComponent<SensorManager>();
    }

    void OnCollisionEnter(Collision drones)
    {
        if (drones.gameObject.tag == "T_Drones")
        {
            Destroy(gameObject);
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
