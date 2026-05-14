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
        // Instancia única (Singleton simplificado)
        public static ISoundService Instance { get; private set; }
        private readonly SoundPlayer _flipSound;
        private readonly SoundPlayer _WinSound;
        private readonly SoundPlayer _loseSound;
        private readonly SoundPlayer _flippingSound;
        private readonly SoundPlayer _relevantSound;
        private readonly SoundPlayer _irrelevantSound;
        private readonly SoundPlayer _loadingSuccesfull;

        public SoundService()
        {
            Instance = this; // Asignamos la instancia actual a la propiedad estática para que sea accesible desde cualquier parte de la aplicación
            // Properties.Resources apuntará a los archivos que metiste en esta capa
            _flipSound = new SoundPlayer(Properties.Resources._flip);
            _WinSound = new SoundPlayer(Properties.Resources._win);
            _loseSound = new SoundPlayer(Properties.Resources._lose);
            _flippingSound = new SoundPlayer(Properties.Resources._cardsFlipping);
            _relevantSound = new SoundPlayer(Properties.Resources._buttonClickRelevant);
            _irrelevantSound = new SoundPlayer(Properties.Resources._buttonClickCommon);
            _loadingSuccesfull = new SoundPlayer(Properties.Resources._loadingSuccesfull);
        }
        public void PlayFlip() => _flipSound.Play();
        public void PlayFlippingCards() => _flippingSound.Play();
        public void PlayWin() => _WinSound.Play();
        public void PlayGameOver() => _loseSound.Play();
        public void PlayRelevantButton() => _relevantSound.Play();
        public void PlayIrrelevantButton() => _irrelevantSound.Play();
        public void PlayLoadingSuccesfull() => _loadingSuccesfull.Play();
        public void StopMusic() { 
            _flipSound.Stop();
            _WinSound.Stop();
            _loseSound.Stop();
            _flippingSound.Stop();
            _relevantSound.Stop();
            _irrelevantSound.Stop();
        }

    }
}
