# TeaDistributor

TeaDistributor is a web application designed to manage and distribute tea items efficiently. The application allows users to manage tea inventory, regions, suppliers, and types, providing a comprehensive solution for tea businesses.

## Features

- **Tea Item Management**: Add, edit, and delete tea items.
- **Supplier Management**: Keep track of suppliers for your tea inventory.
- **Region Management**: Organize and categorize teas by their region of origin.
- **Type Management**: Define and manage tea types (e.g., Green, Black, Herbal).
- **User-Friendly Interface**: Intuitive design with dropdown menus for seamless interaction.

## Technologies Used

- **Frontend**: Razor Pages, Bootstrap for responsive design
- **Backend**: ASP.NET Core MVC (C#)
- **Database**: Microsoft SQL Server with Entity Framework Core
- **Logging**: Integrated logging for debugging and application monitoring

## Installation

### Prerequisites
- .NET 6.0 or later
- Microsoft SQL Server
- Visual Studio 2022 (or a similar IDE)

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/TeaDistributor.git
   ```
2. Navigate to the project directory:
   ```bash
   cd TeaDistributor
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=TeaDb;User Id=your-username;Password=your-password;"
   }
   ```
5. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
6. Run the application:
   ```bash
   dotnet run
   ```

## Usage

1. Navigate to the application in your browser (default: `http://localhost:5000`).
2. Use the menu to manage tea items, suppliers, regions, and types.
3. Add new tea items by filling out the form and selecting relevant dropdown options for type, region, and supplier.
4. Edit or delete existing tea items as needed.

## Contributing

Contributions are welcome! If you find a bug or have a feature request, please open an issue or submit a pull request.

### Steps to Contribute
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes and push the branch to your fork.
   ```bash
   git commit -m "Description of changes"
   git push origin feature-name
   ```
4. Open a pull request against the main repository.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

For questions or support, please contact [your-email@example.com].
