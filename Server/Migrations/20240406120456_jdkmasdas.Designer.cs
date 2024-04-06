﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Database;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(AnalyticsContext))]
    [Migration("20240406120456_jdkmasdas")]
    partial class jdkmasdas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Server.Database.Guild", b =>
                {
                    b.Property<string>("GuildId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AdminRoleId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ViewerRoleId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Visibility")
                        .HasColumnType("INTEGER");

                    b.HasKey("GuildId");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Server.Database.Message", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Bot")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("GuildId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MessageId");

                    b.HasIndex("GuildId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Server.Database.VoiceCall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChannelId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GuildId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("VoiceCalls");
                });

            modelBuilder.Entity("Server.Database.Message", b =>
                {
                    b.HasOne("Server.Database.Guild", "Guild")
                        .WithMany("Messages")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Server.Database.VoiceCall", b =>
                {
                    b.HasOne("Server.Database.Guild", "Guild")
                        .WithMany("VoiceCalls")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Server.Database.Guild", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("VoiceCalls");
                });
#pragma warning restore 612, 618
        }
    }
}
