using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssetsBundleOp : MonoBehaviour {

    AssetBundle assetBundleScene;
    float downloadProgress;

    Image bgImage;
    Text precentIndicator;
    Text stateIndicator;
    bool downloadDone;

	string baseBundleURL; 
	string bundleURL;

	// Use this for initialization
    void Start () {		
		


        Transform bgProgress = transform.FindChild("AB_Scene_1_bg");
        bgImage = bgProgress.GetComponent<Image>();

        precentIndicator = transform.FindChild("progressIndicator").GetComponent<Text>();
        stateIndicator = transform.FindChild("loadingState").GetComponent<Text>();
        stateIndicator.text = "";
        precentIndicator.text = "";
        //bgImage.fillAmount = 0;
        downloadDone = false;

		//CheckCached(assetBundleSceneName);
    }

	public void CheckCached(string assetBundleSceneName, string sceneLabelName)
    {
		if (0 == transform.GetSiblingIndex ()) {
			return;
		}
	
		baseBundleURL = "http://" + DataMaster.GameClient.OnlineIP + ":8080/FIProject_AssetBundles/scenes/";
		bundleURL = baseBundleURL + assetBundleSceneName;

		transform.FindChild("AssetBundleSceneName").GetComponent<Text>().text = sceneLabelName;

        if(Caching.IsVersionCached(bundleURL, 0))
        {
			transform.FindChild("loadingState").GetComponent<Text>().text = "Ready";
            downloadDone = true;
			transform.SetAsFirstSibling ();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(stateIndicator.text.Equals("Ready")) {
			transform.SetAsFirstSibling ();
		}

        if(stateIndicator.text.Equals(""))
        {
            return;
        }

        bgImage.fillAmount = downloadProgress;

        int precent = (int) (downloadProgress * 100);
        precentIndicator.text = "" + precent + "%";

        if (downloadDone)
        {
            stateIndicator.text = "Done";
			transform.SetAsFirstSibling ();
        }
    }


    public void StartDownloadAssetBundle_Scene_1()
    {
        if(downloadDone)
        {
            return;
        }

        stateIndicator.text = "Loading...";

        StartCoroutine(DownloadAssetBundle_Scene_1());
    }

	IEnumerator DownloadAssetBundle_Scene_1()
    {
        Debug.Log("DownloadAssetBundle Scene:" + bundleURL);
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