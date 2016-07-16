using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ContactManagement.Core.Entity;

namespace ContactManagement.Data.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            //Key
            HasKey(c => c.Id);

            //Fields
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(100).HasColumnType("nvachar");
            Property(c => c.Phone).IsOptional().HasMaxLength(14).HasColumnType("nvachar");
            Property(c => c.Email).IsRequired().HasMaxLength(14).HasColumnType("nvachar");
            Property(c => c.Company).IsOptional().HasMaxLength(50).HasColumnType("nvachar");
            Property(c => c.Title).IsOptional().HasMaxLength(35).HasColumnType("nvachar");
            Property(c => c.House).IsOptional().HasMaxLength(20).HasColumnType("nvachar");
            Property(c => c.Street).IsOptional().HasMaxLength(80).HasColumnType("nvachar");
            Property(c => c.PObox).IsOptional().HasMaxLength(10).HasColumnType("nvachar");
            Property(c => c.City).IsOptional().HasMaxLength(20).HasColumnType("nvachar");
            Property(c => c.ZipCode).IsOptional().HasMaxLength(10).HasColumnType("nvachar");

            ToTable("Contact");
        }
    }
}
