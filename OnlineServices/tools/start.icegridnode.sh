# @echo off

# %CD:~0,2%
# cd %~dp0

# title %0 

clear


# del /S /Q ..\db\node\*
# del /S /Q ..\db\registry\*

# rmdir /S /Q ..\db\node\distrib
# rmdir /S /Q ..\db\node\servers
# rmdir /S /Q ..\db\node\tmp
# rmdir /S /Q ..\db\registry\__Freeze

cd ..
icegridnode --Ice.Config=./config/config.grid
