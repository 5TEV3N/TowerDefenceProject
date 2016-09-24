using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletExitPoint;
    public float bulletShootingForce;

    public void ShootOnSight()
    {

        /*
        GameObject bulletShoot = GameObject.Instantiate(bullet);    //Spawn bullet while enemies stay on your sensor
        bulletShoot.transform.position = bulletExitPoint.transform.position; //Spawn this bullet on the same transform as the gameobject that this script is attached

        Vector3 shootingDirection = drones.transform.position - bulletExitPoint.transform.position;
        shootingDirection.Normalize();

        bulletShoot.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletShootingForce, ForceMode.Impulse);
        */
    }
}