using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeBasket
{
    //delete from player
    public List<ScriptableItem> itemsForSell = new List<ScriptableItem>();
    //add to player
    public List<ScriptableItem> itemsForBuy = new List<ScriptableItem>();
}
public class UITradeWindow : MonoBehaviour
{
    public GameObject panel;
    public Transform SellContent;
    public Transform BuyContent;

    public Transform SellContentBasket;
    public Transform BuyContentBasket;

    public TMP_Text currencyPlayerText;
    public TMP_Text currencyAgentText;

    public TMP_Text currencyBuyText;
    public TMP_Text currencySellText;

    public GameObject prefubSellSlot;
    public GameObject prefubBuySlot;
    public GameObject prefubBasketSlot;
    [HideInInspector]
    public Agent player;
    [HideInInspector]
    public Agent tradeAgent;

    TradeBasket TradeBasket;

    public static UITradeWindow instance;
    public static UITradeWindow Instance 
    {
        get 
        {
            if (instance == null) Debug.LogError("UITradeWindow is null");
            return instance;
        }
    }

    private void Start() {
        instance = this;
        TradeBasket = new TradeBasket();
    }
    //call for start trade
    public void FirstLoadTradeWindow(Agent tradeAgent) 
    {
        this.tradeAgent = tradeAgent;
        LoadTradeWindow();
    }
    //call for reload or press cancel button
    public void LoadTradeWindow() 
    {
        panel.SetActive(true);

        //set info about currency
        currencyPlayerText.text = player.inventory.currency.ToString();
        currencyAgentText.text = tradeAgent.inventory.currency.ToString();

        //clear all
        currencySellText.text = "0";
        currencyBuyText.text = "0";
        TradeBasket = new TradeBasket();
        ClearContent(SellContent);
        ClearContent(BuyContent);
        ClearContent(SellContentBasket);
        ClearContent(BuyContentBasket);

        //load panels
        LoadPanel(tradeAgent.inventory, BuyContent, prefubBuySlot);
        LoadPanel(player.inventory, SellContent, prefubSellSlot);
    }
    void LoadPanel(Inventory inventory, Transform content, GameObject prefubSlot) 
    {
        for (int i = 0; i < inventory.items.Count; i++) 
        {
            AddSlot(inventory.items[i], content, prefubSlot, i);
        }
    }
    void AddSlot(ScriptableItem item, Transform content, GameObject prefubSlot, int id=0) 
    {
        GameObject slot = Instantiate(prefubSlot);
        slot.GetComponent<TradeSlot>().LoadTradeSlot(item, id);
        slot.transform.SetParent(content);
    }
    void DisableSlot(int id, Transform content) 
    {
        content.GetChild(id).GetComponent<Button>().interactable = false;
    }
    public void AddItemForSell(int id) 
    {
        ScriptableItem item = SellContent.GetChild(id).GetComponent<TradeSlot>().thisItem;

        //Add if there is money
        int differencePrice = GetSellValue() - GetBuyValue();
        if (!tradeAgent.inventory.GetPermitForBuy(differencePrice + item.price)) 
        {
            //message window
            return;
        }

        AddSlot(item, SellContentBasket, prefubBasketSlot);
        TradeBasket.itemsForSell.Add(item);
        DisableSlot(id, SellContent);
        currencySellText.text = GetSellValue().ToString();
    }
    public void AddItemForBuy(int id) 
    {
        ScriptableItem item = BuyContent.GetChild(id).GetComponent<TradeSlot>().thisItem;

        //Add if there is money
        int differencePrice = GetBuyValue() - GetSellValue();
        if (!player.inventory.GetPermitForBuy(differencePrice + item.price)) 
        {
            //message window
            return;
        }

        AddSlot(item, BuyContentBasket, prefubBasketSlot);
        TradeBasket.itemsForBuy.Add(item);
        DisableSlot(id, BuyContent);
        currencyBuyText.text = GetBuyValue().ToString();
    }

    public void TradePlay() 
    {
        for (int i = 0; i < TradeBasket.itemsForBuy.Count; i++) 
        {
            //int id = TradeBasket.itemsForBuy[i];
            //ScriptableItem item = tradeAgent.inventory.items[id];
            ScriptableItem item = TradeBasket.itemsForBuy[i];

            //update currency
            player.inventory.currency -= item.price;
            tradeAgent.inventory.currency += item.price;

            tradeAgent.inventory.DeleteItem(item.nameItem);
            player.inventory.AddItem(item);
        }
        for (int i = 0; i < TradeBasket.itemsForSell.Count; i++) 
        {
            ScriptableItem item = TradeBasket.itemsForSell[i];

            //update currency
            player.inventory.currency += GetPriceItemFromInvetoryOfPlayer(item);
            tradeAgent.inventory.currency -= item.price;

            player.inventory.DeleteItem(item.nameItem);
            tradeAgent.inventory.AddItem(item);
        }
        //update window with new inventory
        LoadTradeWindow();
    }
    int GetBuyValue() 
    {
        int priceAllItems = 0;
        for (int i = 0; i < TradeBasket.itemsForBuy.Count; i++) priceAllItems += TradeBasket.itemsForBuy[i].price;
        return priceAllItems;
    }
    int GetSellValue() 
    {
        int priceAllItems = 0;
        for (int i = 0; i < TradeBasket.itemsForSell.Count; i++) priceAllItems += GetPriceItemFromInvetoryOfPlayer(TradeBasket.itemsForSell[i]);
        return priceAllItems;
    }
    void ClearContent(Transform parent) 
    {
        foreach (Transform child in parent) {
            GameObject.Destroy(child.gameObject);
        }
    }
    //call from button script too
    public int GetPriceItemFromInvetoryOfPlayer(ScriptableItem item) 
    {
        return (int)(item.price - ((item.price*20)/100));
    }
}
