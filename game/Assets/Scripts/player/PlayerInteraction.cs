using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public InventoryObject inventory;
    
    
    public bool inContact;
    Camera cam;
    collectable collectable; 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) ) {

            
              
            
        }if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform.CompareTag("Collectable"))
            {
                Debug.Log(rayHit.transform.tag);
                inContact = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)  //other.GetComponent<Item>() auch möglich  other.CompareTag("Collectable")
        {
            inventory.AddItem(item.item, 1);
            Debug.Log(item.name);
            Destroy(other.gameObject);
        }
    }

}

