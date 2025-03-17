# KCShoppingMallWebAPI

Technologies Used </br>
>C# </br>
>Visual Studio 2022 </br>
>.Net 8.0 </br>
>SQL Server Express 2019 </br>
>Entity FrameworkCore 9.0.3 </br>

Instruction to setup the app. </br>
1. Create a database in SQL Server Express 2019 by the name KCShoppingMall.</br>
2. Run the attached script in the email (KCShoppingMall.sql) on KCShoppingMall database created above.</br>
3. Fork or Clone the app in Visual Studio 2022 </br>
4. Update the app ConnectionStrings in the appsettings.json and appsettings.Development.json files, to make sure the app is pointing to the right instance of SQL Server.</br>
5. Run the app.</br></br>
6. Please execute the /Product/V1/GetProducts endpoint with the featured parameter being null or empty to auto create products records in the Database.
