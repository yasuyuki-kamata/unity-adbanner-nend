using UnityEngine;
using System.Collections;

public class AdBannerObserver : MonoBehaviour {
    private static AdBannerObserver sInstance;
    
    public static void Initialize() {
        Initialize(0, null, 0.0f);
    }
    
    public static void Initialize(int spotID, string apiKey, float refresh) {
        if (sInstance == null) {
            // Make a game object for observing.
            GameObject go = new GameObject("_AdBannerObserver");
            go.hideFlags = HideFlags.HideAndDontSave;
            DontDestroyOnLoad(go);
            // Add and initialize this component.
            sInstance = go.AddComponent<AdBannerObserver>();
            sInstance.mNendSpotID = spotID;
            sInstance.mNendApiKey = apiKey;
            sInstance.mRefreshTime = refresh;
        }
    }
    
    public int mNendSpotID;
    public string mNendApiKey;
    public float mRefreshTime;
    
    IEnumerator Start () {
#if UNITY_IPHONE
        ADBannerView banner = new ADBannerView();
        banner.autoSize = true;
        banner.autoPosition = ADPosition.Bottom;
        
        while (true) {
            if (banner.error != null) {
                Debug.Log("Error: " + banner.error.description);
                break;
            } else if (banner.loaded) {
                banner.Show();
                break;
            }
            yield return null;
        }
#elif UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass plugin = new AndroidJavaClass("net.oira_project.nendunityplugin.NendAdBannerController");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        while (true) {
            plugin.CallStatic("tryCreateBanner", activity, mNendSpotID, mNendApiKey);
            yield return new WaitForSeconds(Mathf.Max(30.0f, mRefreshTime));
        }
#else
        return null;
#endif
    }
}