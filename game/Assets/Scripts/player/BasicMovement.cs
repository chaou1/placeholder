using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float dashDistance;
    public bool dashCooldown = false;
    public float moveSpeed;
    public float normalSpeed;
    public float sprintSpeed;
    public Vector2 movement;
    public Rigidbody2D rb;
    public Transform playerPosition;
    bool walkingRight;
    bool walkingUp;
    public enum movementState {dash}
    // Start is called before the first frame update
    void start() { }

    private void FixedUpdate()
    {
        Moving();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && dashCooldown == false )
        {
            StartCoroutine(dash()); 
        }
    }
    IEnumerator dash() 
    {
        playerPosition.position += new Vector3(movement.x*dashDistance, movement.y * dashDistance, 0);
        dashCooldown = true;
        yield return new WaitForSeconds(3f);
        dashCooldown = false;
    }
    //MOVING
    public void Moving()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            //Diagonal movement
            switch (Input.GetAxis("Fire1"))
            {
                case 1:
                    moveSpeed = sprintSpeed / 1.414f;
                    break;
                case 0:
                    moveSpeed = normalSpeed / 1.414f;
                    break;
            }
        }
        //
        else
        {
            switch (Input.GetAxis("Fire1"))
            {
                case 1:
                    moveSpeed = sprintSpeed;
                    break;
                case 0:
                    moveSpeed = normalSpeed;
                    break;
            }
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


    }

}
