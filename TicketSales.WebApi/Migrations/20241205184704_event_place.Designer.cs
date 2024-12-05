﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicketSales.WebApi.Data;

#nullable disable

namespace TicketSales.WebApi.Migrations
{
    [DbContext(typeof(TicketSalesDbContext))]
    [Migration("20241205184704_event_place")]
    partial class event_place
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Aware.Data.Entity.LookupEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExtraData")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("Aware.Data.Entity.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("CompanyID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastVisit")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aware.File.Model.FileRelationEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<long>("RelationId")
                        .HasColumnType("bigint");

                    b.Property<int>("RelationType")
                        .HasColumnType("integer");

                    b.Property<string>("SortOrder")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("FileRelations");
                });

            modelBuilder.Entity("Aware.Model.MailTemplateDto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ParentID")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.Property<string>("awd")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MailTemplates");
                });

            modelBuilder.Entity("TicketSales.WebApi.Data.Entity.EventEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TicketSales.WebApi.Data.Entity.EventPlaceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlaceId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PlaceId");

                    b.ToTable("EventPlace");
                });

            modelBuilder.Entity("TicketSales.WebApi.Data.Entity.PlaceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreated")
                        .HasColumnType("bigint");

                    b.Property<long>("UserModified")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("TicketSales.WebApi.Data.Entity.EventPlaceEntity", b =>
                {
                    b.HasOne("TicketSales.WebApi.Data.Entity.EventEntity", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketSales.WebApi.Data.Entity.PlaceEntity", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TicketSales.WebApi.Data.Entity.PlaceEntity", b =>
                {
                    b.HasOne("TicketSales.WebApi.Data.Entity.PlaceEntity", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });
#pragma warning restore 612, 618
        }
    }
}
