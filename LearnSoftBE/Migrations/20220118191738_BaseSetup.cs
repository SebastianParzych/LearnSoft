using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LearnSoftBE.Migrations
{
    public partial class BaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ChatName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ECTS = table.Column<int>(type: "int", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UniversityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Chats_UserChatId",
                        column: x => x.UserChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    InstitudeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InstituteName = table.Column<string>(type: "text", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.InstitudeId);
                    table.ForeignKey(
                        name: "FK_Institutes_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    MessageDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    HasSeen = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserChatId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => x.UserChatId);
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserChatId",
                        column: x => x.UserChatId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseCycles",
                columns: table => new
                {
                    ClassCycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    SemesterNumber = table.Column<int>(type: "int", nullable: false),
                    InstitudeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseCycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCycles", x => x.ClassCycleId);
                    table.ForeignKey(
                        name: "FK_CourseCycles_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCycles_Institutes_InstitudeId",
                        column: x => x.InstitudeId,
                        principalTable: "Institutes",
                        principalColumn: "InstitudeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseCycles_Users_CourseCycleId",
                        column: x => x.CourseCycleId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IndexNumber = table.Column<int>(type: "int", nullable: false),
                    CourseCycleClassCycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Students_CourseCycles_CourseCycleClassCycleId",
                        column: x => x.CourseCycleClassCycleId,
                        principalTable: "CourseCycles",
                        principalColumn: "ClassCycleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Degree = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    CourseCycleClassCycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tutors_CourseCycles_CourseCycleClassCycleId",
                        column: x => x.CourseCycleClassCycleId,
                        principalTable: "CourseCycles",
                        principalColumn: "ClassCycleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tutors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "text", nullable: false),
                    InstituteId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "InstitudeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departments_Tutors_UserId",
                        column: x => x.UserId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCycles_CourseCycleId",
                table: "CourseCycles",
                column: "CourseCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCycles_CourseId",
                table: "CourseCycles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCycles_InstitudeId",
                table: "CourseCycles",
                column: "InstitudeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstituteId",
                table: "Departments",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UserId",
                table: "Departments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_UniversityId",
                table: "Institutes",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseCycleClassCycleId",
                table: "Students",
                column: "CourseCycleClassCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_CourseCycleClassCycleId",
                table: "Tutors",
                column: "CourseCycleClassCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_UserId",
                table: "UserChats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserChatId",
                table: "Users",
                column: "UserChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "CourseCycles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Chats");
        }
    }
}
