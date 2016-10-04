using UnityEngine;
using System.Collections;

public class LoseCondition : MonoBehaviour
{
    // If 3 drones hit the base, gameover!

    DroneController droneController;         //Reffernce to the DroneController

    public GameObject GameOverText;
    public int damagedBase;                    // How many times the base got damaged


    public void GameOver()
    {
        damagedBase++;
        if (damagedBase == 5)
        {
            GameOverText.SetActive(true);
        }
    }
}
