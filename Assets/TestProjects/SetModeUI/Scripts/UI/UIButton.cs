using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public bool interactable = true;

    public bool showAdvertising;

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (showAdvertising) ShowAdvertising();
        if (interactable) OnClick();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (interactable) OnEnter();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactable) OnExit();
    }

    public virtual void OnClick() {}
    public virtual void OnEnter() {}
    public virtual void OnExit() {}

    void ShowAdvertising() 
    {
        AdsManager.Instance.ShowInterstitial();
    }
}
