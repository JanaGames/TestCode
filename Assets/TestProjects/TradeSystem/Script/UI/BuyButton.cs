using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : TradeSlot
{
    public void AddItemForBuy() 
    {
        UITradeWindow.Instance.AddItemForBuy(id);
    }
}
