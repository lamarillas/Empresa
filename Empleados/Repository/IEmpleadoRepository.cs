using Empleados.Models;

namespace Empleados.Repository
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleadoById(int empleado_id);
        Task<Empleado> CreateUpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleadoById(int empleado_id);
    }
}
