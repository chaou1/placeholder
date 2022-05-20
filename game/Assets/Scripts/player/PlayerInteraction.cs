using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable focus;
    public InventoryObject inventory;   
    public bool inContact;
    Camera cam;
    collectable collectable; 
   
    void Start()
    {
        cam = Camera.main; 
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) ) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));

            if (rayHit.transform.CompareTag("Collectable"))
            {
                Interactable interactable = rayHit.transform.GetComponent<Interactable>();
                if (interactable != null)
                {
                    RemoveFocus();
                }
                //Debug.Log(rayHit.transform.tag);
               
            }

        }
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform.CompareTag("Collectable"))
            {
                Interactable interactable = rayHit.transform.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                //Debug.Log(rayHit.transform.tag);
               
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
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            focus.DeFocused();
        }
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        focus.DeFocused();
        focus = null;
    }
}

