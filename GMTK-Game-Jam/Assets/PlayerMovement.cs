using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HandController controller;
    public float speed = 40.0f;
    public float rotationSpeed = 40.0f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    float torque = 0f;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        verticalMove = Input.GetAxisRaw("Vertical") * speed;
        bool right = false;
        bool left = false;
        if (right = Input.GetButton("RotateRight"))
            torque = -1.0f;
        if (left = Input.GetButton("RotateLeft"))
            torque = 1.0f;
        torque = right ^ left ? torque : 0.0f;
        torque *= rotationSpeed;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, torque * Time.fixedDeltaTime);
        torque = 0.0f;
    }
}
