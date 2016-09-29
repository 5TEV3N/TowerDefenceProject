using UnityEngine;
using System.Collections;

public class TowerSpawnerManager : MonoBehaviour
{
    //When the spawners are clicked on, spawn a tower. BUT player must have the sufficient resources

    public GameObject towerSpawn;       // Receives tower prefab
    public Transform first;             // Position of first tower spawner
    public Transform mid;               // Position of mid tower spawner
    public Transform last;              // Position of last tower spawner
    public bool placed;                 // If tower is placed = don't spawn


    private RaycastHit hit;             // Gets info from the raycast
    private Ray ray;                    // Ray that gathers info
    private Vector3 rayOrigin;          // Position of ray 



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
                    print("first");
                    towerSpawn = Instantiate(towerSpawn);
                    towerSpawn.transform.SetParent(first); // makes this true/false
                    towerSpawn.transform.position = first.transform.position + new Vector3 (0,towerSpawn.transform.position.y,0);
                }

                if (hit.collider.CompareTag("T_Mid"))
                {
                    print("mid");
                    towerSpawn = Instantiate(towerSpawn);
                    towerSpawn.transform.SetParent(mid); // makes this true/false
                    towerSpawn.transform.position = mid.transform.position + new Vector3(0, towerSpawn.transform.position.y, 0);
                }

                if (hit.collider.CompareTag("T_Last"))
                {
                    print("last");
                    towerSpawn = Instantiate(towerSpawn);
                    towerSpawn.transform.SetParent(last); // makes this true/false
                    towerSpawn.transform.position = last.transform.position + new Vector3(0, towerSpawn.transform.position.y, 0);
                }
            }
        }
    }
}