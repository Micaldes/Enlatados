using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;


public class Sound
{
    private Raylib_cs.Sound[] _sounds;
    private Raylib_cs.Music _music; // Almacena el flujo de audio si se trata de música de fondo
    private bool _isMusic; // Indica si esta instancia gestiona música continua en lugar de efectos puntuales

    private int _currentStep = 0; //Variable que permite alternar entre los distintos archivos de sonido asociados a un mismo Sound

    public Sound(string[] soundPaths, bool isMusic = false) //Recibe un array de strings con los nombres de los distintos archivos de sonido asociados a un mismo Sound
    {
        _isMusic = isMusic;

        if (_isMusic)
        {
            // Carga el archivo como stream de música y activa la reproducción en bucle
            string fullPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds", soundPaths[0]);
            _music = Raylib.LoadMusicStream(fullPath);
            _music.Looping = true;
        }
        else
        {
            _sounds = new Raylib_cs.Sound[soundPaths.Length];

            for (int i = 0; i < soundPaths.Length; i++)
            {
                _sounds[i] = Raylib.LoadSound(Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds", soundPaths[i])); //Concatena el archivo con el directorio
            }
        }
    }

    public void PlayStep()
    {
        if (_isMusic)
        {
            // Solo inicia la reproducción si no estaba sonando ya, evitando cortes o reinicios entre pantallas
            if (!Raylib.IsMusicStreamPlaying(_music))
            {
                Raylib.PlayMusicStream(_music);
            }
            return;
        }

        if (_currentStep >= _sounds.Length)
            _currentStep = 0;

        Raylib.PlaySound(_sounds[_currentStep]);
        _currentStep++;
    }

    public void UpdateStream()
    {
        // Actualiza el búfer de audio en cada frame mientras la música esté sonando
        if (_isMusic && Raylib.IsMusicStreamPlaying(_music))
        {
            Raylib.UpdateMusicStream(_music);
        }
    }

    public void Stop()
    {
        // Detiene la reproducción del stream musical
        if (_isMusic)
        {
            Raylib.StopMusicStream(_music);
        }
    }
}