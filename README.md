# Student Performance Predictor (C# + ML.NET)

A full-stack machine learning–powered web application built with C#, ASP.NET Core, and ML.NET that predicts whether a student is likely to pass or fail based on academic behavior and performance metrics.

## Overview

This project demonstrates how a machine learning model can be integrated into a real-world backend system.
It combines data science, API development, and database persistence into a clean, modular architecture.

The application:

- Trains a machine learning model on student data
- Exposes predictions through a REST API
- Stores prediction history in a database
- Provides interactive testing via Swagger UI

## Features

- Machine Learning Model

	- Binary classification (Pass / Fail)
	- Built using ML.NET
	- Outputs prediction + probability

- REST API

	- Predict student performance
	- Retrieve prediction history

- Database Integration

	- SQLite database
	- Stores all predictions

- Swagger UI

	- Interactive API testing
	- Auto-generated documentation

- Clean Architecture

	- Separation of concers
	- Scalable and maintainable design

## Architechture

	Client (Swagger / Frontend) 
		  ↓ 
	ASP.NET Core API (Controllers) 
		  ↓ 
	Prediction Service (ML Layer) 
		  ↓ 
	     ML.NET Model 
		  ↓ 
	SQLite Database (EF Core)

## Technologies

- C# / .NET 10.0
- ASP.NET Core Web API
- ML.NET
- Entity Framework Core
- SQLite
- Swagger (OpenAPI)

## Machine Learning Logic

- Data Loading

	- CSV dataset of student performance

- Feature Engineering 

	- Combine inputs into feature vector

- Model Training

	- SDCA Logistic Regression

- Evaluation

	- Accuracy
	- AUC
	- F1 Score

- Model Persistence

	- Saved as `student-model.zip`

- Prediction

	- Loaded at runtime in API

## Example Request

- **POST /api/predictions**

	- Add the student's performance data in JSON format like this:
		```
		{ 
			"studyHoursPerWeek": 12, 
			"attendanceRate": 85, 
			"previousGrade": 75, 
			"assignmentsCompleted": 8 
		}
		```
- **Response**

	- Example response from the server is something like this:
		```
		{ 
			"predictedPassed": true, 
			"probability": 0.9999999, 
			"message": "The student is likely to pass." 
		}
		```

## API Endpoints

- **POST**

	- `/api/predictions` -> Get prediction

- **GET**

	- `/api/predictions/history` -> Get prediction history

## Getting Started

- Clone the repository

	- `git clone https://github.com/wdopen-nk/student-performance-predictor.git`
	- `cd student-performance-predictor`

- Train the model
	
	- `dotnet run --project StudentPerformancePredictor.Trainer`
	- This generates `student-model.zip` which is used for training model later

- Add model to API

	- Copy `student-model.zip` into:

		- `StudentPerformance.Api/`

	- Set:
		
		- Right-click on `student-model.zip`, go to `Properties`
		- Set `Copy to Output Directory` to `Copy if newer`

- Run the API

	- `dotnet run --project StudentPerformancePredictor.Api`

- Open Swagger

	- `http://localhost:PORT/swagger` where `PORT` is the port of your original localhost

## How It Works

- User sends input data via API
- Controller maps input to model format
- ML model generates prediction
- Result is stored in database
- Response is returned to client

## License

- This project is open-source and available under the MIT License.