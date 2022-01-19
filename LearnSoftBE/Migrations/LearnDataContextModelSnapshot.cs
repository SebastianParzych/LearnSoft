﻿// <auto-generated />
using System;
using LearnSoftBE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LearnSoftBE.Migrations
{
    [DbContext(typeof(LearnDataContext))]
    partial class LearnDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("LearnSoftBE.Models.ChatModels.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChatName")
                        .HasColumnType("text");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("LearnSoftBE.Models.ChatModels.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<bool>("HasSeen")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("MessageDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("LearnSoftBE.Models.ChatModels.UserChat", b =>
                {
                    b.Property<int>("UserChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserChatId");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChats");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ECTS")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseAssignment", b =>
                {
                    b.Property<int>("CourseAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseCycleId")
                        .HasColumnType("int");

                    b.Property<float>("FinalMark")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("WeightedMark")
                        .HasColumnType("float");

                    b.HasKey("CourseAssignmentId");

                    b.HasIndex("CourseCycleId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseCycle", b =>
                {
                    b.Property<int>("ClassCycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("SemesterNumber")
                        .HasColumnType("int");

                    b.Property<int>("StudentCount")
                        .HasColumnType("int");

                    b.HasKey("ClassCycleId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("CourseCycles");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseTutor", b =>
                {
                    b.Property<int>("CourseTutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseCycleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseTutorId");

                    b.HasIndex("CourseCycleId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseTutors");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.Institute", b =>
                {
                    b.Property<int>("InstitudeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("InstitudeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UniversityId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.UserUnit", b =>
                {
                    b.Property<int>("UserUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserUnitId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserUnits");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UserModels.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UserModels.Student", b =>
                {
                    b.HasBaseType("LearnSoftBE.Models.UserModels.User");

                    b.Property<int>("IndexNumber")
                        .HasColumnType("int");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UserModels.Tutor", b =>
                {
                    b.HasBaseType("LearnSoftBE.Models.UserModels.User");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("LearnSoftBE.Models.ChatModels.Message", b =>
                {
                    b.HasOne("LearnSoftBE.Models.ChatModels.Chat", "Chatroom")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnSoftBE.Models.UserModels.User", "Sender")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chatroom");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("LearnSoftBE.Models.ChatModels.UserChat", b =>
                {
                    b.HasOne("LearnSoftBE.Models.ChatModels.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnSoftBE.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseAssignment", b =>
                {
                    b.HasOne("LearnSoftBE.Models.CourseModels.CourseCycle", "AssigmentCourse")
                        .WithMany()
                        .HasForeignKey("CourseCycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnSoftBE.Models.UserModels.Student", "AssigmentUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssigmentCourse");

                    b.Navigation("AssigmentUser");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseCycle", b =>
                {
                    b.HasOne("LearnSoftBE.Models.CourseModels.Course", "ClassInfo")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnSoftBE.Models.UnitModels.Department", "ExeDepartment")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassInfo");

                    b.Navigation("ExeDepartment");
                });

            modelBuilder.Entity("LearnSoftBE.Models.CourseModels.CourseTutor", b =>
                {
                    b.HasOne("LearnSoftBE.Models.CourseModels.CourseCycle", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCycleId");

                    b.HasOne("LearnSoftBE.Models.UserModels.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.Department", b =>
                {
                    b.HasOne("LearnSoftBE.Models.UnitModels.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.Institute", b =>
                {
                    b.HasOne("LearnSoftBE.Models.UnitModels.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UnitModels.UserUnit", b =>
                {
                    b.HasOne("LearnSoftBE.Models.UnitModels.Department", "UserDepartment")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearnSoftBE.Models.UserModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserDepartment");
                });

            modelBuilder.Entity("LearnSoftBE.Models.UserModels.Student", b =>
                {
                    b.HasOne("LearnSoftBE.Models.UserModels.User", null)
                        .WithOne()
                        .HasForeignKey("LearnSoftBE.Models.UserModels.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearnSoftBE.Models.UserModels.Tutor", b =>
                {
                    b.HasOne("LearnSoftBE.Models.UnitModels.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("LearnSoftBE.Models.UserModels.User", null)
                        .WithOne()
                        .HasForeignKey("LearnSoftBE.Models.UserModels.Tutor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
