using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLoadMessage : UIButton
{
    public string textField;
    //if confirmable
    //set panel who need open later
    public GameObject nextPanel;

    public override void OnClick() 
    {
        UIPermitMessage.Instance.LoadMessage(textField, nextPanel, true);
    }
}
