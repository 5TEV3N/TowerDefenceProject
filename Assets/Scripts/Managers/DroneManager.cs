using UnityEngine;
using System.Collections;

public class DroneManager : MonoBehaviour
{
    //This script spawns the drones. Manages the speed of the drones

    DroneController droneController;              // Refference to the DroneController

    public bool ifDroneisInScene = false;         // Checks if drones are in the scene. Then, get the reffrence of the DroneController
    public int dronesKilled;                      // Counts how many drones are killed
    public float spawnTime = 5f;                  // The amount of time between each spawn.
    public float spawnDelay = 3f;                 // The amount of time before spawning starts.
    public GameObject drones;                     // Drones that get spawned
    
    void Awake()
    {

    }

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Update()
    {
        if (ifDroneisInScene == true)
        {
            droneController = GameObject.FindGameObjectWithTag("T_Drones").GetComponent<DroneController>();
        }

        IncreasingDifficulty();
    }

    public void Spawn()
    {
        drones = Instantiate(drones) as GameObject;
        drones.transform.position = gameObject.transform.position + new Vector3 (0, drones.transform.position.y,0);
    }

    public void KillCounter()
    {
        dronesKilled++;
        print("Drones Killed = " + dronesKilled);
    }

    public void IncreasingDifficulty()
    {
        if (dronesKilled == 2)
        {
            print("Reset Killed Counter. On to the next wave!");
            dronesKilled = 0;
            droneController.SpeedUp();
        }
    }

}
