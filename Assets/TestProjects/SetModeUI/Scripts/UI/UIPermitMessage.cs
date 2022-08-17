using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPermitMessage : MonoBehaviour
{
    public GameObject panel;

    public TMP_Text textField;

    public UIButtonOpenPanel button;

    public static UIPermitMessage instance;

    public static UIPermitMessage Instance 
    {
        get 
        {
            return instance;
        }
        private set {}
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void LoadMessage(string textField, GameObject panel, bool showAdvertising = false) 
    {
        this.panel.SetActive(true);
        this.textField.text = textField;
        //set panel who need open
        button.panel = panel;
        button.showAdvertising = showAdvertising;
    }
}
