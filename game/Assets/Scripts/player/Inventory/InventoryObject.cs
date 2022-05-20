using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    // Start is called before the first frame update
    public List<InventorySlot> Container = new List<InventorySlot>(); //liste wird erstellt
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasitem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item== _item) //wenn ein item schon vorhanden ist soll es nur noch die Anzahl/Menge (_amount) hinzugefügt werden
            {
                Container[i].AddAmount(_amount);
                hasitem = true;
                break;
                
            }
        }
        if (!hasitem) //wenn das item nicht schon vorhanden ist, dann soll es vollständig hinzugefügt werden (_item + _amount)
        {
            Container.Add(new InventorySlot(_item, _amount)); 
        }
    }

}
[System.Serializable]
public class InventorySlot 
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount) //zum vollständigen hinzufügen
    {

        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value) //Zum hinzufügen der Menge
    {
        amount += value;
    }

}

