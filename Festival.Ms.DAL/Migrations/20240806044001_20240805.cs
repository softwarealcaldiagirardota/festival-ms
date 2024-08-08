using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Festival.Ms.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _20240805 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipationCompany",
                table: "ParticipationCompany");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "vote");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "vote",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IdQuestion",
                table: "vote",
                newName: "id_question");

            migrationBuilder.RenameColumn(
                name: "IdParticipationCompany",
                table: "vote",
                newName: "id_participation_company");

            migrationBuilder.RenameColumn(
                name: "IdAnswer",
                table: "vote",
                newName: "id_answer");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "vote",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "vote",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ParticipationCompany",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "DeviceParticipation",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "votes_pk",
                table: "vote",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "participation_company_pk",
                table: "ParticipationCompany",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_vote",
                table: "vote",
                columns: new[] { "id_answer", "id_question", "id_participation_company" });

            migrationBuilder.CreateIndex(
                name: "IX_company_participation",
                table: "ParticipationCompany",
                columns: new[] { "IdCompany", "IdFestival", "Id" });

            migrationBuilder.CreateIndex(
                name: "unique_company_festival",
                table: "ParticipationCompany",
                columns: new[] { "IdCompany", "IdFestival" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_device_hash",
                table: "DeviceParticipation",
                columns: new[] { "Hash", "IdParticipation" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "votes_pk",
                table: "vote");

            migrationBuilder.DropIndex(
                name: "IX_vote",
                table: "vote");

            migrationBuilder.DropPrimaryKey(
                name: "participation_company_pk",
                table: "ParticipationCompany");

            migrationBuilder.DropIndex(
                name: "IX_company_participation",
                table: "ParticipationCompany");

            migrationBuilder.DropIndex(
                name: "unique_company_festival",
                table: "ParticipationCompany");

            migrationBuilder.DropIndex(
                name: "unique_device_hash",
                table: "DeviceParticipation");

            migrationBuilder.RenameTable(
                name: "vote",
                newName: "Vote");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Vote",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_question",
                table: "Vote",
                newName: "IdQuestion");

            migrationBuilder.RenameColumn(
                name: "id_participation_company",
                table: "Vote",
                newName: "IdParticipationCompany");

            migrationBuilder.RenameColumn(
                name: "id_answer",
                table: "Vote",
                newName: "IdAnswer");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Vote",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vote",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ParticipationCompany",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "DeviceParticipation",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipationCompany",
                table: "ParticipationCompany",
                column: "Id");
        }
    }
}
