using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD_GIBDD.Models
{
    public class Staff
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public short Age { get; set; }
        public string Gender { get; set; }    
        public string Address { get; set; }
        public int Phone { get; set; }
        public string PassportData { get; set; }
        public DbSet<Position> PositionID { get; set; }
        public DbSet<Rank> RankID { get; set; }
    }
}
