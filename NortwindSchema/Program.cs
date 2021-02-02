using NortwindSchema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NortwindSchema
{
    class Program
    {
        static void Main(string[] args)
        {
            NortwindDbContext db = new NortwindDbContext();
            Category category = new Category()
            {
                categoryID = 1,
                categoryName = "Drink",
                categoryDescription = "Drink Category description",
                picture = ""
            };
            db.Categories.Add(category);

            Category category2 = new Category()
            {
                categoryID = 2,
                categoryName = "Fast Food",
                categoryDescription = "Fast Food Category description",
                picture = ""
            };
            db.Categories.Add(category2);

            Supplier supplier = new Supplier()
            {
                supplierID = 1,
                companyName = "Acme Corporation",
                contactName = "John Smith",
                contactTitle = "Mr",
                address = "Address 1",
                city = "London",
                region = "New Street",
                postalCode = "GB 125",
                country = "United Kingdom",
                phone = "009912312312",
                fax = "FAX 021312321",
                homepage = "homepage"
            };
            db.Suppliers.Add(supplier);

            Supplier supplier2 = new Supplier()
            {
                supplierID = 2,
                companyName = "Sumair & Sons",
                contactName = "Sumair Chaudhary",
                contactTitle = "Mr",
                address = "Address 1",
                city = "Birmingham",
                region = "New Street",
                postalCode = "GB 125",
                country = "United Kingdom",
                phone = "0041231212312",
                fax = "FAX 45442342321",
                homepage = "homepage Content"
            };
            db.Suppliers.Add(supplier2);

            Shipper shipper = new Shipper()
            {
                shipperID = 1,
                companyName = "Fed Ex",
                phone = "034123213123"
            };
            db.Shippers.Add(shipper);

            Shipper shipper2 = new Shipper()
            {
                shipperID = 2,
                companyName = "John Shipping & Co",
                phone = "00443213123"
            };
            db.Shippers.Add(shipper2);

            Region region = new Region()
            {
                regionID = 1,
                regionDescription = "Region 1 Description"
            };
            db.Regions.Add(region);

            Region region2 = new Region()
            {
                regionID = 2,
                regionDescription = "Region 2 Description"
            };
            db.Regions.Add(region2);

            Territory territory = new Territory()
            {
                territoryID = 1,
                territoryDescription = "Territory 1 Description",
                region = region
            };
            db.Territories.Add(territory);

            Territory territory2 = new Territory()
            {
                territoryID = 2,
                territoryDescription = "Territory 2 Description",
                region = region2
            };
            db.Territories.Add(territory2);

            List<Territory> territories = new List<Territory>();
            territories.Add(territory);
            territories.Add(territory2);

            Employee[] employees = new Employee[5];
            for (int i=1; i<=5; i++)
            {
                employees[i-1] = new Employee()
                {
                    employeeID = i,
                    firstName = "John",
                    lastName = "Doe " + i,
                    title = "Mr",
                    titleOfCourtesy = "Mr",
                    birthDate = DateTime.Now.AddYears(-25 + i),
                    hireDate = DateTime.Now.AddDays(-i),
                    address = "address " + i,
                    city = "city " + i,
                    region = "region " + i,
                    postalCode = "postal code " + i,
                    country = "country " + i,
                    homePhone = "homephone " + i,
                    extention = "extention " + i,
                    photo = "",
                    notes = "notes " + i,
                    reportsTo = "report " + i,
                    photoPath = "C://Folder" + i,
                    territories  = territories

                };
                db.Employees.Add(employees[i-1]);
            }

            Customer[] customers = new Customer[5];
            for (int i = 1; i <= 5; i++)
            {
                customers[i - 1] = new Customer()
                {
                    customerID = i,
                    companyName = "Acme Corporation " + i,
                    contactName = "Ronnie O Sullivan " + i,
                    contactTitle = "Mr",
                    address = "address " + i,
                    city = "city " + i,
                    region = "region " + i,
                    postalCode = "postal code " + i,
                    country = "country " + i,
                    phone = "homephone " + i,
                    fax = "fax " + i
                };
                db.Customers.Add(customers[i - 1]);
            }

            Product[] products = new Product[5];
            for (int i = 1; i <= 5; i++)
            {
                products[i - 1] = new Product()
                {
                    productID = i,
                    productName = "Product " + i,
                    category = category,
                    supplier = supplier,
                    quantityPerLabel = 10 + i,
                    unitPrice = 100 + i,
                    unitsInStock = 10,
                    unitsOnOrder = 10,
                    reorderLevel = 100 + i,
                    discontinues = ""
                };
                db.Products.Add(products[i - 1]);
            }

            Order[] orders = new Order[5];
            for (int i = 1; i <= 5; i++)
            {
                orders[i - 1] = new Order()
                {
                    orderID = i,
                    customer = customers[i-1],
                    employee = employees[i-1],
                    orderDate = DateTime.Now.AddHours(-i),
                    requiredDate = DateTime.Now.AddHours(-i),
                    shippedDate = DateTime.Now.AddHours(-i),
                    shipVia = "Bike",
                    freight = "freight Details",
                    shipName = "Honda Bike " + i,
                    shipAddress = "address " + i,
                    shipCity = "city " + i,
                    shipRegion = "region " + i,
                    shipPostalCode = "postal code " + i,
                    shipCountry = "country " + i
                };
                db.Orders.Add(orders[i - 1]);
            }

            OrderDetail[] orderDetails = new OrderDetail[5];
            for (int i = 1; i <= 5; i++)
            {
                orderDetails[i - 1] = new OrderDetail()
                {
                    orderID = i,
                    product = products[i-1],
                    unitPrice = 10 + i,
                    quantity = i + 1,
                    discount = 5 + i
                };
                db.OrderDetails.Add(orderDetails[i - 1]);
            }
            db.SaveChanges();
            Console.WriteLine("Data Saved Successfully");
            Console.ReadLine();

        }
    }
}
