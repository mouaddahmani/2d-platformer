using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    private BannerView bannerView;
	private InterstitialAd interstitial;
    public static Admob instens { get; set; }
    private void Awake()
    {
        if(instens == null)
        {
            instens = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        string App_ID = "ca-app-pub-4678651658042635~6825149957";
        MobileAds.Initialize(App_ID);
        RequestBanner();
		RequestInterstitial();
        
    }

    public void RequestBanner()
    {
        #if UNITY_ANDROID
              string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
              string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
              string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
	
private void RequestInterstitial()
{
    #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
        string adUnitId = "unexpected_platform";
    #endif
//
     // Initialize an InterstitialAd.
    this.interstitial = new InterstitialAd(adUnitId);

    // Called when an ad request has successfully loaded.
    this.interstitial.OnAdLoaded += HandleOnAdLoaded;
    // Called when an ad request failed to load.
    this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
    // Called when an ad is shown.
    this.interstitial.OnAdOpening += HandleOnAdOpened;
    // Called when the ad is closed.
    this.interstitial.OnAdClosed += HandleOnAdClosed;
    // Called when the ad click caused the user to leave the application.
    this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

    // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
}

public void HandleOnAdLoaded(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleAdLoaded event received");
}

public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
{
    MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                        + args.Message);
}

public void HandleOnAdOpened(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleAdOpened event received");
}

public void HandleOnAdClosed(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleAdClosed event received");
}

public void HandleOnAdLeavingApplication(object sender, EventArgs args)
{
    MonoBehaviour.print("HandleAdLeavingApplication event received");
}

public void ShowInterstitialAds()
{
  Debug.Log("Inter Shown");
  if (interstitial.IsLoaded()) {
    interstitial.Show();
  }
  else
  {
	  RequestInterstitial();
  }
}
public void ShowBannerAds()
{
	bannerView.Show();
}
public void HideBannerAds()
{
	bannerView.Hide();
}
}