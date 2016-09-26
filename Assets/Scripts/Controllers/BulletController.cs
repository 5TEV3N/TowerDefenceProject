using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    //This scripts deletes the bullet after x amount of time

    public float timeBeforeDeath;
    public float intialTime;

    void Start()
    {
        intialTime = Time.time;
    }

    void Update()
    {
        if (Time.time > intialTime + timeBeforeDeath)
        {
            Destroy(gameObject);
            return;
        }
    }
}
