using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayeMovement : MonoBehaviour
{   
    public float speed = 5f;
    public float horizontal_move;
    public float vertical_move;
    private CharacterController player;

    private Vector3 playerInput;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallSpeed;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal_move = Input.GetAxis("Horizontal");
        vertical_move = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontal_move,0f,vertical_move);
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer *= speed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        player.Move(movePlayer * Time.deltaTime);

        if(Input.GetKeyDown("q")){
            Debug.Log("Phone On");
        }
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;    

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallSpeed = -gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
        else
        {
            fallSpeed -= gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
    }
    
}
