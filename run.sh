docker-compose -p cs-go-stats up --no-recreate -d

rm -rf `cat folders_to_remove | sed 's/\\r//g'`

rm -f ./../../../target/extensions/CSGOStats.Infrastructure.Extensions*.nupkg && 
	dotnet restore -v m ./extensions.sln && 
	dotnet build -v diag -c Release --no-incremental ./extensions.sln && 
	dotnet test -v n ./extensions.sln && 
	dotnet pack -v m -c Release -o ./../../../target/extensions/ ./extensions.sln && 
	dotnet nuget push ./../../../target/extensions/CSGOStats.Infrastructure.Extensions*.nupkg -k b8e0f6c7-0f8d-3d80-83dc-eccb59ee6083 --skip-duplicate -n true -t 30 -s http://localhost:8081/repository/nuget-default/

rm -f ./../../../target/extensions/CSGOStats.Infrastructure.Extensions*.nupkg

echo ''
read -p 'Run finished. Pressing any key will terminate this script.'