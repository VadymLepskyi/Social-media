using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixUserPostFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_UserProfiles_UserProfileId1",
                table: "UserPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserPosts_UserProfileId1",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "UserProfileId1",
                table: "UserPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId1",
                table: "UserPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserProfileId1",
                table: "UserPosts",
                column: "UserProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_UserProfiles_UserProfileId1",
                table: "UserPosts",
                column: "UserProfileId1",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
