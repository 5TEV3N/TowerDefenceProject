using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //BulletController bulletController;
    public GameObject bullet;
    public Transform bulletExitPoint;

    public void ShootOnSight()
    {
        GameObject bulletShoot = GameObject.Instantiate(bullet);    //Spawn bullet while enemies stay on your sensor
        bulletShoot.transform.position = bulletExitPoint.transform.position; //Spawn this bullet on the same transform as the gameobject that this script is attached

        //Vector3 shootingDirection = bulletShoot.transform.position - bulletExitPoint.transform.position;
        //shootingDirection.Normalize();

    }

}