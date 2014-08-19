using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GoogleAdsScript : MonoBehaviour
{

    private BannerView bannerView;
    private InterstitialAd interstitial;

    public string bannerAdID;
    public string interstitialAdID;

    public bool Banner;
    public bool IABBanner;
    public bool Leaderboard;
    public bool MediumRectangle;
    public bool SmartBanner;

    public bool TopPosition;
    public bool BottomPosition;

    public string keywords;
    public bool TagForChildDirectedTreatmentAD = false;
    //public int BirthdayYear;
    //public int BirthdayMonth;
    //public int BirthdayDay;

    private void RequestBanner()
    {

        string adUnitId = bannerAdID;

        #region Banner Size
        AdSize adsize = AdSize.SmartBanner;

        if (Banner == true)
        {
            adsize = AdSize.Banner;
        }
        if (IABBanner == true)
        {
            adsize = AdSize.IABBanner;
        }
        if (Leaderboard == true)
        {
            adsize = AdSize.Leaderboard;
        }
        if (MediumRectangle == true)
        {
            adsize = AdSize.MediumRectangle;
        }
        if (SmartBanner == true)
        {
            adsize = AdSize.SmartBanner;
        }
        if ((Banner == true) && (IABBanner == true) &&
            (MediumRectangle == true) && (Leaderboard == true) &&
            (SmartBanner == true))
        {
            Debug.LogError("You check every BannerSize flags");
        }

        if ((!Banner == true) && (!IABBanner == true) &&
            (!MediumRectangle == true) && (!Leaderboard == true) &&
            (!SmartBanner == true))
        {
            Debug.LogError("You need to check any BannerSize flag");
        }
        #endregion

        #region Banner Position

        AdPosition adposition = AdPosition.Top;

        if (TopPosition == true)
        {

            adposition = AdPosition.Top;
        }

        if (BottomPosition == true)
        {

            adposition = AdPosition.Bottom;
        }

        if ((TopPosition == true) && (BottomPosition == true))
        {
            Debug.LogError("You check every position flags");
        }

        if ((!TopPosition == true) && (!BottomPosition == true))
        {
            Debug.LogError("You need to check any position flag");
        }

        #endregion

        // Create a banner.
        bannerView = new BannerView(adUnitId, adsize, adposition);
        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;
        // Load a banner ad.
        bannerView.LoadAd(createAdRequest());
    }

    public void RequestInterstitial()
    {

        string adUnitId = interstitialAdID;

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Register for ad events.
        interstitial.AdLoaded += HandleInterstitialLoaded;
        interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.AdOpened += HandleInterstitialOpened;
        interstitial.AdClosing += HandleInterstitialClosing;
        interstitial.AdClosed += HandleInterstitialClosed;
        interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice("")
            .AddKeyword(keywords)
            //.SetGender(Gender.Male)
            //.SetBirthday(new DateTime(BirthdayYear, BirthdayMonth, BirthdayDay))
            .TagForChildDirectedTreatment(TagForChildDirectedTreatmentAD)
            //.AddExtra("","")
            .Build();

    }

    public void ShowInterstitial()
    {

        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet.");
            ShowInterstitial();
        }
    }

    private static GoogleAdsScript instance = null;

    public static GoogleAdsScript Instance {
        get { return instance; }
    }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static GoogleAdsScript Instance {
        get { return instance; }
    }
    void Awake() {

        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {

        RequestBanner();
    }
        

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion

}
