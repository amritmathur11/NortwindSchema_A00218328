namespace NortwindSchema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryID = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                        categoryDescription = c.String(),
                        picture = c.String(),
                    })
                .PrimaryKey(t => t.categoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        contactName = c.String(),
                        contactTitle = c.String(),
                        address = c.String(),
                        city = c.String(),
                        region = c.String(),
                        postalCode = c.String(),
                        country = c.String(),
                        phone = c.String(),
                        fax = c.String(),
                    })
                .PrimaryKey(t => t.customerID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        employeeID = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        firstName = c.String(),
                        title = c.String(),
                        titleOfCourtesy = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        hireDate = c.DateTime(nullable: false),
                        address = c.String(),
                        city = c.String(),
                        region = c.String(),
                        postalCode = c.String(),
                        country = c.String(),
                        homePhone = c.String(),
                        extention = c.String(),
                        photo = c.String(),
                        notes = c.String(),
                        reportsTo = c.String(),
                        photoPath = c.String(),
                    })
                .PrimaryKey(t => t.employeeID);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        territoryID = c.Int(nullable: false, identity: true),
                        territoryDescription = c.String(),
                        region_regionID = c.Int(),
                    })
                .PrimaryKey(t => t.territoryID)
                .ForeignKey("dbo.Regions", t => t.region_regionID)
                .Index(t => t.region_regionID);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        regionID = c.Int(nullable: false, identity: true),
                        regionDescription = c.String(),
                    })
                .PrimaryKey(t => t.regionID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        unitPrice = c.Single(nullable: false),
                        quantity = c.Single(nullable: false),
                        discount = c.Single(nullable: false),
                        product_productID = c.Int(),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.Products", t => t.product_productID)
                .Index(t => t.product_productID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productID = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        quantityPerLabel = c.Single(nullable: false),
                        unitPrice = c.Single(nullable: false),
                        unitsInStock = c.Single(nullable: false),
                        unitsOnOrder = c.Single(nullable: false),
                        reorderLevel = c.Single(nullable: false),
                        discontinues = c.String(),
                        category_categoryID = c.Int(),
                        supplier_supplierID = c.Int(),
                    })
                .PrimaryKey(t => t.productID)
                .ForeignKey("dbo.Categories", t => t.category_categoryID)
                .ForeignKey("dbo.Suppliers", t => t.supplier_supplierID)
                .Index(t => t.category_categoryID)
                .Index(t => t.supplier_supplierID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        supplierID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        contactName = c.String(),
                        contactTitle = c.String(),
                        address = c.String(),
                        city = c.String(),
                        region = c.String(),
                        postalCode = c.String(),
                        country = c.String(),
                        phone = c.String(),
                        fax = c.String(),
                        homepage = c.String(),
                    })
                .PrimaryKey(t => t.supplierID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderID = c.Int(nullable: false, identity: true),
                        dateTime = c.DateTime(nullable: false),
                        requiredDate = c.DateTime(nullable: false),
                        shippedDate = c.DateTime(nullable: false),
                        shipVia = c.String(),
                        freight = c.String(),
                        shipName = c.String(),
                        shipAddress = c.String(),
                        shipCity = c.String(),
                        shipRegion = c.String(),
                        shipPostalCode = c.String(),
                        shipCountry = c.String(),
                        customer_customerID = c.Int(),
                        employee_employeeID = c.Int(),
                        shipper_shipperID = c.Int(),
                    })
                .PrimaryKey(t => t.orderID)
                .ForeignKey("dbo.Customers", t => t.customer_customerID)
                .ForeignKey("dbo.Employees", t => t.employee_employeeID)
                .ForeignKey("dbo.Shippers", t => t.shipper_shipperID)
                .Index(t => t.customer_customerID)
                .Index(t => t.employee_employeeID)
                .Index(t => t.shipper_shipperID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        shipperID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        phone = c.String(),
                    })
                .PrimaryKey(t => t.shipperID);
            
            CreateTable(
                "dbo.TerritoryEmployees",
                c => new
                    {
                        Territory_territoryID = c.Int(nullable: false),
                        Employee_employeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Territory_territoryID, t.Employee_employeeID })
                .ForeignKey("dbo.Territories", t => t.Territory_territoryID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_employeeID, cascadeDelete: true)
                .Index(t => t.Territory_territoryID)
                .Index(t => t.Employee_employeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "shipper_shipperID", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "employee_employeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "customer_customerID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "product_productID", "dbo.Products");
            DropForeignKey("dbo.Products", "supplier_supplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "category_categoryID", "dbo.Categories");
            DropForeignKey("dbo.Territories", "region_regionID", "dbo.Regions");
            DropForeignKey("dbo.TerritoryEmployees", "Employee_employeeID", "dbo.Employees");
            DropForeignKey("dbo.TerritoryEmployees", "Territory_territoryID", "dbo.Territories");
            DropIndex("dbo.TerritoryEmployees", new[] { "Employee_employeeID" });
            DropIndex("dbo.TerritoryEmployees", new[] { "Territory_territoryID" });
            DropIndex("dbo.Orders", new[] { "shipper_shipperID" });
            DropIndex("dbo.Orders", new[] { "employee_employeeID" });
            DropIndex("dbo.Orders", new[] { "customer_customerID" });
            DropIndex("dbo.Products", new[] { "supplier_supplierID" });
            DropIndex("dbo.Products", new[] { "category_categoryID" });
            DropIndex("dbo.OrderDetails", new[] { "product_productID" });
            DropIndex("dbo.Territories", new[] { "region_regionID" });
            DropTable("dbo.TerritoryEmployees");
            DropTable("dbo.Shippers");
            DropTable("dbo.Orders");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Regions");
            DropTable("dbo.Territories");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
