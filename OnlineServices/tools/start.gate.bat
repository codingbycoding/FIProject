@echo off

%CD:~0,2%
cd %~dp0

title %0 

cls


cd ..
glacier2router --Ice.Config=.\config\gate.cfg
pause.