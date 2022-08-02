using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeBasket
{
    //delete from player
    public List<int> itemsForSell = new List<int>();
    //add to player
    public List<int> itemsForBuy = new List<int>();
}
public class UITradeWindow : MonoBehaviour
{
    public GameObject panel;
    public Transform SellContent;
    public Transform BuyContent;

    public Transform SellContentBasket;
    public Transform BuyContentBasket;

    public GameObject prefubSellSlot;
    public GameObject prefubBuySlot;
    public GameObject prefubBasketSlot;

    public Agent player;
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

    void Awake() { instance = this; }

    private void Start() {
        FirstLoadTradeWindow(tradeAgent);
    }
    //
    public void FirstLoadTradeWindow(Agent tradeAgent) 
    {
        this.tradeAgent = tradeAgent;
        LoadTradeWindow();
    }
    //cancel button too
    public void LoadTradeWindow() 
    {
        TradeBasket = new TradeBasket();
        ClearContent(SellContent);
        ClearContent(BuyContent);
        ClearContent(SellContentBasket);
        ClearContent(BuyContentBasket);
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
        //if currency in tradeAgent
        AddSlot(SellContent.GetChild(id).GetComponent<TradeSlot>().thisItem, SellContentBasket, prefubBasketSlot);
        TradeBasket.itemsForSell.Add(id);
        DisableSlot(id, SellContent);
    }
    public void AddItemForBuy(int id) 
    {
        //if currency in player
        AddSlot(BuyContent.GetChild(id).GetComponent<TradeSlot>().thisItem, BuyContentBasket, prefubBasketSlot);
        TradeBasket.itemsForBuy.Add(id);
        DisableSlot(id, BuyContent);
    }

    public void TradePlay() 
    {
        for (int i = 0; i < TradeBasket.itemsForBuy.Count; i++) 
        {
            int id = TradeBasket.itemsForBuy[i];
            ScriptableItem item = tradeAgent.inventory.items[id];

            tradeAgent.inventory.DeleteItem(item.nameItem);
            player.inventory.AddItem(item);

            player.currency -= item.price;
            tradeAgent.currency += item.price;
        }
        for (int i = 0; i < TradeBasket.itemsForSell.Count; i++) 
        {
            int id = TradeBasket.itemsForSell[i];
            ScriptableItem item = player.inventory.items[id];

            player.inventory.DeleteItem(item.nameItem);
            tradeAgent.inventory.AddItem(item);

            player.currency += item.price;
            tradeAgent.currency -= item.price;
        }
        LoadTradeWindow();
    }
    void ClearContent(Transform parent) 
    {
        foreach (Transform child in parent) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
