using UnityEditor;


// Build Game Client and Server by Editor's menu
public class FIBuild
{

    [MenuItem("Build/Build GameServer", false, 1)]
    public static void BuildGameServer()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/1-Scenes/Server.unity", "Assets/1-Scenes/ServerScene_1.unity", "Assets/1-Scenes/ServerScene_2.unity" };
        buildPlayerOptions.locationPathName = "../Server/Build/GameServer.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    [MenuItem("Build/Build GameClient", false, 1)]
    public static void BuildGameClient()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/1-Scenes/Client.unity", "Assets/1-Scenes/ServerList.unity", "Assets/1-Scenes/ServerScene_1.unity", "Assets/1-Scenes/ServerScene_2.unity" };
        buildPlayerOptions.locationPathName = "../Client/Build/GameClient.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}