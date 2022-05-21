using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
       
        
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
               // SetFocus(interactable);
                Debug.Log("Irgenwasddas: " + hit.collider.gameObject.transform);
            }
        }
        /*
        if (Input.GetMouseButtonDown(1))
        {Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {Debug.Log("tagsasga");}}
            /*
        if (Input.GetMouseButtonDown(1) ) {RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));
                {Interactable interactable = rayHit.transform.GetComponent<Interactable>();
                    if (interactable != null{RemoveFocus();}
                    //Debug.Log(rayHit.transform.tag);}}
            */
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Input.mousePosition));

          //  if(Physics2D.Raycast(Ray2D, out rayHit, 100))
            if (rayHit.transform.CompareTag("Collectable"))
            {
                
               Interactable interactable = rayHit.collider.GetComponent<Interactable>();
                if (rayHit != null)
                {
                    Debug.Log( "Fokus");
                    //SetFocus(interactable);
                }
                
               
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
      //  if (newFocus != focus)
       // {
        //    focus.DeFocused();
       // }
        focus = newFocus;
        //newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        //focus.DeFocused();
        focus = null;
    }
}

