using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    //fields for test only
    public List<ScriptableItem> items;
    public int currency;

    public Inventory inventory;

    public void Start() {
        //save load from SQLite
        inventory = new Inventory();
        inventory.items = items;
        inventory.currency = currency;
    }
}
