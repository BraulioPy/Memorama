using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorama.Application.Interfaces
{
    public interface ISoundService
    {
        void PlayFlip();
        void PlayFlippingCards();
        void PlayWin();
        void PlayGameOver();
        void StopMusic();
        void PlayRelevantButton();
        void PlayIrrelevantButton();
        void PlayLoadingSuccesfull();
    }
}
