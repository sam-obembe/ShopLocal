using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using shopLocalDataAccess.Entities;

namespace shopLocalMvc.Data
{
    public class MvcDbContext : IdentityDbContext
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options)
            : base(options)
        {
        }
    }
}
