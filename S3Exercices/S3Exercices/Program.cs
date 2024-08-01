// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using S3Exercices.Models;
using System.Linq;

NorthwindContext nc = new NorthwindContext();

//Lister tous les Customers habitants dans une ville saisie au clavier.

//Console.Write("B1- recherche de client par ville : ");
//string ville = Console.ReadLine();

//var habitantsResults = from Customer c in nc.Customers
//                       where c.City == ville
//                       select new { c.CustomerId, c.ContactName };

//foreach (var result in habitantsResults) 
//{
//    Console.WriteLine(result.CustomerId + " : " +result.ContactName );
//}

//Afficher les produits de la catégorie Beverages et Condiments.
//Utilisez le lazy loading  (pas d’include !)

var categories = nc.Categories.Where(c => c.CategoryName == "Beverages" ||
                                      c.CategoryName == "Condiments")
                               .ToList();

/* foreach (var category in categories)
{
    Console.WriteLine($"{category.CategoryName} :");

    foreach (var product in category.Products)
    {
        Console.WriteLine($"  {product.ProductName}");
    }

    Console.WriteLine(); 
}*/

// 3.	Afficher les produits de la catégorie Beverages et Condiments.
// Utilisez le eager loading ! (avec include).  Le résultat est identique à la requête précédente.

var produits = nc.Categories.Where(c => c.CategoryName == "Beverages" ||
                                      c.CategoryName == "Condiments").Include( p=> p.Products).ToList();

/*foreach (var category in categories)
{
    Console.WriteLine($"{category.CategoryName} :");

    foreach (var product in category.Products)
    {
        Console.WriteLine($"  {product.ProductName}");
    }

    Console.WriteLine();
}*/

// 4.	Donnez pour un client donné saisi au clavier (LILAS par ex) la liste de ces commandes
// (de la plus récente à la plus ancienne) et qui ont été livrées ( il y a une date de livraison). 
/*Console.WriteLine("Nom du client : ");
string nameCustomer = Console.ReadLine();

var orders = from ord in nc.Orders
            where ord.CustomerId == nameCustomer
            orderby ord.OrderDate descending
            select new
            {
                ord.CustomerId,
                ord.OrderDate,
                ord.ShippedDate
            };

foreach(var order in orders)
{
    Console.WriteLine($"customer : {order.CustomerId}, orderDate :{order.OrderDate} schippedDate :{order.ShippedDate  }");
} */

//Afficher le total des ventes par produit (ID  produit -> Total) trié par ordre de numéro produit

var totalSell = from od in nc.OrderDetails
                group od by od.ProductId into sells
                orderby sells.Key
                select new
                {
                    sells.Key,
                    Total = sells.Sum(s => s.UnitPrice * s.Quantity)
                };

foreach(var se in totalSell)
{
    Console.WriteLine($"{se.Key} ===> {se.Total}");
}

// 6.Afficher tous les employés (leur nom) qui ont sous leur responsabilité la région « Western »

var empResp = from emp in nc.Employees
              where emp.Territories.Any(t=> t.Region.RegionDescription == "Western")
              select emp;

Console.WriteLine("Employees qui ont sous leur responsabilité la region western:");
foreach(var emp in empResp)
{
    Console.WriteLine($"    {emp.FirstName} {emp.LastName}");
}

// 7.Quels sont les territoires gérés par le supérieur de « Suyama Michael »
var territories = from t in nc.Territories
                  where t.Employees.Any(e => e.InverseReportsToNavigation
                                   .Any(e2 => (e2.FirstName == "Michael" && e2.LastName== "suyama")))
                  select t;

Console.WriteLine("Territories geres par le superieur de Michael :" );
foreach(var t in territories)
{
    Console.WriteLine($"    {t.TerritoryDescription}");
}

// C-UPDATE 
var clients = from c in nc.Customers
              select c;

Console.WriteLine("Liste des clients : ");
foreach(var client in clients)
{
    client.CompanyName = $"{client.CompanyName.ToUpper()}";

}
nc.SaveChanges();

foreach (var client in clients)
{
    Console.WriteLine($"    {client.CompanyName}");

}

// D-AJOUT
Console.WriteLine("Entrez le nom de la catégorie : ");
var categorie = Console.ReadLine();

if(string.IsNullOrEmpty(categorie))
{
    Console.WriteLine("Categorie vide");
    return;
}

Category new_cat = new ()
{
    CategoryName = categorie
};

nc.Categories.Add(new_cat);

nc.SaveChanges();

var categoriesL = nc.Categories.ToList();

foreach (var c in categoriesL)
{
    Console.WriteLine($"    {c.CategoryName}");
}

// E-DELETE
Console.WriteLine("Entrez le nom de la catégorie à supprimer: ");
var nameCat = Console.ReadLine();

Category? catFinded = nc.Categories.Where(c => c.CategoryName == nameCat).FirstOrDefault();

if (catFinded == null)
{
    Console.WriteLine("Categorie non trouvée");
    return;
}

nc.Categories.Remove(catFinded);
nc.SaveChanges();
categoriesL = nc.Categories.ToList();
foreach (var c in categoriesL)
{
    Console.WriteLine($"    {c.CategoryName}");
}

// 3.	Supprimez un employé et réassignez toutes ses commandes 
Console.WriteLine("entrez l'id de l'employé à supprimer : ");
var idEmp = Int32.Parse(Console.ReadLine());

Console.WriteLine("entrez l'id de l'employeur à assigner : ");
var idEmpNew = Int32.Parse(Console.ReadLine());

var employeToRemove = nc.Employees.Where(c => c.EmployeeId == idEmp).FirstOrDefault();
var employeToAssigne = nc.Employees.FirstOrDefault(c => c.EmployeeId == idEmpNew);

if (employeToRemove == null)
{
    Console.WriteLine("Employe à supprimer inexistant");
    return;
}
Console.WriteLine($"nom de l'employé à supprimé : {employeToRemove.FirstName} {employeToRemove.LastName}");
var old_commandes = employeToRemove.Orders;

nc.Employees.Remove(employeToRemove);

nc.SaveChanges();

if (employeToAssigne == null)
{
    Console.WriteLine("Employe à assigner  inexistant");
    return;
}

foreach (var order in old_commandes)
{
    employeToAssigne.Orders.Add(order);
}


nc.SaveChanges();

var reassignedOrders = nc.Orders.Where(o => o.EmployeeId == idEmpNew).ToList();
Console.WriteLine($"nom de l'employé assigné : {employeToAssigne.FirstName} {employeToAssigne.LastName}");
Console.WriteLine($"Nombre de commandes réassignées : {reassignedOrders.Count}");

