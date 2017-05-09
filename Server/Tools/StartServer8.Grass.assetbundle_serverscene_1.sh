# @echo off

echo GameServer with Grass(asssetbundle_serverscene_grasshouse) is running.

open -n ../Build/GameServer.app --args -batchmode -SceneName assetbundle_serverscene_grasshouse -SceneLabelName GrassHouse -IP 127.0.0.1 -Port 10008 -OnlineIP 127.0.0.1 -OnlinePort 4060 -logFile ../Build/Server_GrassHouse.log



