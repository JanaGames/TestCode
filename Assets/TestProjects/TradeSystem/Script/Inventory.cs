using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<ScriptableItem> items;
    public int currency;

    public bool GetPermitForBuy(int price) 
    {
        return (currency-price) >= 0;
    }

    public void DeleteItem(string deletedItem) 
    {
        for (int i = 0; i < items.Count; i++) 
        {
            if (items[i].nameItem == deletedItem) items.RemoveAt(i);
        }
    }
    public void AddItem(ScriptableItem item) 
    {
        items.Add(item);
    }
}
