using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public bool inContact;

    Camera cam;
    collectable collectable; 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Vector3 mousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) ) {

            print("itemas");   
            
        }if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform.CompareTag("Collectable") )
            {
                Debug.Log(rayHit.transform.tag);
                inContact = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable") && inContact == true )
        {
            print("ItemCollected");
            Destroy(obj: collectable );

        }
        else
        {  }
    }
}

