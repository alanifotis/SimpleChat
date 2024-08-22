﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleChat.Data;

#nullable disable

namespace SimpleChat.Migrations
{
    [DbContext(typeof(ChatMessagesDBContext))]
    [Migration("20240816103745_NewUser")]
    partial class NewUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("SimpleChat.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("SimpleChat.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<string>("SentMessage")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("user_chat_message");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("SimpleChat.Models.ChatMessage", b =>
                {
                    b.HasOne("SimpleChat.Models.User", null)
                        .WithMany("ChatMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleChat.Models.User", b =>
                {
                    b.Navigation("ChatMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
