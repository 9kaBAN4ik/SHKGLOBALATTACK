# Скрипт для экспорта координат деревень из Stronghold Kingdoms

Write-Host "=============================================="
Write-Host "  VILLAGE EXPORTER - SETUP & RUN"
Write-Host "==============================================`n"

# Проверяем наличие .env
if (-not (Test-Path ".env")) {
    Write-Host "❌ Файл .env не найден!" -ForegroundColor Red
    Write-Host "Создайте файл .env со следующим содержимым:`n"
    Write-Host "GAME_EMAIL=your_email@example.com"
    Write-Host "GAME_PASSWORD=your_password"
    Write-Host "shk_link=http://shk-w756.elb.fireflyops.com:80`n"
    pause
    exit 1
}

# Загружаем переменные окружения из .env
Write-Host "Загрузка .env..." -ForegroundColor Cyan
Get-Content .env | ForEach-Object {
    $line = $_.Trim()
    if ($line -and !$line.StartsWith('#') -and $line.Contains('=')) {
        $parts = $line.Split('=', 2)
        $key = $parts[0].Trim()
        $value = $parts[1].Trim()
        [Environment]::SetEnvironmentVariable($key, $value, "Process")
        Write-Host "  $key = $value" -ForegroundColor Gray
    }
}

Write-Host "`nКомпиляция VillageExporter..." -ForegroundColor Cyan

# Компилируем проект
dotnet build VillageExporter.csproj -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Host "`n❌ Ошибка компиляции!" -ForegroundColor Red
    pause
    exit 1
}

Write-Host "`n✅ Компиляция успешна!" -ForegroundColor Green

# Копируем DLL в выходную папку
Write-Host "`nКопирование DLL..." -ForegroundColor Cyan
$outputDir = "bin\Release\net48"

if (Test-Path "StrongholdKingdoms\bin\Debug\ServerInterface.dll") {
    Copy-Item "StrongholdKingdoms\bin\Debug\ServerInterface.dll" "$outputDir\" -Force
    Write-Host "  ✅ ServerInterface.dll" -ForegroundColor Green
}

if (Test-Path "FixedCustomSinks\bin\Release\net48\CustomSinks.dll") {
    Copy-Item "FixedCustomSinks\bin\Release\net48\CustomSinks.dll" "$outputDir\" -Force
    Write-Host "  ✅ CustomSinks.dll" -ForegroundColor Green
}

# Копируем .env
Copy-Item ".env" "$outputDir\" -Force
Write-Host "  ✅ .env" -ForegroundColor Green

Write-Host "`n=============================================="
Write-Host "  ЗАПУСК ЭКСПОРТА"
Write-Host "==============================================`n"

# Запускаем
Set-Location "$outputDir"
& ".\VillageExporter.exe"
Set-Location "..\..\..\"

Write-Host "`n=============================================="
Write-Host "  ГОТОВО!"
Write-Host "==============================================`n"

if (Test-Path "villages.json") {
    Write-Host "✅ Файл villages.json создан!" -ForegroundColor Green
    Write-Host "`nТеперь:" -ForegroundColor Cyan
    Write-Host "1. Скопируйте villages.json на ваш Linux сервер"
    Write-Host "2. Положите его в папку с Discord ботом"
    Write-Host "3. Запустите команду в Discord: !loadvillages`n"
} else {
    Write-Host "⚠️ Файл villages.json не создан!" -ForegroundColor Yellow
    Write-Host "Проверьте вывод программы выше для деталей`n"
}

pause
