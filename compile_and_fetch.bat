@echo off
echo ============================================
echo Compiling GameServerClient.cs
echo ============================================

REM Copy required DLLs to current directory
echo Copying DLL files...
copy StrongholdKingdoms\bin\Debug\ServerInterface.dll . >nul 2>&1
copy StrongholdKingdoms\bin\Debug\CustomSinks.dll . >nul 2>&1
copy StrongholdKingdoms\bin\Debug\CookComputing.XmlRpcV2.dll . >nul 2>&1
copy StrongholdKingdoms\bin\Debug\CommonTypes.dll . >nul 2>&1

REM Try to find Newtonsoft.Json.dll
if exist "packages\Newtonsoft.Json*\lib\net45\Newtonsoft.Json.dll" (
    copy "packages\Newtonsoft.Json*\lib\net45\Newtonsoft.Json.dll" . >nul 2>&1
) else if exist "StrongholdKingdoms\bin\Debug\Newtonsoft.Json.dll" (
    copy "StrongholdKingdoms\bin\Debug\Newtonsoft.Json.dll" . >nul 2>&1
) else (
    echo WARNING: Newtonsoft.Json.dll not found, installing via NuGet...
    nuget install Newtonsoft.Json -OutputDirectory packages
    copy "packages\Newtonsoft.Json*\lib\net45\Newtonsoft.Json.dll" . >nul 2>&1
)

echo Compiling GameServerClient.cs...

REM Compile C# client
csc /r:ServerInterface.dll /r:CustomSinks.dll /r:CookComputing.XmlRpcV2.dll /r:CommonTypes.dll /r:Newtonsoft.Json.dll /r:System.Runtime.Remoting.dll /r:System.Net.Http.dll GameServerClient.cs

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ============================================
    echo ERROR: Compilation failed!
    echo ============================================
    pause
    exit /b 1
)

echo.
echo ============================================
echo Compilation successful!
echo ============================================
echo.
echo Now running GameServerClient to fetch villages...
echo.

REM Run the compiled client
GameServerClient.exe

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ============================================
    echo ERROR: Failed to fetch villages!
    echo ============================================
    pause
    exit /b 1
)

echo.
echo ============================================
echo Success! Village data fetched.
echo ============================================
pause
