using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiConFin.Models;

namespace WebApiConFin.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase {

        private static List<Cidade> lista = new List<Cidade>();

        [HttpGet]
        public List<Cidade> getEstados() {
            return lista;
        }

        [HttpGet("{id}")]
        public Cidade getEstados([FromRoute] int id) {
            Cidade cidadeAux = new Cidade();
            try {
                cidadeAux = lista.Where(e => e.Id == id).FirstOrDefault();
            } catch(Exception ex) {

            }
            return cidadeAux;
        }

        [HttpPost]
        public string postEstado(Cidade cidade) {
            lista.Add(cidade);
            return "Cidade Cadastrada com sucesso";
        }

        [HttpPut]
        public string putEstado(Cidade cidade) {
            Cidade cidadeAux = lista.Where(e => e.Id == cidade.Id).FirstOrDefault();
            cidadeAux.nome = cidade.nome;
            cidadeAux.estadoSigla = cidade.estadoSigla;

            return "Cidade alterada com sucesso";
        }

        [HttpDelete]
        public string deleteEstado(Cidade cidade) {
            Cidade cidadeAux = lista.Where(e => e.Id == cidade.Id).FirstOrDefault();
            lista.Remove(cidadeAux);
            return "Cidade removida com sucesso";
        }

        [HttpDelete("{id}")]
        public string deleteEstado(int id) {
            Cidade cidadeAux = lista.Where(e => e.Id == id).FirstOrDefault();
            lista.Remove(cidadeAux);
            return "Cidade removida com sucesso";
        }


    }
}
