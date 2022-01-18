using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSoftBE.Migrations
{
    public partial class SplitCourseByUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCycles_Users_CourseCycleId",
                table: "CourseCycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_CourseCycles_CourseCycleClassCycleId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Tutors_CourseCycles_CourseCycleClassCycleId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Tutors_CourseCycleClassCycleId",
                table: "Tutors");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseCycleClassCycleId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_CourseCycles_CourseCycleId",
                table: "CourseCycles");

            migrationBuilder.DropColumn(
                name: "CourseCycleClassCycleId",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "CourseCycleClassCycleId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseCycleId",
                table: "CourseCycles");

            migrationBuilder.CreateTable(
                name: "CourseAssignment",
                columns: table => new
                {
                    CourseAssignmentId = table.Column<int>(type: "int", nullable: false),
                    CourseCycleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeightedMark = table.Column<float>(type: "float", nullable: false),
                    FinalMark = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignment", x => x.CourseAssignmentId);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_CourseCycles_CourseCycleId",
                        column: x => x.CourseCycleId,
                        principalTable: "CourseCycles",
                        principalColumn: "ClassCycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Students_CourseAssignmentId",
                        column: x => x.CourseAssignmentId,
                        principalTable: "Students",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignment_Students_UserId",
                        column: x => x.UserId,
                        principalTable: "Students",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTutors",
                columns: table => new
                {
                    CourseTutorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CourseCycleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTutors", x => x.CourseTutorId);
                    table.ForeignKey(
                        name: "FK_CourseTutors_CourseCycles_CourseCycleId",
                        column: x => x.CourseCycleId,
                        principalTable: "CourseCycles",
                        principalColumn: "ClassCycleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTutors_CourseCycles_CourseTutorId",
                        column: x => x.CourseTutorId,
                        principalTable: "CourseCycles",
                        principalColumn: "ClassCycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTutors_Tutors_CourseTutorId",
                        column: x => x.CourseTutorId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTutors_Tutors_UserId",
                        column: x => x.UserId,
                        principalTable: "Tutors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_CourseCycleId",
                table: "CourseAssignment",
                column: "CourseCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignment_UserId",
                table: "CourseAssignment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTutors_CourseCycleId",
                table: "CourseTutors",
                column: "CourseCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTutors_UserId",
                table: "CourseTutors",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignment");

            migrationBuilder.DropTable(
                name: "CourseTutors");

            migrationBuilder.AddColumn<int>(
                name: "CourseCycleClassCycleId",
                table: "Tutors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseCycleClassCycleId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseCycleId",
                table: "CourseCycles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_CourseCycleClassCycleId",
                table: "Tutors",
                column: "CourseCycleClassCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseCycleClassCycleId",
                table: "Students",
                column: "CourseCycleClassCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCycles_CourseCycleId",
                table: "CourseCycles",
                column: "CourseCycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCycles_Users_CourseCycleId",
                table: "CourseCycles",
                column: "CourseCycleId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CourseCycles_CourseCycleClassCycleId",
                table: "Students",
                column: "CourseCycleClassCycleId",
                principalTable: "CourseCycles",
                principalColumn: "ClassCycleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tutors_CourseCycles_CourseCycleClassCycleId",
                table: "Tutors",
                column: "CourseCycleClassCycleId",
                principalTable: "CourseCycles",
                principalColumn: "ClassCycleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
