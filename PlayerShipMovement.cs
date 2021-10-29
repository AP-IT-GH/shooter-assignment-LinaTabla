using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;

    Transform myT;

    void Awake()
    {
        myT = transform;
    }

    void Update()
    {
        Turn();
        Thrust();
    }

    // Go left or light
    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(-pitch, yaw, -roll);
    }

    // Go forwards or backwords
    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }
    }
}
