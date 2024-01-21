using Empleados.Models;
using Empleados.Models.Dtos;
using Empleados.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        protected ResponseDto _response;
        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<Empleado> empleadosDto = await _empleadoRepository.GetEmpleados();
                _response.Result = empleadosDto;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

                return _response;
            }
        }

        [HttpGet]
        [Route("{empleado_Id:int}")]
        public async Task<object> GetById(int empleado_id)
        {
            try
            {
                Empleado empleadoDto = await _empleadoRepository.GetEmpleadoById(empleado_id);
                _response.Result = empleadoDto;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

                return _response;
            }
        }

        [HttpPost]
        public async Task<object> Post([FromBody] Empleado empleado)
        {
            try
            {
                Empleado empleadoCreated = await _empleadoRepository.CreateUpdateEmpleado(empleado);
                _response.Result = empleadoCreated;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

                return _response;
            }
        }


        [HttpPut]
        public async Task<object> Put([FromBody] Empleado empleado)
        {
            try
            {
                Empleado empleadoUpdated = await _empleadoRepository.CreateUpdateEmpleado(empleado);
                _response.Result = empleadoUpdated;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

                return _response;
            }
        }

        [HttpDelete]
        [Route("{empleado_Id:int}")]
        public async Task<object> Delete(int empleado_Id)
        {
            try
            {
                _response.Result = await _empleadoRepository.DeleteEmpleadoById(empleado_Id);
                return _response.Result = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

                return _response;
            }
        }
    }
}
