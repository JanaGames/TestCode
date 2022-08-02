using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : TradeSlot
{
    public void AddItemForSell() 
    {
        UITradeWindow.Instance.AddItemForSell(id);
    }
}
