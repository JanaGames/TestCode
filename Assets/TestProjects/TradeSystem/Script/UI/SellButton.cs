using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : TradeSlot
{
    public override void LoadTradeSlot(ScriptableItem item, int id) 
    {
        base.LoadTradeSlot(item, id);
        priceText.text = UITradeWindow.Instance.GetPriceItemFromInvetoryOfPlayer(thisItem).ToString();
    }
    public void AddItemForSell() 
    {
        UITradeWindow.Instance.AddItemForSell(id);
    }
}
