using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.DTOs.OnTime
{
    public class OnTimeGameDataInfoDTO
    {
        public string ModoDeJuego { get; set; }
        public int CartasTotales { get; set; }
        public int IntentosActuales { get; set; }
        public int SegundosActuales { get; set; }
    }
}
