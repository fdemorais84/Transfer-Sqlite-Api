﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcessoTransfer.Api.Model;
using AcessoTransfer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AcessoTransfer.Api.Controllers
{    
    public class TransferenciaController : ControllerBase
    {
        private readonly ILogger<TransferenciaController> _logger;
        public readonly ITransferenciaService _transferenciaService;

        public TransferenciaController(ILogger<TransferenciaController> logger, ITransferenciaService transferenciaService)
        {
            _logger = logger;
            _transferenciaService = transferenciaService;
        }

        [HttpPost("api/fund-transfer")]
        public async Task<IActionResult> RealizarTransferencia([FromBody] Transferencia dados)
        {
            _logger.LogInformation(
               "Recebida nova requisição|" +
              $"Conta Origem: {dados.AccountOrigin}|" +
              $"Conta Destino: {dados.AccountDestination}|" +
              $"Valor: {dados.Value}");            

            return Ok(await _transferenciaService.RealizarTransferencia(dados));
        }

        [HttpGet("api/fund-transfer/{transactionId:Guid}")]
        public async Task<IActionResult> ConsultarStatusTranferencia(Guid transactionId)
        {
            _logger.LogInformation(
              "Recebida nova requisição|" +
             $"Dados Transação: {transactionId}");

            return Ok(await _transferenciaService.ConsultarStatusTranferencia(transactionId));
        }
    }
}
