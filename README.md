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


* RecipeItemTest:
Este archivo de prueba es para verificar si el método ValidateRecipe
de la clase RecipeItemService funciona correctamente.
Primero, se crean tres objetos RecipeItem (recipeA, recipeB y recipeC)
con   diferentes   valores   de   propiedad.   Luego,   se   llama   al   método
ValidateRecipe de la clase RecipeItemService para cada uno de estos
objetos.
Finalmente, se realiza la comprobación o aserción de que cada uno de
estos   objetos   recipe   devuelve   el   valor   esperado   en   el   método
ValidateRecipe, utilizando el método de aserción Assert.AreEqual. Si
alguna de las aserciones falla, el mensaje de error personalizado se
muestra en la consola.
En   resumen,   este   archivo   de   prueba   verifica   si   el   método
ValidateRecipe de la clase RecipeItemService funciona correctamente
y produce los resultados esperados para cada objeto RecipeItem.

* OrderItemTest:
Este código muestra un ejemplo de unit test para la clase OrderItem. 
La   clase   OrderItemTest   tiene   un   método   ValidateOrderTest,   que   se
encarga de probar la validez de la instancia de OrderItem. Primero, se
crean   tres   instancias   de   OrderItem   con   diferentes   valores   para   sus
propiedades.   Luego   se   comentan   los   métodos   ValidateOrderA   y   se
dejan los objetos de las pruebas, pero se deja comentado el código de
la validación. Finalmente, se usan los métodos Assert.AreEqual para
verificar que el resultado de la validación sea verdadero.
Es importante mencionar que el código comentado que se encuentra
dentro   del   método   OrderItemService.ValidateOrderA   y   la   clase
OrderItemService es una posible implementación de la validación de
un objeto OrderItem.

* UserItemTest:
Este código muestra un ejemplo de una prueba unitaria utilizando el
marco de pruebas unitarias de Microsoft .NET, conocido como MSTest.
La prueba se realiza en la clase UserItemTest, y el método de prueba
se llama ValidateUserTest.
El   método   ValidateUserTest   utiliza   tres   instancias   de   la   clase
UserItem,   userA,   userB,   y   userC,   y   los   configura   con   valores
específicos   para   cada   propiedad   de   la   clase   UserItem.   Luego   se
intenta validar cada usuario llamando al método ValidateUser de la
clase UserService, el cual se define en un archivo diferente que no se
incluye en este código. Sin embargo, parece que este método no se
utiliza   en   esta   implementación,   ya   que   está   comentado   en   la
sección //Act.

Finalmente,   se   incluyen   tres   afirmaciones   utilizando   el   método
Assert.AreEqual   para   verificar   que   los   usuarios   son   válidos.   Sin
embargo,   estas   afirmaciones   también   están   comentadas   en   la
sección //Assert, lo que sugiere que esta prueba en particular se ha 
desactivado o no se ha implementado completamente.


![Test-Back](https://user-images.githubusercontent.com/117833121/235530906-dbbab2c3-47b4-4258-96eb-29da1ac24bdb.JPG)


## Contributors:
[<img src="https://avatars.githubusercontent.com/u/117833586?v=4" width=115><br><sub> Ainhoa Cala </sub>](https://github.com/acalabustos)| [<img src="https://avatars.githubusercontent.com/u/117833121?v=4" width=115><br><sub> Jennifer Cordero </sub>](https://github.com/JenniferCorderoR) |[<img src="https://avatars.githubusercontent.com/u/117834632?v=4" width=115><br><sub> Anyi Flores </sub>](https://github.com/Anyi79) |[<img src="https://avatars.githubusercontent.com/u/117834265?v=4" width=115><br><sub> Celia García </sub>](https://github.com/CeliaGC) |[<img src="https://avatars.githubusercontent.com/u/117834229?v=4" width=115><br><sub> RoseMary Rengel </sub>](https://github.com/rrengelj) |
| :---: | :---: | :---: |  :---: |  :---: |

## Next steps:
------------------------------------------------------------------------------------------------------------------------------

