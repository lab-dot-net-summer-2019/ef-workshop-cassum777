using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class EditKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Samurais",
                table: "Samurais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.RenameTable(
                name: "SecretIdentity",
                newName: "SecretIdentites");

            migrationBuilder.RenameTable(
                name: "Samurais",
                newName: "Samurai");

            migrationBuilder.RenameTable(
                name: "SamuraiBattle",
                newName: "SamuraiBattles");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "Batles");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentity_SamuraiId",
                table: "SecretIdentites",
                newName: "IX_SecretIdentites_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattle_SamuraiId",
                table: "SamuraiBattles",
                newName: "IX_SamuraiBattles_SamuraiId");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Quotes",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Samurai",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Samurai",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KillStreak",
                table: "SamuraiBattles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Batles",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentites",
                table: "SecretIdentites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Samurai",
                table: "Samurai",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batles",
                table: "Batles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Samurai_BattleId",
                table: "Samurai",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Samurai_SamuraiId",
                table: "Quotes",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurai_Batles_BattleId",
                table: "Samurai",
                column: "BattleId",
                principalTable: "Batles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Batles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId",
                principalTable: "Batles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Samurai_SamuraiId",
                table: "SamuraiBattles",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentites_Samurai_SamuraiId",
                table: "SecretIdentites",
                column: "SamuraiId",
                principalTable: "Samurai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Samurai_SamuraiId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Samurai_Batles_BattleId",
                table: "Samurai");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Batles_BattleId",
                table: "SamuraiBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Samurai_SamuraiId",
                table: "SamuraiBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentites_Samurai_SamuraiId",
                table: "SecretIdentites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecretIdentites",
                table: "SecretIdentites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SamuraiBattles",
                table: "SamuraiBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Samurai",
                table: "Samurai");

            migrationBuilder.DropIndex(
                name: "IX_Samurai_BattleId",
                table: "Samurai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batles",
                table: "Batles");

            migrationBuilder.DropColumn(
                name: "KillStreak",
                table: "SamuraiBattles");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Samurai");

            migrationBuilder.RenameTable(
                name: "SecretIdentites",
                newName: "SecretIdentity");

            migrationBuilder.RenameTable(
                name: "SamuraiBattles",
                newName: "SamuraiBattle");

            migrationBuilder.RenameTable(
                name: "Samurai",
                newName: "Samurais");

            migrationBuilder.RenameTable(
                name: "Batles",
                newName: "Battles");

            migrationBuilder.RenameIndex(
                name: "IX_SecretIdentites_SamuraiId",
                table: "SecretIdentity",
                newName: "IX_SecretIdentity_SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_SamuraiBattles_SamuraiId",
                table: "SamuraiBattle",
                newName: "IX_SamuraiBattle_SamuraiId");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Quotes",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Samurais",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Battles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecretIdentity",
                table: "SecretIdentity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SamuraiBattle",
                table: "SamuraiBattle",
                columns: new[] { "BattleId", "SamuraiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Samurais",
                table: "Samurais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Samurais_SamuraiId",
                table: "Quotes",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Battles_BattleId",
                table: "SamuraiBattle",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattle_Samurais_SamuraiId",
                table: "SamuraiBattle",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentity_Samurais_SamuraiId",
                table: "SecretIdentity",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}