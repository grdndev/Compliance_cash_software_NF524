using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CLICore.Data;
using Microsoft.EntityFrameworkCore;

namespace CLISyncService
{
    public class Helper
    {
      private CLIContext _dbContext;

        private DbContextOptions<CLIContext> GetAllOptions()
        {
            DbContextOptionsBuilder<CLIContext> optionsBuilder = new DbContextOptionsBuilder<CLIContext>();

            //optionsBuilder.UseSqlServer(apps.ConnectionString);

            return optionsBuilder.Options;
        }
}
}
