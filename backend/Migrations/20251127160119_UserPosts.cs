using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserProfileId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    PostContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PostMediaUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_UserPosts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPosts_UserProfiles_UserProfileId1",
                        column: x => x.UserProfileId1,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserProfileId",
                table: "UserPosts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserProfileId1",
                table: "UserPosts",
                column: "UserProfileId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPosts");
        }
    }
}
