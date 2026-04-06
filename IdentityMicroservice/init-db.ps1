$ContainerName = "identity-db"

Write-Host "--- ПРОВЕРКА DOCKER В ARCH ---" -ForegroundColor Cyan

# 1. Запуск демона, если он спит
# Запускаем dockerd через nohup, чтобы он жил своей жизнью в фоне WSL
wsl bash -c "if ! pgrep -x dockerd > /dev/null; then sudo nohup dockerd > /dev/null 2>&1 & sleep 3; fi"

# 2. Логика контейнера одной строкой (чтобы избежать проблем с переносами \r)
$bashCmd = "if [ `$(docker ps -aq -f name=^/${ContainerName}$)` ]; then " +
           "docker start ${ContainerName}; " +
           "else docker run --name ${ContainerName} -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin -e POSTGRES_DB=identity_db -p 5432:5432 -d postgres; fi"

Write-Host "--- ЗАПУСК КОНТЕЙНЕРА ---" -ForegroundColor Cyan
wsl bash -c "$bashCmd"

if ($LASTEXITCODE -eq 0) {
    Write-Host "--- ГОТОВО! ---" -ForegroundColor Green
    wsl docker ps --filter "name=$ContainerName"
} else {
    Write-Host "--- ОШИБКА ---" -ForegroundColor Red
    Write-Host "Если просит пароль - введи его. Если пишет 'command not found' - сделай в Арче: sudo pacman -S docker"
}