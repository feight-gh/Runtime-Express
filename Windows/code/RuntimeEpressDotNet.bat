::Runtime Express DotNet Framework Offline Installer
::Version 1.5 by Feight
::Copyright Feight Software 2015,All rights reserved.
@echo off
echo ȷ����
pause>nul
%SystemRoot%\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:\image
echo ���в����ѳɹ���ɡ�
pause