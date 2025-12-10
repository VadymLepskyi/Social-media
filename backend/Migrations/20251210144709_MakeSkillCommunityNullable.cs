using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class MakeSkillCommunityNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillCommunityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillCommunityId",
                table: "CommunityPosts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles",
                column: "SkillCommunityId",
                principalTable: "SkillCommunities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillCommunityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SkillCommunityId",
                table: "CommunityPosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles",
                column: "SkillCommunityId",
                principalTable: "SkillCommunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
