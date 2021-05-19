@Echo OFF
SET PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\
SET SolutionPath=src\MoneyAssessment.sln


Echo "Restoring Packages..."
call nuget\nuget.exe restore %SolutionPath%

Echo "Building Solution..."

MSbuild %SolutionPath% /p:Configuration=Release /p:Platform="Any CPU"


Echo "Running Tests..."
SET PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\
cd output\tests
VSTest.Console.exe MoneyAssessment.Tests.dll /logger:trx;LogFileName=TestResults.trx

pushd "%~dp0"
Echo "Running application...
call output\MoneyAssessment.exe

