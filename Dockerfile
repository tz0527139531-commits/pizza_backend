# שלב הבנייה (Build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# מעתיק את קבצי הפרויקט ומבצע restore
COPY *.sln ./
COPY PizzaShopAPI/*.csproj PizzaShopAPI/
COPY PizzaShopCore/*.csproj PizzaShopCore/
COPY PizzaShopData/*.csproj PizzaShopData/
COPY PizzaShopService/*.csproj PizzaShopService/
RUN dotnet restore

# מעתיק את שאר הקבצים ובונה את האפליקציה
COPY . .
RUN dotnet publish PizzaShopAPI -c Release -o out

# שלב ההרצה (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# מגדיר את הפורט שהאפליקציה תאזין עליו
EXPOSE 80

# מפעיל את האפליקציה בפועל
ENTRYPOINT ["dotnet", "PizzaShopAPI.dll"]