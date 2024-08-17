namespace E_Commerce.DAL.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
           
            builder.HasOne(o => o.ShippingMethod)
                .WithMany(sm => sm.Orders)
                .HasForeignKey(o => o.ShippingMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.TotalPrice)
                .HasPrecision(10, 2);
        }
    }
}
