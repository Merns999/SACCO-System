using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SACCO_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Admin_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Phone_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Admin_ID);
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "deposittype",
                columns: table => new
                {
                    Deposit_Type_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Deposit_Type_ID);
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Date_Of_Birth = table.Column<DateOnly>(type: "date", nullable: true),
                    Delete_Request = table.Column<sbyte>(type: "tinyint", nullable: true),
                    Membership_Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Occupation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Member_ID);
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Account_Number = table.Column<int>(type: "int", nullable: false),
                    Member_ID = table.Column<int>(type: "int", nullable: true),
                    Account_Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Lock_Status = table.Column<sbyte>(type: "tinyint", nullable: true),
                    Account_Type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Account_Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Last_TransactionTimestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Account_Number);
                    table.ForeignKey(
                        name: "account_ibfk_1",
                        column: x => x.Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "loan_application",
                columns: table => new
                {
                    Loan_Application_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Member_ID = table.Column<int>(type: "int", nullable: true),
                    Guarantor = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Type_Of_Loan = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Annual_Income = table.Column<int>(type: "int", nullable: true),
                    Loan_Period = table.Column<int>(type: "int", nullable: true),
                    Loan_Principle = table.Column<int>(type: "int", nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Application_Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Reason_For_Rejection = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Loan_Application_ID);
                    table.ForeignKey(
                        name: "loan_application_ibfk_1",
                        column: x => x.Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "shareholder",
                columns: table => new
                {
                    Shareholder_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Member_ID = table.Column<int>(type: "int", nullable: true),
                    Share_Count = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Shareholder_ID);
                    table.ForeignKey(
                        name: "shareholder_ibfk_1",
                        column: x => x.Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "delete_request",
                columns: table => new
                {
                    Delete_Request_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Account_Number = table.Column<int>(type: "int", nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Delete_Request_ID);
                    table.ForeignKey(
                        name: "delete_request_ibfk_1",
                        column: x => x.Account_Number,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "deposit",
                columns: table => new
                {
                    Deposit_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Account_Number = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Deposit_Type_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Transaction_Reference_Number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Transaction_Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Deposit_ID);
                    table.ForeignKey(
                        name: "deposit_ibfk_1",
                        column: x => x.Account_Number,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                    table.ForeignKey(
                        name: "deposit_ibfk_2",
                        column: x => x.Deposit_Type_ID,
                        principalTable: "deposittype",
                        principalColumn: "Deposit_Type_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "dividend",
                columns: table => new
                {
                    Dividend_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Account_Number = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Dividend_Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Dividend_Calculation_Method = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Dividend_ID);
                    table.ForeignKey(
                        name: "dividend_ibfk_1",
                        column: x => x.Account_Number,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "share_transfer",
                columns: table => new
                {
                    Transfer_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Sender_Member_ID = table.Column<int>(type: "int", nullable: false),
                    Receiver_Member_ID = table.Column<int>(type: "int", nullable: false),
                    Share_Count = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: true),
                    AccountNumber1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_share_transfer", x => x.Transfer_ID);
                    table.ForeignKey(
                        name: "FK_share_transfer_account_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                    table.ForeignKey(
                        name: "FK_share_transfer_account_AccountNumber1",
                        column: x => x.AccountNumber1,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                    table.ForeignKey(
                        name: "share_transfer_receiver_fk",
                        column: x => x.Receiver_Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "share_transfer_sender_fk",
                        column: x => x.Sender_Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "withdrawal",
                columns: table => new
                {
                    Withdrawal_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Account_Number = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Phone_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Transaction_Reference_Number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Transaction_Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Withdrawal_ID);
                    table.ForeignKey(
                        name: "withdrawal_ibfk_1",
                        column: x => x.Account_Number,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "dividend_payment",
                columns: table => new
                {
                    Dividend_Payment_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Dividend_ID = table.Column<string>(type: "varchar(255)", nullable: true),
                    Account_Number = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Dividend_Payment_ID);
                    table.ForeignKey(
                        name: "dividend_payment_ibfk_1",
                        column: x => x.Dividend_ID,
                        principalTable: "dividend",
                        principalColumn: "Dividend_ID");
                    table.ForeignKey(
                        name: "dividend_payment_ibfk_2",
                        column: x => x.Account_Number,
                        principalTable: "account",
                        principalColumn: "Account_Number");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "guarantor",
                columns: table => new
                {
                    Guarantor_ID = table.Column<int>(type: "int", nullable: false),
                    Loan_ID = table.Column<string>(type: "varchar(255)", nullable: true),
                    Member_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Guarantor_ID);
                    table.ForeignKey(
                        name: "guarantor_ibfk_1",
                        column: x => x.Member_ID,
                        principalTable: "member",
                        principalColumn: "Member_ID");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    Loan_ID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Loan_Application_ID = table.Column<string>(type: "varchar(255)", nullable: true),
                    Type_Of_Loan = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Annual_Income = table.Column<int>(type: "int", nullable: true),
                    Loan_Period = table.Column<int>(type: "int", nullable: true),
                    Loan_Principle = table.Column<int>(type: "int", nullable: true),
                    Compound_Interest = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Guarantor_ID = table.Column<int>(type: "int", nullable: true),
                    Loan_Status = table.Column<sbyte>(type: "tinyint", nullable: true),
                    Time_stamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Repayment_Schedule = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Last_Payment_Timestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Loan_ID);
                    table.ForeignKey(
                        name: "loan_ibfk_1",
                        column: x => x.Loan_Application_ID,
                        principalTable: "loan_application",
                        principalColumn: "Loan_Application_ID");
                    table.ForeignKey(
                        name: "loan_ibfk_2",
                        column: x => x.Guarantor_ID,
                        principalTable: "guarantor",
                        principalColumn: "Guarantor_ID");
                })
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "Member_ID",
                table: "account",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "Account_Number",
                table: "delete_request",
                column: "Account_Number");

            migrationBuilder.CreateIndex(
                name: "Account_Number1",
                table: "deposit",
                column: "Account_Number");

            migrationBuilder.CreateIndex(
                name: "Deposit_Type_ID",
                table: "deposit",
                column: "Deposit_Type_ID");

            migrationBuilder.CreateIndex(
                name: "Account_Number2",
                table: "dividend",
                column: "Account_Number");

            migrationBuilder.CreateIndex(
                name: "Account_Number3",
                table: "dividend_payment",
                column: "Account_Number");

            migrationBuilder.CreateIndex(
                name: "Dividend_ID",
                table: "dividend_payment",
                column: "Dividend_ID");

            migrationBuilder.CreateIndex(
                name: "Loan_ID",
                table: "guarantor",
                column: "Loan_ID");

            migrationBuilder.CreateIndex(
                name: "Member_ID1",
                table: "guarantor",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "Guarantor_ID",
                table: "loan",
                column: "Guarantor_ID");

            migrationBuilder.CreateIndex(
                name: "Loan_Application_ID",
                table: "loan",
                column: "Loan_Application_ID");

            migrationBuilder.CreateIndex(
                name: "Member_ID2",
                table: "loan_application",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_share_transfer_AccountNumber",
                table: "share_transfer",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_share_transfer_AccountNumber1",
                table: "share_transfer",
                column: "AccountNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_share_transfer_Receiver_Member_ID",
                table: "share_transfer",
                column: "Receiver_Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_share_transfer_Sender_Member_ID",
                table: "share_transfer",
                column: "Sender_Member_ID");

            migrationBuilder.CreateIndex(
                name: "Member_ID3",
                table: "shareholder",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "Account_Number4",
                table: "withdrawal",
                column: "Account_Number");

            migrationBuilder.AddForeignKey(
                name: "guarantor_ibfk_2",
                table: "guarantor",
                column: "Loan_ID",
                principalTable: "loan",
                principalColumn: "Loan_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "guarantor_ibfk_1",
                table: "guarantor");

            migrationBuilder.DropForeignKey(
                name: "loan_application_ibfk_1",
                table: "loan_application");

            migrationBuilder.DropForeignKey(
                name: "guarantor_ibfk_2",
                table: "guarantor");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "delete_request");

            migrationBuilder.DropTable(
                name: "deposit");

            migrationBuilder.DropTable(
                name: "dividend_payment");

            migrationBuilder.DropTable(
                name: "share_transfer");

            migrationBuilder.DropTable(
                name: "shareholder");

            migrationBuilder.DropTable(
                name: "withdrawal");

            migrationBuilder.DropTable(
                name: "deposittype");

            migrationBuilder.DropTable(
                name: "dividend");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "loan_application");

            migrationBuilder.DropTable(
                name: "guarantor");
        }
    }
}
