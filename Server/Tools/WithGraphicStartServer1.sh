# @echo off
# title GameServer.exe -SceneName ServerScene_1 -IP 127.0.0.1 -Port 10001
echo GameServer with ServerScene_1 is running.

open ../Build/GameServer.app --args -SceneName ServerScene_1 -IP 127.0.0.1 -Port 10001 -OnlineIP 127.0.0.1 -OnlinePort 4060 -logFile ../Build/Server_1.log



