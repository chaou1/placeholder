using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{
    public Transform playerPosition;

    public Rigidbody2D rb;
    public float speed;
    private Vector2 playerPositionv = new Vector2();
   

    public Vector2 distance = new Vector2();
    public float test;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       positions();
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
        distance.Normalize();
        //Bewegung
        rb.MovePosition(rb.position + distance * speed * Time.deltaTime);

        //debug line
        Debug.DrawLine(transform.position, playerPositionv);
        

    

    }

}
