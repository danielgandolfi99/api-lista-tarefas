using Microsoft.EntityFrameworkCore;
using ListaTarefasApi.Models;

namespace ListaTarefasApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().HasNoKey();
        }

        public async Task<List<Tarefa>> ListaTarefas()
        {
            return await Tarefas
                .FromSqlRaw("CALL LISTA_TAREFAS()")
                .ToListAsync();
        }

        public async Task AdicionaTarefa(string titulo, string descricao)
        {
            await Database.ExecuteSqlRawAsync("CALL ADICIONA_TAREFA({0}, {1})", titulo, descricao);
        }

        public async Task EditaTarefa(int id, string titulo, string descricao)
        {
            await Database.ExecuteSqlRawAsync("CALL EDITA_TAREFA({0}, {1}, {2})", id, titulo, descricao);
        }

        public async Task RemoveTarefa(int id)
        {
            await Database.ExecuteSqlRawAsync("CALL REMOVE_TAREFA({0})", id);
        }

        public async Task ConcluiTarefa(int id)
        {
            await Database.ExecuteSqlRawAsync("CALL CONCLUI_TAREFA({0})", id);
        }

    }
}
