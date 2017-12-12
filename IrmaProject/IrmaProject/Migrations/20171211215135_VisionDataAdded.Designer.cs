﻿// <auto-generated />
using IrmaProject.Repository.EntityFramework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IrmaProject.Migrations
{
    [DbContext(typeof(PicBookDbContext))]
    [Migration("20171211215135_VisionDataAdded")]
    partial class VisionDataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IrmaProject.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilNumber");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("SocialUserId");

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool?>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.Property<string>("Url");

                    b.Property<string>("UrlFriendlyName");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlbumId");

                    b.Property<Guid>("BlobImageId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<int?>("Height");

                    b.Property<string>("MobileSizeUrl");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("OriginalSizeUrl");

                    b.Property<bool>("Public");

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.Property<string>("UrlFriendlyName");

                    b.Property<string>("VisionData");

                    b.Property<string>("WebSizeUrl");

                    b.Property<int?>("Width");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<string>("Comment");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<Guid?>("ImageId");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTimeOffset?>("UpdatedAt");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ImageId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Album", b =>
                {
                    b.HasOne("IrmaProject.Domain.Entities.Account", "Account")
                        .WithMany("Album")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Image", b =>
                {
                    b.HasOne("IrmaProject.Domain.Entities.Album", "Album")
                        .WithMany("Image")
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("IrmaProject.Domain.Entities.Rating", b =>
                {
                    b.HasOne("IrmaProject.Domain.Entities.Account", "Account")
                        .WithMany("Rating")
                        .HasForeignKey("AccountId");

                    b.HasOne("IrmaProject.Domain.Entities.Image", "Image")
                        .WithMany("Rating")
                        .HasForeignKey("ImageId");
                });
#pragma warning restore 612, 618
        }
    }
}
