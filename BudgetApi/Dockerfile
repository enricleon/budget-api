FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BudgetApi/*.csproj ./BudgetApi/
COPY BudgetApi.Tests/*.csproj ./BudgetApi.Tests/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/BudgetApi
RUN dotnet build


FROM build AS testrunner
WORKDIR /app/BudgetApi.Tests
ENTRYPOINT ["dotnet", "test", "--logger:trx"]


FROM build AS test
WORKDIR /app/BudgetApi.Tests
RUN dotnet test


FROM build AS publish
WORKDIR /app/BudgetApi
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=publish /app/BudgetApi/out ./
ENTRYPOINT ["dotnet", "BudgetApi.dll"]

EXPOSE 5000
