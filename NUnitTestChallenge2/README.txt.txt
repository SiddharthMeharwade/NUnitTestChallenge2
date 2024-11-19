# NUnit API Test Project
# Date: 19/11/2024
# Author: Siddharth Meharwade

## Overview
This project contains automated tests for validating RESTful API endpoints using NUnit and RestSharp, with enhanced reporting through Allure.

### Prerequisites
- Visual Studio 2022
- .NET SDK 6.0 or above
- Allure Command Line Interface (CLI)
- Ensure the following packages are installed in your project:
	Microsoft.NET.Test.Sdk
	NUnit
	NUnit3TestAdapter
	RestSharp
	Allure.NUnit
	Allure.Commons
- Run these commands in the terminal if needed 
	dotnet add package Microsoft.NET.Test.Sdk
	dotnet add package NUnit
	dotnet add package NUnit3TestAdapter
	dotnet add package RestSharp
	dotnet add package Allure.NUnit
	dotnet add package Allure.Commons


### Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd NUnitTestChallenge2

### Run tests 
- Run the tests from Visual Studio or use the command line:
	dotnet test --logger "trx;LogFileName=test-results.trx"
- Generate and serve results:
	allure serve Test-results

### Test Cases Included
- GET Request: Verify a post is returned with status code 200.
- POST Request: Create a new post and verify status code 201.
- PUT Request: Update a post and verify status code 200.
- DELETE Request: Delete a post and verify status code 200 or 204.

