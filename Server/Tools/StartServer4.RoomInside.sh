# @echo off
# title GameServer.exe -batchmode -SceneName ServerScene_1 -IP 127.0.0.1 -Port 10001
echo GameServer with ServerScene_RoomInside is running.

open -n ../Build/GameServer.app --args -batchmode -SceneName ServerScene_RoomInside -SceneLabelName RoomInside -IP 127.0.0.1 -Port 10004 -OnlineIP 127.0.0.1 -OnlinePort 4060 -logFile ../Build/ServerScene_RoomInside.log



