using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TypeItem { Food, Weapon }
[CreateAssetMenu(fileName = "ScriptableItem", menuName = "Scriptable/ScriptableItem", order = 0)]
public class ScriptableItem : ScriptableObject 
{
    public string nameItem;
    public Sprite icon;
    public TypeItem type;
    //drop item
    public GameObject thisItem;
    //middle price +-bonus (level of traiding, level of relation with agent)
    //curent price
    public int price;
}
