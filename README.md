[![Module Logo](https://github.com/BrunoFaria-DEV/DOCUMENTS/raw/main/MODULE.png)](https://github.com/BrunoFaria-DEV/DOCUMENTS)
<h1 align="center">Product Categorization</h1>
<p align="center"><i>Repository for project versioning and documentation of the ProductCategory project.</i></p>

This project is suitable for creating a new project or for use in another existing application.

##  About this project

This module is a small product categorization system, which contains:
- Categorization
- Pagination
- Search
- Filtering

### Technologies
<p display="inline-block">
  <img width="48" src="https://www.freeiconspng.com/uploads/c-logo-icon-18.png" alt="csharp-logo"/>
  <img width="48" src="https://upload.wikimedia.org/wikipedia/commons/d/d0/Blazor.png" alt="blazor-logo"/>
</p>
                                                                                                  
### Development Tools

<p display="inline-block">
  <img width="48" src="https://static.wikia.nocookie.net/logopedia/images/e/ec/Microsoft_Visual_Studio_2022.svg" alt="vs-logo"/>
  <img width="48" src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Visual_Studio_Code_1.35_icon.svg/2048px-Visual_Studio_Code_1.35_icon.svg.png" alt="vscode-logo"/>
</p>

## Running
Manage migrations:
```
dotnet ef migrations add InitialCreate --project .\ProdutoCategory.Data\ --startup-project .\ProductCategory.API\
```
Run the generated migrations:
```
dotnet ef database update --project .\ProdutoCategory.Data\ --startup-project .\ProductCategory.API\
```
Run the local server:
```
dotnet run
```