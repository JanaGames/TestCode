using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

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
        StartLoadingWindow();
    }
    //call between scenes
    //or start game
    public async void StartLoadingWindow() 
    {
        while(true) 
        {
            await Task.Delay(50);
            slider.value += 0.01f;

            if (slider.value == 1) EndLoading();
        }
    }

    public void EndLoading() 
    {
        gameObject.SetActive(false);
    }
}
