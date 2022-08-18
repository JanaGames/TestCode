using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingWindow : MonoBehaviour
{
    public Slider slider;

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
            yield return new WaitForSeconds(0.05f);
            slider.value += 0.01f;

            if (slider.value == 1) EndLoading();
        }
    }

    public void EndLoading() 
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
    }
}
