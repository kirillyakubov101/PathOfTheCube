using EndlessCube.Core;
using EndlessCube.Events;
using UnityEngine;
using UnityEngine.Advertisements;

namespace EndlessCube.Ads
{
	public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
		[SerializeField] private bool testMode = true;
		[SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

        const string _androidAdUnitIdBanner = "Banner_Android";
        const string _androidAdUnitId = "Rewarded_Android";

        public static AdManager instance;

#if UNITY_ANDROID

		private string gameId = "4264663";
#else
		private string gameId = "4264662";
#endif

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Destroy(gameObject);
			}
			else
			{
				instance = this;
				DontDestroyOnLoad(gameObject);

				Advertisement.Initialize(gameId, false);
			}
		}

		private void Start()
		{
			Advertisement.Banner.SetPosition(_bannerPosition);

			// Load the Ad Unit with banner content:
			Advertisement.Banner.Load(_androidAdUnitIdBanner);

			// Show the loaded Banner Ad Unit:
			Advertisement.Banner.Show(_androidAdUnitIdBanner);
		}

        public void PlayRewardedAdd()
		{
            Advertisement.Load(_androidAdUnitId,this);
            
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Advertisement.Show(placementId, this);
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
           
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
          
        }

        public void OnUnityAdsShowStart(string placementId)
        {
           
        }

        public void OnUnityAdsShowClick(string placementId)
        {
          
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (_androidAdUnitId.Equals(placementId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                PlayerEvents.Instance.ContinueGame();
                PlayerHealth.Instance.EnableInvisibility();
            }
        }

        public void HideBanner()
        {
            Advertisement.Banner.Hide();
        }
    }
}


