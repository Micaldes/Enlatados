using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static EventId;
using static SoundAssets.SoundID;

public class SoundLoader : IService, IGameObject, IObserver<EventId>
{
    //Diccionario que asocia las ids con su Sound
    private Dictionary<SoundAssets.SoundID, Sound> _sounds = new Dictionary<SoundAssets.SoundID, Sound>();

    //Cola que contiene los sonidos pendientes de reproducirse
    private Queue<SoundAssets.SoundID> _playSoundQueue = new Queue<SoundAssets.SoundID>();

    public void Initialize()
    {
        Raylib.InitAudioDevice();

        //Por cada entrada del diccionario SoundFiles (definido en SoundAssets), asignamos al valor del nuevo diccionario _sounds
        //un Sound al que pasamos como argumento el array de strings que contiene el nombre de los archivos de sonido para cada Sound
        foreach (KeyValuePair<SoundAssets.SoundID, string[]> sound in SoundAssets.SoundFiles)
        {
            bool isMusic = sound.Key == MenuMusic; // Comprueba si la entrada corresponde a música de fondo
            float volume = (sound.Key == ExplosionSound) ? 10f : 0.5f;
            _sounds[sound.Key] = new Sound(sound.Value, isMusic);
        }
    }
    public void Input()
    {

    }

    public void Update(float deltaTime)
    {
        // Mantiene actualizado el flujo de reproducción de las pistas musicales activas
        foreach (Sound sound in _sounds.Values)
        {
            sound.UpdateStream();
        }
    }

    public void Render()
    {
        while (_playSoundQueue.Count > 0)
        {
            _sounds[_playSoundQueue.Dequeue()].PlayStep();
        }
    }

    public void OnUpdate(EventId data)
    {
        
        if (data == PlayerShoots)
        {
            _playSoundQueue.Enqueue(Shoot);
        }
        if (data == Impacts)
        {
            _playSoundQueue.Enqueue(Impacto);
        }
        if (data == LataDestroyed)
        {
            _playSoundQueue.Enqueue(ExplosionSound);
        }
    }

    // Método auxiliar para iniciar una pista de música directamente desde los estados/escenas
    public void PlayMusic(SoundAssets.SoundID musicId)
    {
        _playSoundQueue.Enqueue(musicId);
    }

    // Método auxiliar para detener una pista de música al salir de un estado/escena
    public void StopMusic(SoundAssets.SoundID musicId)
    {
        if (_sounds.ContainsKey(musicId))
        {
            _sounds[musicId].Stop();
        }
    }

    public void Destroy()
    {
        Raylib.CloseAudioDevice();
    }


}