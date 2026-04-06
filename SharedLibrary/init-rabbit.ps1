$ContainerName = "identity-rabbit"

Write-Host "--- ПРОВЕРКА DOCKER В ARCH ---" -ForegroundColor Cyan

# 1. Запуск демона, если он спит
wsl bash -c "if ! pgrep -x dockerd > /dev/null; then sudo nohup dockerd > /dev/null 2>&1 & sleep 3; fi"

# 2. Логика RabbitMQ (используем образ с management-панелью)
$bashCmd = "if [ `$(docker ps -aq -f name=^/${ContainerName}$)` ]; then " +
           "docker start ${ContainerName}; " +
           "else docker run --name ${ContainerName} " +
           "-e RABBITMQ_DEFAULT_USER=admin " +
           "-e RABBITMQ_DEFAULT_PASS=admin " +
           "-p 5672:5672 -p 15672:15672 " +
           "-d rabbitmq:3-management; fi"

Write-Host "--- ЗАПУСК RABBITMQ ---" -ForegroundColor Cyan
wsl bash -c "$bashCmd"

if ($LASTEXITCODE -eq 0) {
    Write-Host "--- ГОТОВО! ---" -ForegroundColor Green
    Write-Host "Админка: http://localhost:15672 (admin/admin)" -ForegroundColor Yellow
    wsl docker ps --filter "name=$ContainerName"
} else {
    Write-Host "--- ОШИБКА ---" -ForegroundColor Red
}