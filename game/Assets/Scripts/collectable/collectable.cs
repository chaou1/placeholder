using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    //PlayerInteraction playerinteraction;

   // 
    int x = 0;
    float y = 0.005f;
    public Transform collectablepostition;
    public Transform playerposition;
   //public  Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        collectablepostition.position += new Vector3(y, 0, 0);
        x++;
        if (x == 100) {
            y = -y;
            x = 0;
        }


       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            Destroy(obj: gameObject);
        }
    }


}
