dotnet sonarscanner begin /k:"TransactionManagement" /d:sonar.login=sqp_3daa99eebb8bc82aa28ad0af6ff1ae343779e737 /d:sonar.host.url=http://localhost:9000 /d:sonar.verbose=true  /d:sonar.cs.vstest.reportsPaths="TransactionManagement.UnitTests1/TestResults/results.trx" /d:sonar.cs.opencover.reportsPaths=coverage.xml

dotnet build TransactionManagement.sln

dotnet test ./TransactionManagement.UnitTests1 --no-build --logger:"trx;logfilename=results.trx" /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../coverage.xml

dotnet sonarscanner end /d:sonar.login=sqp_3daa99eebb8bc82aa28ad0af6ff1ae343779e737