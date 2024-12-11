using Microsoft.EntityFrameworkCore;

namespace TarefasApi.Models
{
    public class DataContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
