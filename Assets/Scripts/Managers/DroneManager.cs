using UnityEngine;
using System.Collections;

public class DroneManager : MonoBehaviour
{
    //This script spawns the drones. Manages the speed of the drones

    DroneController droneController;              // Refference to the DroneController

    [Header("Difficulty")]
    public int dronesKilled;                      // Counts how many drones are killed
    public int dronesRequired;                    // How much drones must be killed inorder to go faster
    public float speedIncrease;                   // How much drone's Health increases
    public float droneSpeed;                      // Speed of the drones

    [Header("Spawn")]
    public float spawnTime = 5f;                  // The amount of time between each spawn.
    public float spawnDelay = 3f;                 // The amount of time before spawning starts.

    public GameObject drones;                     // Drones that get spawned

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Update()
    {
        IncreasingDifficulty();
    }

    public void Spawn()
    {
        GameObject cloneSpawn = Instantiate(drones) as GameObject;  
        cloneSpawn.name = "Drone";
        cloneSpawn.transform.position = gameObject.transform.position + new Vector3 (0, cloneSpawn.transform.position.y,0);
    }

    public void KillCounter()
    {
        dronesKilled++;
        print("Drones Killed = " + dronesKilled);
    }

    public void IncreasingDifficulty()
    {
        if (dronesKilled == dronesRequired)
        {
            print("Reset Killed Counter. On to the next wave!");
            droneSpeed = droneSpeed + speedIncrease;
            spawnTime--;
            dronesKilled = 0;
        }
    }

}
