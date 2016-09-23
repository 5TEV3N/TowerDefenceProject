using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
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
        }
    }
}
