using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsBundlePanel : MonoBehaviour {

    AssetBundle assetBundleScene;
    float downloadProgress;

    Image bgImage;
    Text precentIndicator;
    Text stateIndicator;
    bool downloadDone;

	string baseBundleURL;
    // string bundleURL = "file://C:/Users/Adam/Documents/GitHub/FIProject/Client/AssetBundles/Windows/scenes/serverscene_assetbundle_1";
	string bundleURL; // = "http://localhost:8080/FIProject_AssetBundles/scenes/serverscene_assetbundle_1";

	// Use this for initialization
    void Start () {		
		baseBundleURL = "http://" + DataMaster.GameClient.OnlineIP + ":8080/FIProject_AssetBundles/scenes/";
		string assetBundleSceneName = "serverscene_assetbundle_1";
		bundleURL = baseBundleURL + assetBundleSceneName;
        Transform bgProgress = transform.FindChild("AB_Scene_1_bg");
        bgImage = bgProgress.GetComponent<Image>();

        precentIndicator = transform.FindChild("progressIndicator").GetComponent<Text>();
        stateIndicator = transform.FindChild("loadingState").GetComponent<Text>();
        stateIndicator.text = "";
        precentIndicator.text = "";
        bgImage.fillAmount = 0;
        downloadDone = false;

        CheckCached();
    }

    void CheckCached()
    {
        if(Caching.IsVersionCached(bundleURL, 0))
        {
            stateIndicator.text = "Ready";
            downloadDone = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(stateIndicator.text.Equals("") || stateIndicator.text.Equals("Ready"))
        {
            return;
        }

        bgImage.fillAmount = downloadProgress;

        int precent = (int) (downloadProgress * 100);
        precentIndicator.text = "" + precent + "%";

        if (downloadDone)
        {
            stateIndicator.text = "Done";
        }
    }


    public void StartDownloadAssetBundle_Scene_1()
    {
        if(downloadDone)
        {
            return;
        }

        stateIndicator.text = "Loading...";

        StartCoroutine(DownloadAssetBundle_Scene_1(bundleURL));
    }

    IEnumerator DownloadAssetBundle_Scene_1(string bundleURL)
    {
        Debug.Log("DownloadAssetBundle_Scene_1 :" + bundleURL);
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload(bundleURL, 0))
        {
            while (!www.isDone)
            {
                downloadProgress = www.progress;
                yield return null;
            }

            downloadDone = true;
            //yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            if (null != assetBundleScene)
            {
                assetBundleScene.Unload(false);
            }

            assetBundleScene = www.assetBundle;

            //Instantiate(bundle.LoadAsset(AssetName));
            // Unload the AssetBundles compressed contents to conserve memory
            //bundle.Unload(false);

            //string[] scenePath = assetBundleScene.GetAllScenePaths();
            //Debug.Log("scenePath[0]:" + Path.GetFileNameWithoutExtension(scenePath[0]));

            //SceneManager.LoadSceneAsync(System.IO.Path.GetFileNameWithoutExtension(scenePath[0]), LoadSceneMode.Single);
        } 


    }
}