using UnityEditor;

public class AssetBundlesBuilder
{
    [MenuItem("Build/AssetBundlesBuilder AssetBundles(Windows)", false, 21)]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("AssetBundles/Windows", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}