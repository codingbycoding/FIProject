# @echo off
# title GameServer.exe -batchmode -SceneName ServerScene_2 -IP 127.0.0.1 -Port 10002
echo GameServer with ServerScene_2 is running.

open ../Build/GameServer.app -batchmode -SceneName ServerScene_2 -IP 127.0.0.1 -Port 10002 -OnlineIP 127.0.0.1 -OnlinePort 4060 -logFile ../Build/Server_2.log



