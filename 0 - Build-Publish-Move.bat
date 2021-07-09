@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.CSharp\bin\Release\Panosen.CodeDom.CSharp.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.CSharp.Engine\bin\Release\Panosen.CodeDom.CSharp.Engine.*.nupkg D:\LocalSavoryNuget\

pause