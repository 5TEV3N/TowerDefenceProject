using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //Tower shoots
    SensorManager sensorManager;

    public GameObject bullets;
    public Transform bulletExitPoint;
    public float bulletShootingForce;

    private GameObject drones;
    private GameObject bulletShoot;
    private Vector3 dronePosition;
    private Vector3 shootingDirection;

    void Awake()
    {
        drones = GameObject.FindGameObjectWithTag("T_Drones");
        dronePosition = drones.transform.position;
        sensorManager = GameObject.FindGameObjectWithTag("T_Sensor").GetComponent<SensorManager>();
    }

    void Update()
    {
        bulletExitPoint.LookAt(dronePosition);
        if (sensorManager.targetAcquired == true)
        {
            ShootOnSight();
        }
    }

    public void ShootOnSight()
    {
            bulletShoot = GameObject.Instantiate(bullets) as GameObject;
            bulletShoot.transform.position = bulletExitPoint.transform.position;

            //shootingDirection = drones.transform.position - bulletExitPoint.transform.position;
            //shootingDirection.Normalize();
            bulletShoot.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletShootingForce, ForceMode.Impulse);
    }
}
