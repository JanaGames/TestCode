using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonExitGame : UIButton
{
    public virtual void OnClick() 
    {
        //save
        Application.Quit();
    }
}
