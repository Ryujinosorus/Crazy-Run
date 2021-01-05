using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string gameId;

#if UNITY_ANDROID
        gameId = "3962231";
#elif UNITY_IOS
             gameId = "3962230";
#endif

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, false);
        }
    }
    // Update is called once per frame
    public void showAds()
    {
        if (Random.Range(0,2)==0 && Advertisement.IsReady())
            Advertisement.Show();
    }
}
