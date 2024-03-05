using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiFuncionario.Models;

namespace WebApiFuncionario.Data
{
    public class WebApiFuncionarioContext : DbContext
    {
        public WebApiFuncionarioContext (DbContextOptions<WebApiFuncionarioContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiFuncionario.Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
