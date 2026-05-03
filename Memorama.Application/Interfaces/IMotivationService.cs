using Memorama.Application.DTOs.OnTime;
using Memorama.Application.DTOs.Records;
using Memorama.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Interfaces
{
    public interface IMotivationService
    {
        // Para el MainForm: Muestra los 5 mejores tiempos
        List<GameRecordDTO> ConsultarHistoricos(int CantidadHistoricos);

        // Para el JuegoForm: Genera el mensaje al terminar la partida
        string GenerarMensajeFinal(OnTimeGameDataInfoDTO OnTimeGameInfo);
    }
}
