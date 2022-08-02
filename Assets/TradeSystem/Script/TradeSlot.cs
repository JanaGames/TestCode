using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeSlot : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text typeText;
    public TMP_Text priceText;
    public ScriptableItem thisItem;
    public int id;

    public void LoadTradeSlot(ScriptableItem item, int id) 
    {
        nameText.text = item.nameItem;
        typeText.text = item.type.ToString();
        priceText.text = item.price.ToString();
        thisItem = item;
        this.id = id;
    }
}
