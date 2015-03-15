::Runtime Express DotNet Framework Offline Installer
::Version 1.5 by Feight
::Copyright Feight Software 2015,All rights reserved.
@echo off
echo 确定吗？
pause>nul
%SystemRoot%\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:\image
echo 所有操作已成功完成。
pause