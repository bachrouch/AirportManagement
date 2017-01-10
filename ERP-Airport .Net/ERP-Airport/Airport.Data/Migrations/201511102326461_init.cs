namespace Airport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "airline",
                c => new
                    {
                        idAirline = c.Int(nullable: false, identity: true),
                        localAddress = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idAirline);
            
            CreateTable(
                "airplane",
                c => new
                    {
                        idAirplane = c.Int(nullable: false, identity: true),
                        label = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        idTrack = c.Int(nullable: false),
                        number = c.Int(nullable: false),
                        state = c.Boolean(nullable: false),
                        airline_idAirline = c.Int(),
                        numberTrack = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAirplane)
                .ForeignKey("airline", t => t.airline_idAirline)
                .Index(t => t.airline_idAirline);
            
            CreateTable(
                "flight",
                c => new
                    {
                        idFlight = c.Int(nullable: false, identity: true),
                        arrivalTime = c.String(maxLength: 255, storeType: "nvarchar"),
                        classType = c.String(maxLength: 255, storeType: "nvarchar"),
                        flightState = c.String(maxLength: 255, storeType: "nvarchar"),
                        price = c.Single(nullable: false),
                        startTime = c.String(maxLength: 255, storeType: "nvarchar"),
                        airline_idAirline = c.Int(),
                        destination = c.String(maxLength: 255, storeType: "nvarchar"),
                        arrivalCity = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idFlight)
                .ForeignKey("airline", t => t.airline_idAirline)
                .Index(t => t.airline_idAirline);
            
            CreateTable(
                "flightinf",
                c => new
                    {
                        idAirport = c.Int(nullable: false),
                        idFlight = c.Int(nullable: false),
                        type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idAirport, t.idFlight })
                .ForeignKey("airport", t => t.idAirport, cascadeDelete: true)
                .ForeignKey("flight", t => t.idFlight, cascadeDelete: true)
                .Index(t => t.idAirport)
                .Index(t => t.idFlight);
            
            CreateTable(
                "airport",
                c => new
                    {
                        idAirport = c.Int(nullable: false, identity: true),
                        city = c.String(maxLength: 255, storeType: "nvarchar"),
                        name = c.String(unicode: false),
                        country = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idAirport);
            
            CreateTable(
                "reservation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        arrivalDate = c.String(maxLength: 255, storeType: "nvarchar"),
                        departureDate = c.String(maxLength: 255, storeType: "nvarchar"),
                        reservationState = c.Int(),
                        customer_id = c.String(maxLength: 128, storeType: "nvarchar"),
                        flight_idFlight = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("flight", t => t.flight_idFlight)
                .ForeignKey("user", t => t.customer_id)
                .Index(t => t.customer_id)
                .Index(t => t.flight_idFlight);
            
            CreateTable(
                "user",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        grade = c.String(maxLength: 255, storeType: "nvarchar"),
                        nature = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateRegistration = c.DateTime(precision: 0),
                        score = c.Int(),
                        airline_idAirline = c.Int(),
                        sexe = c.String(unicode: false),
                        addressMail = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        password = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        username = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("airline", t => t.airline_idAirline)
                .Index(t => t.airline_idAirline);
            
            CreateTable(
                "claim",
                c => new
                    {
                        idClaim = c.Int(nullable: false, identity: true),
                        editionDate = c.String(maxLength: 255, storeType: "nvarchar"),
                        subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        text = c.String(maxLength: 255, storeType: "nvarchar"),
                        customer_id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idClaim)
                .ForeignKey("user", t => t.customer_id)
                .Index(t => t.customer_id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "comment",
                c => new
                    {
                        idComment = c.Int(nullable: false, identity: true),
                        editionDate = c.DateTime(precision: 0),
                        text = c.String(maxLength: 255, storeType: "nvarchar"),
                        customer_id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.idComment)
                .ForeignKey("user", t => t.customer_id)
                .Index(t => t.customer_id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        user_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("user", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        IdentityRole_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("user", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "stopover",
                c => new
                    {
                        idStopOver = c.Int(nullable: false, identity: true),
                        arrivalTime = c.DateTime(precision: 0),
                        startTime = c.DateTime(precision: 0),
                        flight_idFlight = c.Int(),
                    })
                .PrimaryKey(t => t.idStopOver)
                .ForeignKey("flight", t => t.flight_idFlight)
                .Index(t => t.flight_idFlight);
            
            CreateTable(
                "employee",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        addressMail = c.String(maxLength: 255, storeType: "nvarchar"),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        grade = c.String(maxLength: 255, storeType: "nvarchar"),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        salary = c.Single(nullable: false),
                        idEmployee = c.Int(nullable: false),
                        state = c.String(maxLength: 255, storeType: "nvarchar"),
                        hireDate = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("stopover", "flight_idFlight", "flight");
            DropForeignKey("reservation", "customer_id", "user");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "user");
            DropForeignKey("dbo.IdentityUserLogins", "user_Id", "user");
            DropForeignKey("comment", "customer_id", "user");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "user");
            DropForeignKey("claim", "customer_id", "user");
            DropForeignKey("user", "airline_idAirline", "airline");
            DropForeignKey("reservation", "flight_idFlight", "flight");
            DropForeignKey("flightinf", "idFlight", "flight");
            DropForeignKey("flightinf", "idAirport", "airport");
            DropForeignKey("flight", "airline_idAirline", "airline");
            DropForeignKey("airplane", "airline_idAirline", "airline");
            DropIndex("stopover", new[] { "flight_idFlight" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogins", new[] { "user_Id" });
            DropIndex("comment", new[] { "customer_id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("claim", new[] { "customer_id" });
            DropIndex("user", new[] { "airline_idAirline" });
            DropIndex("reservation", new[] { "flight_idFlight" });
            DropIndex("reservation", new[] { "customer_id" });
            DropIndex("flightinf", new[] { "idFlight" });
            DropIndex("flightinf", new[] { "idAirport" });
            DropIndex("flight", new[] { "airline_idAirline" });
            DropIndex("airplane", new[] { "airline_idAirline" });
            DropTable("dbo.IdentityRoles");
            DropTable("employee");
            DropTable("stopover");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("comment");
            DropTable("dbo.IdentityUserClaims");
            DropTable("claim");
            DropTable("user");
            DropTable("reservation");
            DropTable("airport");
            DropTable("flightinf");
            DropTable("flight");
            DropTable("airplane");
            DropTable("airline");
        }
    }
}
