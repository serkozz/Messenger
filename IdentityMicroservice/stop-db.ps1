$ContainerName = "identity-db"

Write-Host "--- ОСТАНОВКА И УДАЛЕНИЕ $ContainerName ---" -ForegroundColor Yellow

# Останавливаем и удаляем одной строкой в Bash
wsl bash -c "docker stop $ContainerName && docker rm $ContainerName"

if ($LASTEXITCODE -eq 0) {
    Write-Host "--- КОНТЕЙНЕР УДАЛЕН ---" -ForegroundColor Green
} else {
    Write-Host "--- КОНТЕЙНЕР НЕ НАЙДЕН ИЛИ УЖЕ УДАЛЕН ---" -ForegroundColor Gray
}