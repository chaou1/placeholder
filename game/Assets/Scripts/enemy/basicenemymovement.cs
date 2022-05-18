using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{
    public Transform playerposition;
    public Transform enemyposition;
    public Vector2 playerpositionv = new Vector2();
    public Vector2 enemypositionv = new Vector2();
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
        BasicMovement();
    }
     void positions() {
        playerpositionv = playerposition.transform.position;
        enemypositionv = enemyposition.transform.position;
    }
    void BasicMovement() {
        distance.x = playerpositionv.x - enemypositionv.x;
        distance.y = playerpositionv.y - enemypositionv.y;
        test = Mathf.Sqrt(distance.x * distance.x + distance.y * distance.y);

    

    }

}
