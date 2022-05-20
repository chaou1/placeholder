using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collectable Object", menuName = "Inventory System/Items/Collectable")]

public class CollectableObject : ItemObject
{
    public float bonus;
    public void Awake()
    {
        type = ItemType.collectable;
    }
}
