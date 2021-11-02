using Microsoft.EntityFrameworkCore;
using NordicStationCodeTestPart3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordicStationCodeTestPart3.DataAccess
{
    public class CreditCardDbContext : DbContext
    {
        public CreditCardDbContext(DbContextOptions<CreditCardDbContext> options): base(options) { }
        
        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
