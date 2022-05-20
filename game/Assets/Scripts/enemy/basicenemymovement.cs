using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{  //basicpositions
    public Transform playerPosition;
    public Rigidbody2D rb;
    //speed of the enemy
    public float speed;
    //range of the 
    public float MaxRadius;
    private Vector2 distance = new Vector2();
    public float radiusDistance;
    public bool playerInRange= false;
    public Vector2 spawnPosition = new Vector2();
    private Vector2 distanceToSpawn;
    private Vector2 distanceToSpawnN;
    private bool idle = true;
    private bool idleCooldown = false;
    private bool canPerform = false;
    public float HowLittleIdle;
    public Vector2 random;



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

        //distanzvektor
        distance.x = playerPosition.position.x - transform.position.x;
        distance.y = playerPosition.position.y - transform.position.y;
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
        Debug.DrawLine(transform.position, playerPosition.position);

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

        if (idleCooldown == false) { 
            switch (Random.Range(1,HowLittleIdle)) {
                case 1:
                    StartCoroutine(noise());
                    break;
                default:
                    StartCoroutine(nothing());
                    break;
            }
        }
        if (canPerform==true) {
            rb.MovePosition(rb.position + random * speed * Time.deltaTime);
        } 
    
    }
    IEnumerator noise()
    {
        random.x = Random.Range(-5f, 5f);
        random.y = Random.Range(-5f, 5f);
        random.Normalize();
        canPerform = true;
        idleCooldown = true;
        yield return new WaitForSeconds(Random.Range(0f,1f));
        idleCooldown = false;
        canPerform = false;
    }
    IEnumerator nothing() {
        idleCooldown = true;
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        idleCooldown = false;
    }
 


}

