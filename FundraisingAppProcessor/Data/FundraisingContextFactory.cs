using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FundraisingAppProcessor.Data
{
    public class FundraisingContextFactory : IDesignTimeDbContextFactory<FundraisingContext>
    {
        public FundraisingContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=LAPTOP-N5VPC8I0;Initial Catalog=Fundraising;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            var builder = new DbContextOptionsBuilder<FundraisingContext>();
            builder.UseSqlServer(connectionString);

            return new FundraisingContext(builder.Options);
        }
    }
}