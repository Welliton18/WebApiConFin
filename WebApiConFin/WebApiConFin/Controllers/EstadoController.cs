using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiConFin.Models;

namespace WebApiConFin.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase {

        private static List<Estado> lista = new List<Estado>();

        [HttpGet]
        public List<Estado> getEstados() {
            return lista;
        }

        [HttpGet("{sigla}")]
        public Estado getEstado([FromRoute] string sigla) {
            Estado estadoAux = new Estado();
            try {
                estadoAux = lista.Where(e => e.sigla == sigla).FirstOrDefault();
            } catch(Exception ex) {

            }
            return estadoAux;
        }

        [HttpPost]
        public string postEstado(Estado estado) {
            lista.Add(estado);
            return "Estado Cadastrado com Sucesso";
        }

        [HttpPut]
        public string putEstado(Estado estado) {
            Estado estadoAux = lista.Where(e => e.sigla == estado.sigla).FirstOrDefault();
            estadoAux.nome = estado.nome;

            return "Estado alterado com sucesso";
        }

        [HttpDelete]
        public string deleteEstado(Estado estado) {
            Estado estadoAux = lista.Where(e => e.sigla == estado.sigla).FirstOrDefault();
            lista.Remove(estadoAux);
            return "Estado removido com Sucesso";
        }

        [HttpDelete("{sigla}")]
        public string deleteEstadoSigla(string sigla) {
            Estado estadoAux = lista.Where(e => e.sigla == sigla).FirstOrDefault();
            lista.Remove(estadoAux);
            return "Estado removido com Sucesso";
        }

        [HttpDelete("Delete")]
        public string deleteEstadoSigla2([FromQuery] string sigla) {
            Estado estadoAux = lista.Where(e => e.sigla == sigla).FirstOrDefault();
            lista.Remove(estadoAux);
            return "Estado removido com Sucesso";
        }

        [HttpDelete("DeleteHeader")]
        public string deleteEstadoSigla3([FromHeader] string sigla) {
            Estado estadoAux = lista.Where(e => e.sigla == sigla).FirstOrDefault();
            lista.Remove(estadoAux);
            return "Estado removido com Sucesso";
        }

    }
}
