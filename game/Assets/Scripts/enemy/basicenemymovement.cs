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

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = rb.position;

    }

    // Update is called once per frame
    void Update()
    {
        positions();

    }
    private void FixedUpdate()
    {
        targetingMovement();
    }
    void positions() {
        playerPositionv = playerPosition.transform.position;
    }
    void targetingMovement() {
        //transform.position = Vector2.MoveTowards(enemypositionv, playerpositionv, speed * Time.deltaTime);
        //distanzvektor
        distance.x = playerPositionv.x - transform.position.x;
        distance.y = playerPositionv.y - transform.position.y;
        radiusDistance = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);
        distance.Normalize();
        //Bewegung
        if (radiusDistance < MaxRadius && radiusDistance > minRadius) {
            rb.MovePosition(rb.position + distance * speed * Time.deltaTime);

        }
        if (radiusDistance > MaxRadius) {
            returnToSpawn();
        }


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


}

