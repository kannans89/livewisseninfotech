@echo off

REM Generate a timestamp for the file name
set current_time=%date:~10,4%%date:~4,2%%date:~7,2%%time:~0,2%%time:~3,2%%time:~6,2%

REM Set the file name with the generated timestamp
set file_name=TestResults_%current_time%.html

REM Run NUnit tests and save results in HTML format with the generated file name
dotnet test --logger:"html;LogFileName=%file_name%"

REM dotnet test --logger:"trx;LogFileName=TestResults.xml"
REM if needed xml test result xml ->trx