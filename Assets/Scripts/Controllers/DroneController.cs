using UnityEngine;
using System.Collections;

public class DroneController : MonoBehaviour
{
    public Rigidbody rb; //Gets obj's rigidbody
    public float droneSpeedX; //float val of the drone's speed
    public float droneSpeedY;
    public float droneSpeedZ;

    void FixedUpdate()
    {
        rb.AddForce(droneSpeedX, droneSpeedY, droneSpeedZ);
    }
}
