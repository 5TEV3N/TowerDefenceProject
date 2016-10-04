using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    // If 3 drones hit the base, gameover!

    DroneController droneController;         // Reffernce to the DroneController

    public int baseHealth;                   // Health of the base

    public void GameOver()
    {
        baseHealth--;
        print("Base took a hit!");
        if (baseHealth <= 0)
        {
            print("GameOver, go to the Lose Scene");
        }
    }
}
