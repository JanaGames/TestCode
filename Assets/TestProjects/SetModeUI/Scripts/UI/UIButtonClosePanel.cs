using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonClosePanel : UIButton
{
    public GameObject panel;

    public override void OnClick() 
    {
        panel.SetActive(false);
    }
}
