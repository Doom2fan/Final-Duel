@echo off
color F
setlocal

set acc-path=C:\Users\Graham\Desktop\Utils\dh-acc
set PATH=%PATH%;%acc-path%
set SRC=.\src
set OBJ=.\acs
set CMD=dh-acc --named-scripts --auto-stack-size=0 -Z -i %SRC%\inc

echo Compiling DS files...
%CMD% %SRC%\fd_main.ds -o %OBJ%\fd_main.o
rem echo Done! Compiling final object file...
rem %CMD% %OBJ%\CWAtchMenu.o %OBJ%\CWAttach.o %OBJ%\CWGetVal.o %OBJ%\CWKeyFinder.o %OBJ%\CWLaser.o %OBJ%\CWGetAttachment.o -o %OBJ%\CWMain.o
rem del %OBJ%\CWAtchMenu.o

echo All done! Press any key to exit.

endlocal
pause >nul