using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public ThirdPersonAnimations animations;

    public float speed = 6f;
    public float runSpeed = 10f;

    public float gravity = -9.8f;
    public float jumpHeight = 1f;  // Height of the jump

    public Transform cam;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;  // Store vertical velocity

    void Awake()
    {
        animations = GetComponent<ThirdPersonAnimations>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        // Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Reset velocity when grounded
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            if (isRunning)
            {
                controller.Move(moveDir * runSpeed * Time.deltaTime);
                animations.Running(true);
                animations.Walk(false);
            }
            else
            {
                controller.Move(moveDir * speed * Time.deltaTime);
                animations.Walk(true);
                animations.Running(false);
            }
        }
        else
        {
            animations.Walk(false);
            animations.Running(false);
        }

        // Jump
        if (isJumping && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity); // Calculate upward velocity for the jump
            animations.Jump();
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime * 2f;
        controller.Move(velocity * Time.deltaTime); // Move the player vertically
    }
}