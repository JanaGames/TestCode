using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMessagePanel : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text textField;

    public static UIMessagePanel instance;

    public static UIMessagePanel Instance 
    {
        get 
        {
            if (instance == null) Debug.Log("UIMessagePanel is null");
            return instance;
        }
    }

    void Start() 
    {
        instance = this;
        panel.SetActive(false);
    }

    public void CreateMessage(string text) 
    {
        panel.SetActive(true);
        textField.text = text;
    }
    //press "OK"
    public void CloseMessageWindow() 
    {
        panel.SetActive(false);
    }
}
