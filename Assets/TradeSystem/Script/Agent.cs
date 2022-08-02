using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public List<ScriptableItem> items;
    public Inventory inventory;
    public int currency;

    public void Start() {
        inventory = new Inventory();
        inventory.items = items;
    }
}
