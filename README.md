# festival-ms


dotnet ef migrations add InitialCreate
dotnet ef migrations add 20240805 --startup-project ../Festival.Ms.API/

execute migrations 
win
dotnet ef database update --startup-project ..\Festival.Ms.API\
mac
dotnet ef database update --startup-project ../Festival.Ms.API/