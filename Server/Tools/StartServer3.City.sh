# @echo off
# title GameServer.exe -batchmode -SceneName ServerScene_1 -IP 127.0.0.1 -Port 10003
echo GameServer with ServerScene_City is running.

open -n ../Build/GameServer.app --args -batchmode -SceneName ServerScene_City -SceneLabelName City -IP 127.0.0.1 -Port 10003 -OnlineIP 127.0.0.1 -OnlinePort 4060 -logFile ../Build/Server_City.log


