using BarberApi.Entidades;
using BarberApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barber.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {        
        /// <summary>
        /// Método de Inclusão de agendamentos
        /// </summary>
        /// <param name="agendamento">Agendamento</param>
        /// <returns>agendamento</returns>
        [HttpPost("Incluir")]
        public async Task<ActionResult<dynamic>> Incluir(Agendamento agendamento)
        {
            var retorno = new Retorno<Agendamento>();

            try
            {
                BarberApi.Negocios.Agendamento nAgendamento = new BarberApi.Negocios.Agendamento();

                var agenda = await ListarPorDataHora(agendamento);

                if (agenda == null)
                {
                    agendamento.Situacao = true;
                    nAgendamento.Incluir(agendamento);

                    retorno.Sucesso = true;
                    retorno.Mensagem = "agendamento efetuado com sucesso!";
                    retorno.ObjetoRetorno = agendamento;
                }
                else
                {
                    retorno.Sucesso = true;
                    retorno.Mensagem = "já existe um agendamento com esses dados.";
                    retorno.ObjetoRetorno = agendamento;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método de Listagem por Data e Hora
        /// </summary>
        /// <param name="agendamento">Agendamento</param>
        /// <returns>Lista de Agendamentos</returns>
        [HttpGet("ListarPorDataHora")]
        public async Task<ActionResult<dynamic>> ListarPorDataHora([FromBody] Agendamento agendamento)
        {
            var retorno = new Retorno<List<Agendamento>>();

            BarberApi.Negocios.Agendamento nAgendamento = new BarberApi.Negocios.Agendamento();

            var agendamentos = nAgendamento.ListarPorDataHora(agendamento);

            retorno.Sucesso = true;
            retorno.Mensagem = "comando executado com sucesso!";
            retorno.ObjetoRetorno = agendamentos;

            return retorno;
        }

        /// <summary>
        /// Método de Listagem por Data
        /// </summary>
        /// <param name="agendamento">Agendamento</param>
        /// <returns>Lista de agendamentos</returns>
        [HttpGet("ListarPorData")]
        public async Task<ActionResult<dynamic>> ListarPorData([FromBody] string data)
        {
            var retorno = new Retorno<List<Agendamento>>();

            BarberApi.Entidades.Agendamento agendamento = new BarberApi.Entidades.Agendamento();

            agendamento.DataAgendamento = Convert.ToDateTime(data);

            BarberApi.Negocios.Agendamento nAgendamento = new BarberApi.Negocios.Agendamento();

            var agendamentos = nAgendamento.ListarPorDataHora(agendamento);

            retorno.Sucesso = true;
            retorno.Mensagem = "comando executado com sucesso!";
            retorno.ObjetoRetorno = agendamentos;

            return retorno;
        }

        /// <summary>
        /// Método de Listagem de Calendários
        /// </summary>
        /// <param name="calendario">Calendario</param>
        /// <returns>agendamento</returns>
        [HttpGet("ListarCalendario")]
        public async Task<ActionResult<dynamic>> ListarCalendario(int IdLocacao = 1)
        {
            var retorno = new Retorno<List<Calendario>>();

            BarberApi.Negocios.Agendamento nAgendamento = new BarberApi.Negocios.Agendamento();

            var calendarios = nAgendamento.ListarCalendario(IdLocacao);

            retorno.Sucesso = true;
            retorno.Mensagem = "comando executado com sucesso!";
            retorno.ObjetoRetorno = calendarios;

            return retorno;
        }

        /// <summary>
        /// Método de Inclusão de agendamentos
        /// </summary>
        /// <param name="horas">Horas</param>
        /// <returns>listagem de horas</returns>
        [HttpGet("ListarHoras")]
        public async Task<ActionResult<dynamic>> ListarHoras()
        {
            var retorno = new Retorno<List<Horas>>();

            BarberApi.Negocios.Hora nHora = new BarberApi.Negocios.Hora();

            var horas = nHora.ListarHoras(null);

            retorno.Sucesso = true;
            retorno.Mensagem = "comando executado com sucesso!";
            retorno.ObjetoRetorno = horas;

            return retorno;
        }
    }
}
