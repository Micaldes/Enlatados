using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

public class SoundSystem : IGameObject, IObserver<PlayerEventData>
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
            _sounds[sound.Key] = new Sound(sound.Value);
        }
    }
    public void Input()
    {

    }

    public void Update(float deltaTime)
    {

    }

    public void Render()
    {
        if(_playSoundQueue.Count > 0)
        {
            _sounds[_playSoundQueue.Dequeue()].PlayStep();
        }
    }

    public void OnUpdate(PlayerEventData data)
    {
        if(data.EventType == Events.PlayerShoots)
        {
            _playSoundQueue.Enqueue(SoundAssets.SoundID.Shoot);
        }

    }
}
