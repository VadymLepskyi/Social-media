using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillCommunityAndCommunityPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SkillCommunityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SkillCommunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCommunities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillCommunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    MediaUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityPosts_SkillCommunities_SkillCommunityId",
                        column: x => x.SkillCommunityId,
                        principalTable: "SkillCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunityPosts_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_SkillCommunityId",
                table: "UserProfiles",
                column: "SkillCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPosts_SkillCommunityId",
                table: "CommunityPosts",
                column: "SkillCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPosts_UserProfileId",
                table: "CommunityPosts",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCommunities_Level",
                table: "SkillCommunities",
                column: "Level");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles",
                column: "SkillCommunityId",
                principalTable: "SkillCommunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SkillCommunities_SkillCommunityId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CommunityPosts");

            migrationBuilder.DropTable(
                name: "SkillCommunities");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_SkillCommunityId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "SkillCommunityId",
                table: "UserProfiles");
        }
    }
}
