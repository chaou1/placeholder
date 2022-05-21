using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itempickup : Interactable
{
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Pickcingup item");
        Destroy(gameObject);
    }
}
