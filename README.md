# Notebook

Simple Windows Forms project.

### Main Functions of App:

  - Containing general information about people - name, last name, birthday, phone, country.
  - Showing info from a database in a table.
  - Editing information of each person.
  - Searching people by last name, birthday, country.
  - Showing notification about near birthdays.
  
### Configurations

  - Database connection string - ../Notebook/Notebook.Core/App.config
    Example:
    
  ```sh
  ...
        <connectionStrings>
		<add name="NotebookDbConnection" connectionString="server=.\SQLEXPRESS;Initial Catalog=NotebookMasterDb; Integrated Security=true;" providerName="System.Data.SqlClient"/>
	</connectionStrings>
  ...
  ```
  
  - Period of checking near birthdays - ../Notebook/Notebook.Forms/App.config
    Example:
  
  ```sh
  ...
        <appSettings>
		<add key="checkBirthdayPeriodMs" value="10000"/> <!-- Milliseconds -->
	</appSettings>
  ...
  ```
  
### Database Migration

  - Ensure that you set correct connection string of a database.
  - Select "Notebook.Core" project as "Default project" in Package Manager Console.
  - Enter "update-database" command.
  
Empty database tables will be seeded default data during migrations.
