using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class SoundAssets
{
    public enum SoundID
    {
        Shoot,
        MenuMusic,

        GameMusic,

        Impacto,
        ExplosionSound
    }

    public static readonly Dictionary<SoundID, string[]> SoundFiles = new Dictionary<SoundID, string[]>()
    {
        [SoundID.Shoot] = ["Shoot.mp3"],
        [SoundID.MenuMusic] = ["Cantina_song.mp3"],
        [SoundID.GameMusic] = ["GameMusic.mp3"],
        [SoundID.Impacto] = ["Sonido de Disparo en Metal.mp3"],
        [SoundID.ExplosionSound] = ["Small Explosion.mp3"]
    };
}
