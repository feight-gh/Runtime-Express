::Runtime Express DotNet Framework Offline Installer
::Version 1.7 by Feight
::Copyright Feight Software 2015,All rights reserved.

@echo off
color 1F
title Runtime Express .net Framework Offline Installer ������ʵ�ù���
echo Runtime Express .net Framework ���߰�װ��
echo �汾��1.7��2015.8.30.0��
echo Դ�汾��6.3.9600.16384
echo Copyright Feight Software 2015,All rights reserved.
echo ------------------------------
echo ��Ҫ���ڿ�ʼ��װ.net Framework��
echo �ڰ�װ��ʼ֮ǰ�뱣�湤���Ա�������
echo �����������ʼ��
pause>nul



:check
echo ####################��ʼ����####################
echo ���ڼ����Ĳ���ϵͳ����
echo ���ڽ���һЩ׼����������
set TempFile_Name=%SystemRoot%\System32\BatTestUACin_SysRt%Random%.tmp
 
::д���ļ�
echo ���ڴ�����ʱ�ļ�����
( echo "Runtime Express UAC test" >%TempFile_Name% ) 1>nul 2>nul
 
::�ж�д���Ƿ�ɹ�
echo ������֤�ļ�����
if exist %TempFile_Name% (
echo �����Թ���Ա������е�ǰ��������֤�ɹ���
echo ����ɾ����ʱ�ļ�����
del %TempFile_Name% 1>nul 2>nul
) else (
color ce
title Runtime Express .net Framework Offline Installer ������ʵ�ù��� - ����
echo �����ִ��󡿼�⵽��û���Թ���Ա������е�ǰ���ߡ�
echo ���˳���Ȼ���ù���ԱȨ������һ�Ρ�
pause
exit
)
 
echo �����ϡ���ĵ��Կ���ʹ�ñ����ߡ�
echo ���ٴ�ȷ�����Ѿ�׼���ð�װ���������������
pause>nul
ver | find "6.3." > NUL &&  goto install


:fail
echo ��Ǹ�������߽�������Windows 8.1 x86/x64���޷�Ӧ�õ���Ĳ���ϵͳ��
echo �밴������˳���
pause>nul
exit


:install
echo ��װ������ʼ����
echo �������Ҫ�����ӻ��߸���ʱ�䣬����رռ������
if %processor_architecture%==x86 (%SystemRoot%\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:\image\x86) else (%SystemRoot%\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:\image\x64)
echo ���в����ѳɹ���ɡ����������������ɰ�װ��
pause>nul
shutdown /r /t 30
exit
