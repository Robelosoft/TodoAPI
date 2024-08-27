# Todo API

This is a simple RESTful API to manage a to-do list. It allows users to create, read, update, and delete to-do items. Each item has a title and description.

## Prerequisites

- .NET 5.0 or later
- MySQL Server
- Docker (optional)

## Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/todoapi.git
   ```
2. Navigate to the project directory:
   ```
   cd todoapi
   ```
3. Install the necessary packages:
   ```
   dotnet restore
   ```
4. Update the connection string in `appsettings.json` with your MySQL server details.

5. Run the application:
   ```
   dotnet run
   ```
   The API will start running at `https://localhost:5001`.

## Running the Tests

1. Navigate to the test project directory:
   ```
   cd TodoApi.Tests
   ```
2. Run the tests:
   ```
   dotnet test
   ```

## Docker

1. Build the Docker image:
   ```
   docker build -t todoapi .
   ```
2. Run the Docker container:
   ```
   docker run -p 5001:80 todoapi
   ```
   The API will start running at `http://localhost:5001`.

## API Endpoints

- GET `/api/todoitems`: Get all to-do items.
- GET `/api/todoitems/{id}`: Get a to-do item by ID.
- POST `/api/todoitems`: Create a new to-do item.
- PUT `/api/todoitems/{id}`: Update a to-do item.
- DELETE `/api/todoitems/{id}`: Delete a to-do item.

## License

This project is licensed under the MIT License.

Please replace `https://github.com/yourusername/todoapi.git` with your actual repository URL.

- Was it easy to complete the task using AI? It was Easy
- How long did task take you to complete? 1 hour
- Was the code ready to run after generation? What did you have to change to make it usable? I have todo some modifications with the unit test, and the connection string condifiguration.
- Which challenges did you face during completion of the task? Get the detail of the code
- Which specific prompts you learned as a good practice to complete the task? ask for the detailed code, for large projects it shows examples and code extracts, but it does not show the detail, you have to ask for it.
