using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AKOK_BlazorServer.Data
{
    public static class FortuneInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            FortuneDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<FortuneDbContext>();
            try
            {
                // Uncomment to Delete database and apply a new Migration //
                //context.Database.EnsureDeleted();
                // Create database if it does not exist and apply the Migration //
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
