using UnityEngine;
using System.Collections;

public class TowerSpawnerManager : MonoBehaviour
{
    //When the spawners are clicked on, spawn a tower. BUT player must have the sufficient resources

    public Transform first;             // Position of first tower spawner
    public Transform mid;               // Position of mid tower spawner
    public Transform last;              // Position of last tower spawner

    public bool canSpawnFirst;          // If tower is placed on the first spawner = don't spawn
    public bool canSpawnMid;            // If tower is placed on the mid spawner = don't spawn
    public bool canSpawnLast;           // If tower is placed on the last spawner = don't spawn

    private RaycastHit hit;             // Gets info from the raycast
    private Ray ray;                    // Ray that gathers info
    private Vector3 rayOrigin;          // Position of ray 
    private GameObject towerSpawn;      // Receives tower prefab

    void Awake()
    {
        //Get the refference of the base to see how much points the player can spend 
    }

    void Update()
    {
        rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, 1000f);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("T_First"))
                {
                    if (canSpawnFirst == true)
                    {
                        print("Tower Spawned in the First Marker");
                        towerSpawn = Instantiate(Resources.Load("TowerFirst")) as GameObject;
                        towerSpawn.transform.SetParent(first);
                        towerSpawn.transform.position = first.transform.position + new Vector3(0, towerSpawn.transform.position.y, 0);
                        canSpawnFirst = false;

                    }
                    else
                    {
                        print("A Tower is already placed here!");
                    }
                }

                if (hit.collider.CompareTag("T_Mid"))
                {
                    if (canSpawnMid == true)
                    {
                        print("Tower Spawned in the Mid Marker");
                        towerSpawn = Instantiate(Resources.Load("TowerMid")) as GameObject;
                        towerSpawn.transform.SetParent(mid);
                        towerSpawn.transform.position = mid.transform.position + new Vector3(0, towerSpawn.transform.position.y, 0);
                        canSpawnMid = false;
                    }

                    else
                    {
                        print("A Tower is already placed here!");
                    }
                }

                if (hit.collider.CompareTag("T_Last"))
                {
                    if (canSpawnLast == true)
                    {
                        print("Tower Spawned in the Last Marker");
                        towerSpawn = Instantiate(Resources.Load("TowerLast")) as GameObject;
                        towerSpawn.transform.SetParent(last);
                        towerSpawn.transform.position = last.transform.position + new Vector3(0, towerSpawn.transform.position.y, 0);
                        canSpawnLast = false;
                    }
                    else
                    {
                        print("A Tower is already placed here!");
                    }
                }
            }
        }
    }

}