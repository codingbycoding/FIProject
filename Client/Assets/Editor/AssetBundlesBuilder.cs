using UnityEditor;

public class AssetBundlesBuilder
{
    [MenuItem("Build/AssetBundlesBuilder AssetBundles(Win)", false, 21)]
    static void BuildAllAssetBundlesWin()
    {
        BuildPipeline.BuildAssetBundles("AssetBundles/Win", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }

	[MenuItem("Build/AssetBundlesBuilderOSX AssetBundles(OSX)", false, 121)]
	static void BuildAllAssetBundles()
	{
		BuildPipeline.BuildAssetBundles("AssetBundles/OSX", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
	}
}