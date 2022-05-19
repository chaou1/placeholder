using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{
    public Transform playerPosition;
    public Rigidbody2D rb;
    public float speed;
    public float minRadius;
    public float MaxRadius;
    public Vector2 distance = new Vector2();
    public float radiusDistance;
    private Vector2 playerPositionv = new Vector2();
    public Vector2 spawnPosition = new Vector2();
    private Vector2 distanceToSpawn;
    private Vector2 distanceToSpawnN;
    public bool idle = true;
    //public bool idleMovementokay=true;
    //public Vector2 randomNoise= new Vector2();

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

        if (radiusDistance < MaxRadius && radiusDistance > minRadius)
        {
            idle = false;
            targetingMovement();
        }
        else {
            //idleMovement();
        }
        if (radiusDistance > MaxRadius&& idle ==false)
        {
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
    //private void idleMovement() {

    //    if (idleMovementokay == true && idle ==true)
    //    {
    //        idleMovementokay = true;
    //        StartCoroutine(cooldownIdleMovement());
            
            
    //    }
    //    if (idle == true) { 
    //    }
    //}
    //IEnumerator cooldownIdleMovement()
    //{
    //    if (idleMovementokay == true) { 
    //    randomNoise.x = Random.Range(0, 2);
    //    randomNoise.y = Random.Range(0, 2);
    //        randomNoise.Normalize();
    //        rb.MovePosition(rb.position + randomNoise * speed / 2 * Time.deltaTime);
    //        yield return new WaitForSeconds(5f);
    //    idleMovementokay = false;
    //}
    //}


}

