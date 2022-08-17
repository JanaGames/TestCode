using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingWindow : MonoBehaviour
{
    public Image imageLoading;

    public static UILoadingWindow instance;

    public static UILoadingWindow Instance 
    {
        get 
        {
            return instance;
        }
        private set {}
    }

    private void Start() {
        instance = this;
        StartCoroutine("LoadingProcess");
    }
    //call between scenes
    //or start game
    public void StartLoadingWindow() 
    {
        StartCoroutine("LoadingProcess");
    }

    IEnumerator LoadingProcess() 
    {
        while(true) 
        {
            yield return new WaitForSeconds(0.1f);
            imageLoading.fillAmount -= 0.01f;

            if (imageLoading.fillAmount == 0) EndLoading();
        }
    }

    public void EndLoading() 
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
