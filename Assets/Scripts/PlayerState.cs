using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    private float x;
    private float z;
    private Vector3 move;
    private Vector3 velocity;
    private bool isGrounded;
    private bool allowJump;
    private float baseSpeed;
    private float baseJumpHeight;
    

    public enum State
    {
        reset,
        real,
        dream,
        jumpnrun,
        torch
    }

    public State playerState;


    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;
        baseJumpHeight = jumpHeight;
    }

    // Update is called once per frame
    void Update()
    {

        switch (playerState)
        {
            case State.reset:
                speed = baseSpeed;
                jumpHeight = baseJumpHeight;
                allowJump = false;
                break;
            case State.real:
                break;
            case State.dream:
                speed = 24f;
                break;
            case State.jumpnrun:
                allowJump = true;
                break;
            case State.torch:
                jumpHeight = 12f;
                break;
            default:
                break;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && allowJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
