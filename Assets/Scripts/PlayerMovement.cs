using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    float wSpeed = 10f;
    float wallJumpSpeed = 0f;
    float jumpSpeed = 3f;
    bool canDoubleJump = true;
    float gravity = -19.81f;

    float x = 0;
    float z = 0;

    Vector3 move;
    Vector3 velocity;
    public Transform groundCheck;
    public Transform wallLeftCheck;
    public Transform wallRightCheck;

    float groundDistance = .3f;
    float wallDistance = .3f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isWallLeft;
    bool isWallRight;

    //Draw Gizmos for walljump debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(wallLeftCheck.position, wallDistance);
        Gizmos.DrawSphere(wallRightCheck.position, wallDistance);
    }

    void Update()
    {
        //Ground and wall check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isWallLeft = Physics.CheckSphere(wallLeftCheck.position, wallDistance, groundMask);
        isWallRight = Physics.CheckSphere(wallRightCheck.position, wallDistance, groundMask);

        // If we're standing on the ground
        if (isGrounded && velocity.y < 0)
        {
            wallJumpSpeed = 0f;
            velocity.y = -2;
            canDoubleJump = true;

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
            move = transform.right * x + transform.forward * z;
        }

        //Movement in 4 directions
        Vector3 wallJumpMove = transform.right * wallJumpSpeed;
        controller.Move((wallJumpMove + (move * speed)) * Time.deltaTime);

        // Jumping on ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        }

        // Walljump when wall is on the left
        if (Input.GetButtonDown("Jump") && isWallLeft && isGrounded == false)
        {
            WallJumpLeft();
        }

        //Walljump when wall is on the right
        if (Input.GetButtonDown("Jump") && isWallRight && isGrounded == false)
        {
            WallJumpRight();
        }

        // DoubleJump
        if (Input.GetButtonDown("Jump") && isGrounded == false && canDoubleJump == true)
        {
            DoubleJump();
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -20f)
        {
            OutOfBounds();
        }

        // Closes the application upon pressing the escape button
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }


    void DoubleJump()
    {
        velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        canDoubleJump = false;
    }

    void WallJumpLeft()
    {
        canDoubleJump = false;
        velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        x = 0;
        wallJumpSpeed = wSpeed;
    }

    void WallJumpRight ()
    {
        canDoubleJump = false;
        velocity.y = Mathf.Sqrt(jumpSpeed * -2f * gravity);
        x = 0;
        wallJumpSpeed = -wSpeed;
    }


    // Reset position if player walks off the map
    void OutOfBounds ()
    {
        controller.enabled = false;
        transform.position = new Vector3(0, 0, 0);
        controller.enabled = true;
    }
}
