﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleChat.Data;

#nullable disable

namespace SimpleChat.Migrations
{
    [DbContext(typeof(ChatMessagesDBContext))]
    [Migration("20240819061406_Model-V0")]
    partial class ModelV0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("SimpleChat.Models.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("chat_message");

                    b.Property<long>("UserID")
                        .HasColumnType("INTEGER")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("SimpleChat.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

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
                    b.HasOne("SimpleChat.Models.User", "User")
                        .WithMany("ChatMessages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleChat.Models.User", b =>
                {
                    b.Navigation("ChatMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
