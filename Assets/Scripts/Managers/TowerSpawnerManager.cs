using UnityEngine;
using System.Collections;

public class TowerSpawnerManager : MonoBehaviour
{
    //When the spawners are clicked on, spawn a tower. BUT player must have the sufficient resources

    public GameObject towerSpawn;       //
    public Transform first;             //
    public Transform mid;               //
    public Transform last;              //

    private RaycastHit hit;             //
    private Ray ray;                    //
    private Vector3 rayOrigin;          //



    void Awake()
    {
        //Get the refference of the base to see how much points the player can spend
    }

    void Update()
    {
        rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(rayOrigin, ray.direction * 1000, Color.magenta);    // For testing only
        Physics.Raycast(ray, out hit, 1000f);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("T_First"))
                {

                }

                if (hit.collider.CompareTag("T_Mid"))
                {

                }

                if (hit.collider.CompareTag("T_Last"))
                {

                }
            }
        }
    }
}