using Empleados.DbContexts;
using Empleados.Models;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly ApplicationDbContext _db;


        public EmpleadoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            List<Empleado> empleados =
                 await _db.Empleados
                     .Include(e => e.Estatus)
                     .ToListAsync();

            return empleados;
        }

        public async Task<Empleado> GetEmpleadoById(int empleado_id)
        {
            Empleado empleado =
                await _db.Empleados
                    .Where(e => e.Empleado_Id == empleado_id)
                    .Include(e => e.Estatus)
                    .FirstOrDefaultAsync();

            return empleado;
        }

        public async Task<Empleado> CreateUpdateEmpleado(Empleado empleado)
        {
            //Empleado empleado = _mapper.Map<EmpleadoDto, Empleado>(empleadoDto);
            if (empleado.Empleado_Id > 0)
            {
                _db.Empleados.Update(empleado);
            }
            else
            {
                _db.Empleados.Add(empleado);
            }

            await _db.SaveChangesAsync();

            return empleado;
        }

        public async Task<bool> DeleteEmpleadoById(int empleado_id)
        {
            try
            {
                Empleado empleado = await _db.Empleados.FirstOrDefaultAsync(e => e.Empleado_Id == empleado_id);

                if (empleado == null) return false;

                _db.Empleados.Remove(empleado);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
