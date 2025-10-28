
using keyhanPostWeb.Areas.KP.Models.Entities.Representative;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace keyhanPostWeb.Areas.KP.Models.ModelConfigs.RepresentativeMapp
{
    public class RepApplicantMapp : IEntityTypeConfiguration<RepApplicant>
    {
        public void Configure(EntityTypeBuilder<RepApplicant> builder)
        {
            builder.HasOne(n => n.EntityType)
                .WithMany(n => n.RepApplications)
                .HasForeignKey(f => f.EntityTypeId);

            builder.HasOne(n => n.AgencyType)
            .WithMany(n => n.RepApplications)
            .HasForeignKey(f => f.AgencyTypeId);

            builder.HasOne(n => n.RequestStatus)
           .WithMany(n => n.RepApplications)
           .HasForeignKey(f => f.RequestStatusId);

            builder.HasOne(n => n.Experience)
         .WithMany(n => n.RepApplications)
         .HasForeignKey(f => f.ExperienceId);

            builder.HasOne(n => n.VehicleAvailability)
       .WithMany(n => n.RepApplications)
       .HasForeignKey(f => f.VehicleAvailabilityId);

            builder.HasOne(n => n.VehicleType)
       .WithMany(n => n.RepApplications)
       .HasForeignKey(f => f.VehicleTypeId);

            builder.HasOne(n => n.PropertyType)
       .WithMany(n => n.RepApplications)
       .HasForeignKey(f => f.PropertyTypeId);


            builder.HasOne(n => n.City)
       .WithMany(n => n.RepApplications)
       .HasForeignKey(f => f.CityId);

            builder.HasOne(n => n.Introduction)
     .WithMany(n => n.RepApplications)
     .HasForeignKey(f => f.IntroductionId);

            builder.HasOne(n => n.EducationDegree)
    .WithMany(n => n.RepApplications)
    .HasForeignKey(f => f.EducationId);

        }
    }
}
