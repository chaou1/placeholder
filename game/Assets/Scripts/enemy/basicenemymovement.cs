using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{
    public Transform playerPosition;
    public Rigidbody2D rb;
    public float speed;

    public float MaxRadius;
    public Vector2 distance = new Vector2();
    public float radiusDistance;
    public bool playerInRange= false;
    private Vector2 playerPositionv = new Vector2();
    public Vector2 spawnPosition = new Vector2();
    private Vector2 distanceToSpawn;
    private Vector2 distanceToSpawnN;
    public bool idle = true;
    public bool idleCooldown = false;
    public Vector2 nullVector = new Vector2(1,1);
    private float random;



    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = rb.position;
    }


    private void FixedUpdate()
    {

        mainMovement();
    }

    public void mainMovement() {
        playerPositionv = playerPosition.transform.position;
        //distanzvektor
        distance.x = playerPositionv.x - transform.position.x;
        distance.y = playerPositionv.y - transform.position.y;
        radiusDistance = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);


        if (radiusDistance < MaxRadius)
        {
            idle = false;
            playerInRange = true;
            targetingMovement();
        }
        else {
            if (idle == true) { 
                idleMovement();
            } 
        }
        if (radiusDistance > MaxRadius&& idle ==false)
        {
            playerInRange = false;
            returnToSpawn();
            
        }


    }

    private void targetingMovement() {

        distance.Normalize();
        rb.MovePosition(rb.position + distance * speed * Time.deltaTime);


        //debug line
        Debug.DrawLine(transform.position, playerPositionv);

    }
    private void returnToSpawn()
    { distanceToSpawn = spawnPosition - rb.position;
        distanceToSpawnN = distanceToSpawn;
        distanceToSpawnN.Normalize();
        if (rb.position != spawnPosition) {
            rb.MovePosition(rb.position + distanceToSpawnN * speed * Time.deltaTime);
        }
        if (distanceToSpawn.magnitude < 0.1) {
            transform.position = spawnPosition;
            idle = true;
        }

    }
    private void idleMovement() {

        if (idleCooldown==false) { switch (Random.Range(1f, 3f)) {
                case 1: StartCoroutine(noise());
                    break;

            } 
        }
    }
    IEnumerator noise()
    {
        rb.MovePosition(rb.position + nullVector * Random.Range(-1f, 1f));
        idleCooldown = true;
        yield return new WaitForSeconds(Random.Range(3f,10f));
        idleCooldown = false;
    }
 


}

