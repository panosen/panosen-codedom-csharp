@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget push Panosen.CodeDom.CSharp\bin\Release\Panosen.CodeDom.CSharp.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate

move /Y Panosen.CodeDom.CSharp\bin\Release\Panosen.CodeDom.CSharp.*.nupkg D:\LocalSavoryNuget\

pause