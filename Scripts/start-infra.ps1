$ComposePath = "C:\Projects\MySolution\"

Write-Host "--- ПОДЪЕМ ИНФРАСТРУКТУРЫ ---" -ForegroundColor Cyan

wsl docker compose -f ../docker-compose.yml up -d

if ($LASTEXITCODE -eq 0) {
    Write-Host "--- ВСЕ СЕРВИСЫ ЗАПУЩЕНЫ ---" -ForegroundColor Green
    wsl docker compose ps
} else {
    Write-Host "--- ОШИБКА ЗАПУСКА ---" -ForegroundColor Red
}