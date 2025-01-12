# TEST Guest API Documentation

## How to Run the Project in Visual Studio

1. **Clone the repository** to your local machine using the command:
    ```bash
    git clone https://github.com/pareshs12/TEEG.git
    ```
2. **Open the `TEEG` folder** in **Visual Studio**.
3. Navigate to the project file located at:
    ```
    TEEG/TestGuestApp.API/TestGuestApp.API.csproj
    ```
4. Right-click on the `TestGuestApp.API` project in **Solution Explorer** and select:
    ```
    Set as Startup Project
    ```
5. **Restore the NuGet packages** by going to the **Tools** menu, selecting **NuGet Package Manager**, and clicking **Manage NuGet Packages for Solution**. Ensure all required packages are installed.
6. **Run the project** by pressing `F5` or clicking the **Start** button in Visual Studio.
7. The API should launch in your default browser at a URL similar to:
    ```
    https://localhost:7269
    ```
8. Access the **Swagger UI** for testing endpoints by navigating to:
    ```
    https://localhost:7269/swagger 
    ```
9. Log files are created in TestGuestApp.API folder in the Repo.

## Assumptions Made

1. The project is built on **.NET 6** or higher.
2. The **database** is in-memory for simplicity, no persistent storage is used.
3. The API endpoint **AddPhone** only takes a **single phone number** along with the **GuestId**.
4. The **phone number validation** ensures the number works with internal numbers with a country code (via regex validation).
5. The **API does not include security mechanisms** like authentication or authorization.
6. The Title Field as been added with  my assumations with follwoing titles"Mr,Ms, Mrs, Dr, Prof, Other".

## Challenges Faced and How They Were Addressed

1. **Phone Number Validation**: The challenge was ensuring that the phone number validation pattern works for various international formats. This was handled using a **FluentValidation** rule with a regular expression: `^\+?[1-9]\d{1,14}$` to validate the phone number format.
2. **CQRS Implementation**: Implementing the **CQRS pattern** involved separating command and query responsibilities. This required organizing the logic into distinct layers (Application, Domain, Infrastructure) and leveraging **MediatR** to handle requests.

## Future Improvements

1. **Persistent Database**: Replace the in-memory database with a real database such as **SQL Server** or **PostgreSQL** for persistence.
2. **Authentication and Authorization**: Introduce **JWT-based authentication** and **role-based authorization** to secure the API.
3. **Unit Testing**: Write **unit tests** for the application using a test framework (e.g., **xUnit** or **NUnit**) and mock dependencies where needed.
4. **Error Handling and Logging**: Enhance **error handling** to include more detailed responses and implement better logging for diagnostics.

