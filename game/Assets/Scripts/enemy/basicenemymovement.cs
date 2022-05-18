using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicenemymovement : MonoBehaviour
{
    public Transform playerposition;
    public Transform enemyposition;
    public Vector2 playerpositionv = new Vector2();
    public Vector2 enemypositionv = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attackmovement();
    }
    public void Attackmovement() {
        playerpositionv = playerposition.transform.position;
        enemypositionv = enemyposition.transform.position;


    }
   
}
