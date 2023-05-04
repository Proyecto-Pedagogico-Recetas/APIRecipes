# COOK-SMART

We are a page of cooking recipes, described by teachers so that our students and users can learn their recipes. We indicate ingredients with their quantities, allergens and method of preparation. All separated by categories. At the same time, the ingredients of the recipes selected by the teachers for their elaboration are all collected in a total list of ingredients that the administrator receives. the administrator receives these individual lists plus the total list of all these lists and can edit this last list. This one is designed for the purchase of ingredients, so you can edit it if there are ingredients that you may have in stock. The admin is the one who edits the users.

## Technology stack used in Back-end:
* **Microsoft Visual Studio** - [Sitio web oficial](https://visualstudio.microsoft.com/es/)
* **C#** - [Sitio web oficial](https://learn.microsoft.com/es-es/dotnet/csharp/)
* **ASP.NET Core 6** - [Sitio web oficial](https://dotnet.microsoft.com/es-es/download/dotnet/6.0)
* **Entity Framework 7** - [Sitio web oficial](https://learn.microsoft.com/es-es/ef/core/what-is-new/ef-core-7.0/plan)
* **SQL Server Management Studio 18** - [Sitio web oficial](https://learn.microsoft.com/es-es/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16&viewFallbackFrom=sql-server-ver18)


## Installation:
Create a directory on your computer to store the project:
* Run ***$ git clone https://github.com/Proyecto-Pedagogico-Recetas/APIRecipes.git***
* Run ***$ git clone https://github.com/Proyecto-Pedagogico-Recetas/Frontend.git***


## How to use it? 
In the project directory run:
* To install the dependencies ***$ npm install***
* To install react router ***$ npm install react-router-dom@6***
* To install axios ***$ npm install axios***
* To activate the server and keep this terminal open ***$ npm run dev***


## Methodologies:
*Methodology Agile with Scrum
* Mob Programming
* Pair Programming
* Solo Programming


## Screenshots:
### This is our BBDD:
 ![image (8)](https://user-images.githubusercontent.com/117833121/235253464-66373f36-8194-4cfa-80a7-569f6e0b02b1.png)

## Media queries:

* insert into RolType

([Name], [Description],IsActive)

values
('Administrador','Acceso a todos los métodos', 1)

('Operator','Postea y lista recetas', 1) 

('Operator','Postea y lista recetas', 1) 


* select * from RolType

* insert into Rol_Authorization

(IdRol, IdAuthorization, IsActive)


* insert into Users

(IdRol, [UserName], InsertDate, IsActive, EncryptedPassword, EncryptedToken, TokenExpireDate)

values

(2, 'Maria', GETDATE(), 1, '$2a$11$F62mpHhfDZQJ65p50Lzz0OgzMnu3fZXcZWTbDjdMl.UrYcJqqG6k6', '', GETDATE())

(1, 'Juan', GETDATE(), 1, '$2a$11$ESGTCdOxoR8oBsDj1OB9m.EmSJ3KTXf.Z873KzubFOtC16dno/0Cq', '', GETDATE())


* select * from Users


* insert into Alergens

([Name], [IsActive], [IsChecked])

values

('Gluten', 1 , 0 ),

('Lactosa', 1 , 0 )

('Frutos secos', 1, 0)


* select * from Alergens

* insert into Categories

([Name])

values

('Carne'),

('Pescado'),

('Pasta'),

('Arroz')


* select * from Categories



* DROP TABLE RolType  (borrar tabla)



## Tests:


* RecipeItemTest: This test file is to verify if the ValidateRecipe method of the RecipeItemService class works correctly. First, three RecipeItem objects (recipeA, recipeB, and recipeC) with different property values are created. Then, the ValidateRecipe method of the RecipeItemService class is called for each of these objects. Finally, the check or assertion is made that each of these recipe objects returns the expected value in the ValidateRecipe method, using the Assert.AreEqual assertion method. If any of the assertions fail, the custom error message is displayed on the console. In summary, this test file verifies if the ValidateRecipe method of the RecipeItemService class works correctly and produces the expected results for each RecipeItem object.

* OrderItemTest: This code shows an example of a unit test for the OrderItem class. The OrderItemTest class has a ValidateOrderTest method, which is responsible for testing the validity of the OrderItem instance. First, three instances of OrderItem are created with different values for their properties. Then the ValidateOrderA methods are commented out, leaving only the test objects, but the validation code is commented out. Finally, the Assert.AreEqual methods are used to verify that the validation result is true. It is important to mention that the commented code found within the OrderItemService.ValidateOrderA method and the OrderItemService class is a possible implementation of OrderItem object validation.

* UserItemTest: This code shows an example of a unit test using the Microsoft .NET unit testing framework, known as MSTest. The test is performed on the UserItemTest class, and the test method is called ValidateUserTest. The ValidateUserTest method uses three instances of the UserItem class, userA, userB, and userC, and configures them with specific values for each property of the UserItem class. Then, each user is attempted to be validated by calling the ValidateUser method of the UserService class, which is defined in a separate file not included in this code. However, it appears that this method is not used in this implementation since it is commented out in the //Act section.

* Finally, three assertions are included using the Assert.AreEqual method to verify that the users are valid. However, these assertions are also commented out in the //Assert section, suggesting that this particular test has been disabled or not fully implemented.


![Test-Back](https://user-images.githubusercontent.com/117833121/235530906-dbbab2c3-47b4-4258-96eb-29da1ac24bdb.JPG)


## Contributors:
[<img src="https://avatars.githubusercontent.com/u/117833586?v=4" width=115><br><sub> Ainhoa Cala </sub>](https://github.com/acalabustos)| [<img src="https://avatars.githubusercontent.com/u/117833121?v=4" width=115><br><sub> Jennifer Cordero </sub>](https://github.com/JenniferCorderoR) |[<img src="https://avatars.githubusercontent.com/u/117834632?v=4" width=115><br><sub> Anyi Flores </sub>](https://github.com/Anyi79) |[<img src="https://avatars.githubusercontent.com/u/117834265?v=4" width=115><br><sub> Celia García </sub>](https://github.com/CeliaGC) |[<img src="https://avatars.githubusercontent.com/u/117834229?v=4" width=115><br><sub> RoseMary Rengel </sub>](https://github.com/rrengelj) |
| :---: | :---: | :---: |  :---: |  :---: |

## Next steps:
------------------------------------------------------------------------------------------------------------------------------

