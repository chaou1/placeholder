using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey("i")) {
            //openInventory
            Inventory.SetActive(false);
        }
        if (Input.GetKey("o"))
        {
            //openInventory
            Inventory.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
