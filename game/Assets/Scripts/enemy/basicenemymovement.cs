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
    private Vector2 spawnPosition = new Vector2();
    private Vector2 distanceToSpawn;
    private Vector2 distanceToSpawnN;
    private bool idle = true;
    public Vector2 randomNoise;

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
            idle = true;
        }
        if (radiusDistance > MaxRadius)
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
        }

    }
    private void idleMovement() {

        while (idle == true)
        {
            StartCoroutine(cooldownIdleMovement());
            rb.position = spawnPosition;
        }

    }
    IEnumerator cooldownIdleMovement()
    {

        yield return new WaitForSeconds(Random.Range(5f,13f));
        randomNoise.x = Random.Range(0, 3);
        randomNoise.y = Random.Range(0, 3);
        rb.MovePosition(rb.position + randomNoise * speed * Time.deltaTime);

    }


}

