using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{   
    public Transform collectablepostition;
    public Transform playerposition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(playerposition.position.x < collectablepostition.position.x) {
            print("KONFLIKT!!!!!");
        }
        */
        collectablepostition.position += new Vector3(0.005f, 0, 0);
      
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player" )) {
            print("KONFLIKT!!!!!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            print("KONFLIKT!!!!!");
        }

    }

}
