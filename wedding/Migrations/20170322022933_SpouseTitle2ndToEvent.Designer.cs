using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wedding.Models;

namespace wedding.Migrations
{
    [DbContext(typeof(WedContext))]
    [Migration("20170322022933_SpouseTitle2ndToEvent")]
    partial class SpouseTitle2ndToEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("wedding.Models.Attendee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("GuestOf");

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.HasIndex("EventId");

                    b.ToTable("Attendee");
                });

            modelBuilder.Entity("wedding.Models.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("SndSpouse");

                    b.Property<string>("SndSpouseTitle");

                    b.Property<string>("Spouse");

                    b.Property<string>("SpouseTitle");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("WedDay");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("wedding.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("wedding.Models.Attendee", b =>
                {
                    b.HasOne("wedding.Models.Event", "Event")
                        .WithMany("Attendees")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("wedding.Models.Event", b =>
                {
                    b.HasOne("wedding.Models.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
