using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//only this scene is needed to work
public class StartTrade : MonoBehaviour
{
    public Agent tradeAgent;

    public void OpenTradePanel() 
    {
        UITradeWindow.Instance.FirstLoadTradeWindow(tradeAgent);
        gameObject.SetActive(false);
    }
}
