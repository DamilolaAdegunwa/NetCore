dotnet pack -c Release
dotnet nuget push bin/Release/NetCoreApiKey.2.1.2.nupkg -k oy2ftcuea4qichnsk2yawfx4hkdagzienbq2yp2j3sdwsy -s https://api.nuget.org/v3/index.json

pause