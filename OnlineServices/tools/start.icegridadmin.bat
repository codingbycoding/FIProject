@echo off

%CD:~0,2%
cd %~dp0

title %0 

cls

cd ..
icegridadmin --Ice.Config=.\config\config.grid -e "application add ./config/application.xml"

pause.