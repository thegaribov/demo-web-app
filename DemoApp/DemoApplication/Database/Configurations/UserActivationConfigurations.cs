using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DemoApplication.Database.Configurations
{
    public class UserActivationConfigurations : IEntityTypeConfiguration<UserActivation>
    {
        public void Configure(EntityTypeBuilder<UserActivation> builder)
        {
            builder
               .ToTable("UserActivations");
        }
    }
}
