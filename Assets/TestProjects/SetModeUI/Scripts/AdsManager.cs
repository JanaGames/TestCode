using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    public bool isPlay;

    private InterstitialAd interstitial;
    private BannerView bannerView;
    private string appID, AdsVideoID, AdsBannerID;

    public static AdsManager instance;

    public static AdsManager Instance 
    {
        get 
        {
            return instance;
        }
        private set {}
    }

    private void Start() {
        instance = this;
        appID = "ca-app-pub-2857137893650029~7882704071";
        //AdsVideoID = "ca-app-pub-2857137893650029/9879237097";
        //AdsBannerID = "ca-app-pub-2857137893650029/6151745074";
        //test 712
        AdsVideoID = "ca-app-pub-2857137893650029/6004476506";
        //test banner
        AdsBannerID = "ca-app-pub-2857137893650029/5266109908";
        MobileAds.Initialize(initStatus => { });
        //MobileAds.Initialize(appID);
        RequestInterstitial();
        RequestBanner();
    }
    
    //puplic methods
    public void ShowInterstitial() 
    {
        if (interstitial.IsLoaded()) 
        {
            interstitial.Show();
            isPlay = true;
        }
    }
    public void DestroyInterstitial() 
    {
        interstitial.Destroy();
    }

    AdRequest adRequestBuild() 
    {
        return new AdRequest.Builder().Build();
    }
    private void RequestInterstitial() 
    {
        interstitial = new InterstitialAd(AdsVideoID);
        AdRequest request = adRequestBuild();
        interstitial.LoadAd(request);

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        this.interstitial.OnAdClosed += HandleOnAdClosed;
    }
    private void RequestBanner() 
    {
        bannerView = new BannerView(AdsBannerID, AdSize.Banner, AdPosition.Top);
        AdRequest request = adRequestBuild();
        bannerView.LoadAd(request);
    }
    public void DestroyBanner() 
    {
        if (bannerView != null) bannerView.Destroy();
    }
    private void OnDestroy() 
    {
        DestroyInterstitial();

        this.interstitial.OnAdLoaded -= HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening -= HandleOnAdOpened;
        this.interstitial.OnAdClosed -= HandleOnAdClosed;
    }
    public void HandleOnAdLoaded(object sender, EventArgs args) 
    {

    }
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) 
    {

    }
    public void HandleOnAdOpened(object sender, EventArgs args) 
    {

    }
    public void HandleOnAdClosed(object sender, EventArgs args) 
    {
        this.interstitial.OnAdLoaded -= HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening -= HandleOnAdOpened;
        this.interstitial.OnAdClosed -= HandleOnAdClosed;

        isPlay = false;

        RequestInterstitial();
    }
}
