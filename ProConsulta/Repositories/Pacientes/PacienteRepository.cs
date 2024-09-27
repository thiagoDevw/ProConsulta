using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;
        public PacienteRepository(ApplicationDbContext context) 
        {
            _context = context;
        }


        public async Task AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context
                .Pacientes
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Paciente?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
