using ManageUser.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUser.Infra.Context
{
    public class ManagerUserContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public ManagerUserContext()
        {

        }
    }
}
