using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class ADMob : MonoBehaviour {
    public BannerView bannerView = null;
    // Use this for initialization
    void Start()
    {
        //Request Ads
        RequestBanner();
    }

    

    private void RequestBanner()
    {
       
#if UNITY_EDITOR
    string adUnitId = "ca-app-pub-3940256099942544/3347511713";
#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-3258719729962257/7673417255";
#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
		string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the bottom of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

        // prepara o listener para quando o banner estiver completamente
        bannerView.OnAdLoaded += OnAdLoadedBanner;
    }
    // exibe o banner
    public void OnAdLoadedBanner(object sender, EventArgs args)
    {
        this.bannerView.Show();
    }
}
