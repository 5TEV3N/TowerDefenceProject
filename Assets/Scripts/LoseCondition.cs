using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseCondition : MonoBehaviour
{
    BaseManager baseManagement;                    // Refference to the BaseManagement
    TowerSpawnerManager towerSpawnerManager;       // Refference to the TowerSpawnerManager
                   
    public GameObject GameOverUi;                  // Refference to the GameoverUI. By default it's inactive > Enable it
    public int BaseHP;                             // Hp of base
    public Text HP;                                 // Reference to the Text Hp component.

    void Awake()
    {
        baseManagement = GameObject.FindGameObjectWithTag("T_Base").GetComponent<BaseManager>();
        towerSpawnerManager = GameObject.FindGameObjectWithTag("T_TowerSpawnerManager").GetComponent<TowerSpawnerManager>();
    }

    void Update()
    {
        HP.text = "BASE HEALTH : " + BaseHP;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (BaseHP != 0)
        {
            BaseHP--;
            print("sdfg");
        }
    }

    public void GameOver()
    {
        if (BaseHP <= 0)
        {
            baseManagement.isBaseAlive = false;

            GameOverUi.SetActive(true);

            towerSpawnerManager.canSpawnFirst = false;
            towerSpawnerManager.canSpawnMid = false;
            towerSpawnerManager.canSpawnLast = false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
