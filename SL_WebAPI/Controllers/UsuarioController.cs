
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpPost]
        [Route("api/Usuario/GetAll")]
        public IHttpActionResult GetAll([FromBody]ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            return Ok(result);
        }

        // GET: api/Usuario/5
        [HttpGet]
        [Route("api/Usuario/GetById/{IdUsuario}")]
        public IHttpActionResult GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
            return Ok(result);
        }

        // POST: api/Usuario
        [HttpPost]
        [Route("api/Usuario/Add")]
        public IHttpActionResult Add([FromBody]ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            if (result.Correct)
            {
                return Ok(result);  
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Usuario/5
        [HttpPost]
        [Route("api/Usuario/Update")]
        public IHttpActionResult Update([FromBody]ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEF(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        
       // [Route("api/Usuario/Delete")]
        [Route("api/Usuario/Delete/{IdUsuario}/{IdDireccion}")]
        public IHttpActionResult Delete(int IdUsuario, int IdDireccion)
       // public IHttpActionResult Delete([FromBody] ML.Usuario usuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Direccion direccion = new ML.Direccion();
            direccion.IdDireccion = IdDireccion;
            ML.Result result = BL.Usuario.DeleteEF(usuario, direccion);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
