using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class BannerAD : MonoBehaviour
{
#if UNITY_ANDROID
  private string _adUnitId = "ca-app-pub-4240893116802153/7897968716";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-4240893116802153~8089540403";
#else
  private string _adUnitId = "unused";
#endif

  BannerView _bannerView;

  public void Start()
  {
    if (PlayerPrefs.HasKey("NoAds") == false)
    {
      PlayerPrefs.SetInt("NoAds", 0);
    }
    MobileAds.RaiseAdEventsOnUnityMainThread = true;
    MobileAds.Initialize((InitializationStatus initStatus) =>
        {
          if(PlayerPrefs.GetInt("NoAds") == 0) 
          {
            LoadAd();
          }
          
        });
       


  }
  private void ListenToAdEvents()
  {
    
    _bannerView.OnBannerAdLoaded += () =>
    {
      Debug.Log("Banner view loaded an ad with response : "
          + _bannerView.GetResponseInfo());
    };
    
    _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
    {
      Debug.LogError("Banner view failed to load an ad with error : "
          + error);
    };
    
    _bannerView.OnAdPaid += (AdValue adValue) =>
    {
      Debug.Log(String.Format("Banner view paid {0} {1}.",
          adValue.Value,
          adValue.CurrencyCode));
    };
    
    _bannerView.OnAdImpressionRecorded += () =>
    {
      Debug.Log("Banner view recorded an impression.");
    };
   
    _bannerView.OnAdClicked += () =>
    {
      Debug.Log("Banner view was clicked.");
    };
   
    _bannerView.OnAdFullScreenContentOpened += () =>
    {
      Debug.Log("Banner view full screen content opened.");
    };
    
    _bannerView.OnAdFullScreenContentClosed += () =>
    {
      Debug.Log("Banner view full screen content closed.");
    };
  }
  public void CreateBannerView()
  {
    Debug.Log("Creating banner view");

    
    if (_bannerView != null)
    {
      DestroyAd();
    }

    
    _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
  }
  public void LoadAd()
  {
    
    if (_bannerView == null)
    {
      CreateBannerView();
    }
    
    var adRequest = new AdRequest();
    adRequest.Keywords.Add("unity-admob-sample");

    
    Debug.Log("Loading banner ad.");
    _bannerView.LoadAd(adRequest);
    ListenToAdEvents();
  }
  public void DestroyAd()
  {
    if (_bannerView != null)
    {
      Debug.Log("Destroying banner ad.");
      _bannerView.Destroy();
      _bannerView = null;
    }
  }



}

