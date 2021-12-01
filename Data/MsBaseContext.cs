using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MsBase.Models;

namespace MsBase.Data
{
    public class MsBaseContext : DbContext
    {
        public MsBaseContext (DbContextOptions<MsBaseContext> options)
            : base(options)
        {
        }

        public DbSet<MsBase.Models.MsBaseModel> MsBaseModel { get; set; }
    }
}
