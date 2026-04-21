dotnet sonarscanner begin /k:"andriyhlova_transaction-management" /o:andriyhlova /d:sonar.login=789ed7c677047140608469a22763ec4c1db2251e /d:sonar.host.url=https://sonarcloud.io /d:sonar.verbose=true  /d:sonar.cs.vstest.reportsPaths="TransactionManagement.UnitTests/TestResults/results.trx" /d:sonar.cs.opencover.reportsPaths=coverage.xml

dotnet build TransactionManagement.sln

dotnet test ./TransactionManagement.UnitTests --no-build --logger:"trx;logfilename=results.trx" /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=../coverage.xml

dotnet sonarscanner end /d:sonar.login=789ed7c677047140608469a22763ec4c1db2251e