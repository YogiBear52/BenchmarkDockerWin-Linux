& $Env:ProgramFiles\Docker\Docker\DockerCli.exe -SwitchWindowsEngine

docker build -t docker-benchmark-windows -f DockerBenchmark/DockerfileWindows .
docker tag docker-benchmark-windows yogevmizrahi/docker-benchmark-windows
docker push yogevmizrahi/docker-benchmark-windows

& $Env:ProgramFiles\Docker\Docker\DockerCli.exe -SwitchLinuxEngine

docker build -t docker-benchmark-linux -f DockerBenchmark/DockerfileLinux .
docker tag docker-benchmark-linux yogevmizrahi/docker-benchmark-linux
docker push yogevmizrahi/docker-benchmark-linux