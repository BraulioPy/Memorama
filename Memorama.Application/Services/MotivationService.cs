using Memorama.Application.Constants;
using Memorama.Application.DTOs.OnTime;
using Memorama.Application.DTOs.Records;
using Memorama.Application.Interfaces;
using Memorama.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Services
{
    public class MotivationService : IMotivationService
    {
        private readonly IPersistenceService _dbManager;
        public MotivationService(IPersistenceService dbManager)
        {
            _dbManager = dbManager;
        }

        public List<GameRecordDTO> ConsultarHistoricos(int CantidadHistoricos)
        {
            var RecordsList = _dbManager.Load<List<GameRecordDTO>>(StorageKeys.Records);
            return RecordsList?.Where(x=>x.EsVictoria).OrderByDescending(x=>x.CartasTotales)
                .ThenBy(x => x.IntentosUsados)
                .ThenBy(x => x.SegundosUsados)
                .Take(CantidadHistoricos).ToList() ?? new List<GameRecordDTO>();
        }

        public string GenerarMensajeFinal(OnTimeGameDataInfoDTO OnTimeGameInfo)
        {
            var historico = ConsultarHistoricos(5);
            var MejorPartida = historico.FirstOrDefault();
            if (MejorPartida == null) return "¡Felicidades por tu primera partida! Sigue jugando para mejorar tu puntuación.";
            if (OnTimeGameInfo.SegundosActuales < MejorPartida.SegundosUsados)
                return $"¡BRUTAL! Has superado tu récord por {MejorPartida.SegundosUsados-OnTimeGameInfo.SegundosActuales} segundos. ¡Eres un maestro de la memoria!";
            return ObtenerMensajeAleatorio();
        }


        private string ObtenerMensajeAleatorio()
        {
            var mensajes = new List<string> {
            "¡Muy bien jugado! Estás cerca de tu mejor marca.",
            "¡Esa agudeza visual es impresionante!",
            "¡No te rindas! La próxima será tu mejor tiempo.",
            "¡Tu cerebro está en su mejor momento!"
        };
            return mensajes[new Random().Next(mensajes.Count)];
        }
    }
}
