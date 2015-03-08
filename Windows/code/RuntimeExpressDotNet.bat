::Runtime Express DotNet Framework Offline Installer
::Version 1.5 by Feight
::Copyright Feight Software 2015,All rights reserved.

@echo off
color 1F
title Runtime Express .net Framework Offline Installer 命令行实用工具
echo Runtime Express .net Framework 离线安装器
echo 版本：1.5.2（1531）
echo 映像版本：6.3.9600.16384
echo Copyright Feight Software 2015,All rights reserved.
echo ------------------------------
echo 你要现在开始安装.net Framework吗？
echo 在安装开始之前请保存工作以便重启。
echo 按任意键来开始。
pause>nul



:check
echo ####################开始工作####################
echo 正在检查你的操作系统……
echo 正在进行一些准备工作……
set TempFile_Name=%SystemRoot%\System32\BatTestUACin_SysRt%Random%.tmp
 
::写入文件
echo 正在创建临时文件……
( echo "Runtime Express UAC test" >%TempFile_Name% ) 1>nul 2>nul
 
::判断写入是否成功
echo 正在验证文件……
if exist %TempFile_Name% (
echo 正在以管理员身份运行当前批处理。
echo 验证成功。
echo 正在删除临时文件……
del %TempFile_Name% 1>nul 2>nul
) else (
color ce
echo 【出现错误】
echo 检测到你没有以管理员身份运行当前工具。
echo 请退出，然后用管理员权限再试一次。
pause
exit
)
 
echo 检测完毕。你的电脑可以使用本工具。
echo 请再次确认你已经准备好安装。按任意键继续。
pause>nul
ver | find "6.3." > NUL &&  goto install


:install
echo 安装即将开始……
echo 这可能需要几分钟或者更长时间，请勿关闭计算机。
%SystemRoot%\system32\dism.exe /online /enable-feature /featurename:netfx3 /Source:\image
echo 所有操作已成功完成。按任意键重启来完成安装。
pause>nul
shutdown /r /t 60
exit



:fail
echo 抱歉，本工具仅适用于Windows 8.1。无法应用到你的操作系统。
echo 请按任意键退出。
pause>nul
