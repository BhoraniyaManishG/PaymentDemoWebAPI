using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentDemoModels.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCardInfo_PaymentInfo_PaymentInfoId",
                table: "CreditCardInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCardInfo",
                table: "CreditCardInfo");

            migrationBuilder.RenameTable(
                name: "CreditCardInfo",
                newName: "PaymentStatusInfo");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCardInfo_PaymentInfoId",
                table: "PaymentStatusInfo",
                newName: "IX_PaymentStatusInfo_PaymentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentStatusInfo",
                table: "PaymentStatusInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatusInfo_PaymentInfo_PaymentInfoId",
                table: "PaymentStatusInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatusInfo_PaymentInfo_PaymentInfoId",
                table: "PaymentStatusInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentStatusInfo",
                table: "PaymentStatusInfo");

            migrationBuilder.RenameTable(
                name: "PaymentStatusInfo",
                newName: "CreditCardInfo");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentStatusInfo_PaymentInfoId",
                table: "CreditCardInfo",
                newName: "IX_CreditCardInfo_PaymentInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCardInfo",
                table: "CreditCardInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCardInfo_PaymentInfo_PaymentInfoId",
                table: "CreditCardInfo",
                column: "PaymentInfoId",
                principalTable: "PaymentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
