using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketButton : TradeSlot
{
    public override void LoadTradeSlot(ScriptableItem item, int id) 
    {
        nameText.text = item.nameItem;
        typeText.text = item.type.ToString();
    }
}
