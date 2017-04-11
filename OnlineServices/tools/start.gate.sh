# @echo off

# %CD:~0,2%
# cd %~dp0

# title %0 

clear


cd ..
glacier2router --Ice.Config=./config/gate.cfg
