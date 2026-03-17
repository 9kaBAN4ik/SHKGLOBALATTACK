# PowerShell script to fetch village coordinates

Write-Host "============================================" -ForegroundColor Cyan
Write-Host "🎮 SHKGLOBALATTACK - Village Coordinate Fetcher" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
Write-Host ""

# Load .env file
Write-Host "📂 Loading .env file..." -ForegroundColor Yellow
if (Test-Path ".env") {
    Get-Content .env | ForEach-Object {
        $line = $_.Trim()
        if ($line -and !$line.StartsWith('#') -and $line.Contains('=')) {
            $parts = $line.Split('=', 2)
            $name = $parts[0].Trim()
            $value = $parts[1].Trim()
            [Environment]::SetEnvironmentVariable($name, $value, "Process")
            Write-Host "   ✓ Set $name" -ForegroundColor Green
        }
    }
} else {
    Write-Host "❌ .env file not found!" -ForegroundColor Red
    Write-Host "Please create .env file with GAME_EMAIL and GAME_PASSWORD" -ForegroundColor Red
    pause
    exit 1
}

Write-Host ""

# Copy DLLs to output directory
Write-Host "📦 Copying DLL files..." -ForegroundColor Yellow
$dllPath = "StrongholdKingdoms\bin\Debug"
if (!(Test-Path "bin")) { New-Item -ItemType Directory -Path "bin" -Force | Out-Null }

Copy-Item "$dllPath\ServerInterface.dll" "bin\" -Force
Copy-Item "$dllPath\CustomSinks.dll" "bin\" -Force  
Copy-Item "$dllPath\CookComputing.XmlRpcV2.dll" "bin\" -Force
Copy-Item "$dllPath\CommonTypes.dll" "bin\" -Force

Write-Host "   ✓ DLLs copied" -ForegroundColor Green
Write-Host ""

# Build the project
Write-Host "🔨 Building GameServerFetcher..." -ForegroundColor Yellow
dotnet build GameServerFetcher.csproj -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "============================================" -ForegroundColor Red
    Write-Host "❌ Build failed!" -ForegroundColor Red
    Write-Host "============================================" -ForegroundColor Red
    pause
    exit 1
}

Write-Host ""
Write-Host "============================================" -ForegroundColor Green
Write-Host "✅ Build successful!" -ForegroundColor Green
Write-Host "============================================" -ForegroundColor Green
Write-Host ""

# Run the executable
Write-Host "🚀 Running GameServerFetcher..." -ForegroundColor Yellow
Write-Host ""

dotnet run --project GameServerFetcher.csproj --no-build -c Release

Write-Host ""
Write-Host "============================================" -ForegroundColor Cyan
Write-Host "✅ Done!" -ForegroundColor Cyan
Write-Host "============================================" -ForegroundColor Cyan
pause
