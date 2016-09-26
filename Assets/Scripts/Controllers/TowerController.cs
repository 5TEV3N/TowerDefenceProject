using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    //Tower shoots
    public GameObject bullets;
    public Transform bulletExitPoint;
    public float bulletShootingForce;

    private GameObject drones;

    void Awake()
    {
        drones = GameObject.FindGameObjectWithTag("T_Drones");
    }

    public void ShootOnSight()
    {
        GameObject bulletShoot = GameObject.Instantiate(bullets) as GameObject;
        bulletShoot.transform.position = bulletExitPoint.transform.position;

        Vector3 shootingDirection = drones.transform.position - bulletExitPoint.transform.position;
        shootingDirection.Normalize();

        bulletShoot.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletShootingForce, ForceMode.Impulse);
    }
}
