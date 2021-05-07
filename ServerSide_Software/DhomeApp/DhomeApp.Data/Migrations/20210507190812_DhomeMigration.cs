using Microsoft.EntityFrameworkCore.Migrations;

namespace DhomeApp.Data.Migrations
{
    public partial class DhomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCustomer = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idEmployee = table.Column<int>(type: "int", unicode: false, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    appointmentDate = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    valorization = table.Column<int>(type: "int", unicode: false, nullable: false),
                    status = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    idPaymentMethod = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dni = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    idCity = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idAccount = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Cellphone = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idDistrict = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Lastname = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Dni = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    idCity = table.Column<int>(type: "int", unicode: false, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Cellphone = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idSpecialty = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idDistrict = table.Column<int>(type: "int", unicode: false, nullable: false),
                    idAccount = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
