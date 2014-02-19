@echo off
color F
setlocal

set acc-path=C:\Users\Graham\Desktop\Utils\dh-acc
set PATH=%PATH%;%acc-path%
set SRC=.\src
set OBJ=.\acs
set CMD=dh-acc --named-scripts --auto-stack-size=0 -Z -i %SRC%\inc

echo Compiling DS files...
%CMD% -c %SRC%\fd_fatl.ds -o %OBJ%\fd_fatl.o
%CMD% -c %SRC%\fd_ccmd.ds -o %OBJ%\fd_ccmd.o
%CMD% -c %SRC%\fd_ccam.ds -o %OBJ%\fd_ccam.o
%CMD% -c %SRC%\fd_util.ds -o %OBJ%\fd_util.o
%CMD% -c %SRC%\fd_main.ds -o %OBJ%\fd_main.o
echo Done! Compiling final object file...
%CMD% %OBJ%\fd_fatl.o %OBJ%\fd_ccmd.o %OBJ%\fd_ccam.o %OBJ%\fd_util.o %OBJ%\fd_main.o -o %OBJ%\main.o
del %OBJ%\fd_fatl.o
del %OBJ%\fd_ccmd.o
del %OBJ%\fd_ccam.o
del %OBJ%\fd_util.o
del %OBJ%\fd_main.o

echo All done! Press any key to exit.

endlocal
pause >nul