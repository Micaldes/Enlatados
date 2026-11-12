using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;


public class Sound
{
    private Raylib_cs.Sound[] _sounds;

    private int _currentStep = 0; //Variable que permite alternar entre los distintos archivos de sonido asociados a un mismo Sound

    public Sound(string[] soundPaths) //Recibe un array de strings con los nombres de los distintos archivos de sonido asociados a un mismo Sound
    {
        _sounds = new Raylib_cs.Sound[soundPaths.Length];

        for(int i = 0; i < soundPaths.Length; i++)
        {
            _sounds[i] = Raylib.LoadSound(Path.Combine(AppContext.BaseDirectory, "Assets", "Sounds", soundPaths[i])); //Concatena el archivo con el directorio
        }
    }

    public void PlayStep()
    {
        if (_currentStep >= _sounds.Length)
            _currentStep = 0;

        Raylib.PlaySound(_sounds[_currentStep]);
        _currentStep++;

    }
}

