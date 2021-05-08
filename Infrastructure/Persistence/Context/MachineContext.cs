using Domain.SnackMachine;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class MachineContext : DbContext
    {
        public DbSet<SnackMachine>? SnackMachines { get; set; }

        public MachineContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseHiLo("SnackSequence");
            modelBuilder.Entity<SnackMachine>()
                .Ignore(machine => machine.MoneyInTransaction)
                .OwnsOne<Money>(machine => machine.MoneyInside!)
                .WithOwner();
        }
    }
}