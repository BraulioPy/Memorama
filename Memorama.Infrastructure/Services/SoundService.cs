using Memorama.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Memorama.Infrastructure.Services
{
    public class SoundService : ISoundService
    {
        // Accedemos a los recursos internos de la capa de Infrastructure
        private readonly SoundPlayer _flipSound;
        private readonly SoundPlayer _WinSound;
        private readonly SoundPlayer _loseSound;
        private readonly SoundPlayer _flippingSound;

        public SoundService()
        {
            // Properties.Resources apuntará a los archivos que metiste en esta capa
            _flipSound = new SoundPlayer(Properties.Resources._flip);
            _WinSound = new SoundPlayer(Properties.Resources._win);
            _loseSound = new SoundPlayer(Properties.Resources._lose);
            _flippingSound = new SoundPlayer(Properties.Resources._cardsFlipping);
        }
        public void PlayFlip() => _flipSound.Play();
        public void PlayFlippingCards() => _flippingSound.Play();
        public void PlayWin() => _WinSound.Play();
        public void PlayGameOver() => _loseSound.Play();
        public void StopMusic() { 
            _flipSound.Stop();
            _WinSound.Stop();
            _loseSound.Stop();
            _flippingSound.Stop();
        }

    }
}
