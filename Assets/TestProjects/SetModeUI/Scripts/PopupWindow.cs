using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindow : EditWindow
{
    [Range(0f, 1f)]
    public float timePopup = 0.5f;

    public override void Load() 
    {
        transform.localScale = Vector2.zero;
    }
    public override void Open() 
    {
        transform.LeanScale(Vector2.one, timePopup);
    }
    public override void Close() 
    {
        //transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
        transform.localScale = Vector2.zero;
    }
}
