using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.DTOs.Records
{
    public class GameRecordDTO
    {
        public string ModoDeJuego { get; set; }
        public int CartasTotales { get; set; } = 0;
        public int Segundos { get; set; } = 0;
        public int IntentosUsados { get; set; } = 0;
        public int IntentosTotales { get; set; } = 0;
        public bool EsVictoria { get; set; } = false;
        public DateTime FechaDeJuego { get; set; } = DateTime.Now;

    }
}
