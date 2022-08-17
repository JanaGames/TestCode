using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonOpenPanel : UIButton
{
    public GameObject panel;

    public override void OnClick() 
    {
        panel.SetActive(true);
    }
}
