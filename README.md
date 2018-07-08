# Budget API with users CRUD and Event Sourcing pattern for budget operations handling 

This API has been developed using .NET core along with Marten Event Sourcing library and PostgreSQL.


# How to run

In order to run the API you'll have to install docker-compose.

You can follow the official documentation in order to do so: [https://docs.docker.com/compose/install/]

Once you have docker-compose installed:

```
sudo docker-compose build
```

This will build the project along with all the required dependencies. It is in this step where the integration tests are supposed to run, but there is some problem and it can not be done through the Dockerfile for the moment.

```
sudo docker-compose up
```

This will start the API in [http://localhost:5000]

You can check all the methods through [http://localhost:5000/swagger]

1. You'll have to add some users

```
curl -X POST "http://localhost:5000/api/Users" -H "accept: text/plain" -H "Content-Type: application/json-patch+json" -d "\"User1\""
curl -X POST "http://localhost:5000/api/Users" -H "accept: text/plain" -H "Content-Type: application/json-patch+json" -d "\"User2\""
curl -X POST "http://localhost:5000/api/Users" -H "accept: text/plain" -H "Content-Type: application/json-patch+json" -d "\"User3\""
```
2. After adding some users you'll have to add some funding for them:

```
curl -X POST "http://localhost:5000/api/Money/add" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"userId\": 1, \"amount\": 100}"
curl -X POST "http://localhost:5000/api/Money/add" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"userId\": 1001, \"amount\": 101}"
curl -X POST "http://localhost:5000/api/Money/add" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"userId\": 2001, \"amount\": 102}"
```

3. Then, you can start to transfer money from a user to another:

```
curl -X POST "http://localhost:5000/api/Money/transfer" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"userId\": 1, \"targetUserId\": 1001, \"amount\": 50}"
```

4. Now, you can check the balance of one of the users involved:

```
curl -X GET "http://localhost:5000/api/Users/1/balance" -H "accept: text/plain"
```

In shold be 50 in this case.


# Testing

In order to execute the tests (MSTest) you should install the dotnet cli tool and run it manually by doing "dotnet test"
