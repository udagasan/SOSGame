using Common;
using System.Media;
using System.Threading;

namespace Server
{
    public class SoundController
    {
        Model Model { get; set; }

        string SosSoundPath { get; } = @"D:\GentleTeam\SosGame\Solution\Common\Sources\drowSound.wav";

        string GameMusicPath { get; } = @"D:\GentleTeam\SosGame\Solution\Common\Sources\Music.wav";

        public SoundController(Model model)
        {
            Model = model;
        }
        public void PlaySosSound()
        {
            if (!Model.IsSosSoundActive)
            {
                return;
            }
            var p2 = new System.Windows.Media.MediaPlayer();
            p2.Open(new System.Uri(SosSoundPath));
            p2.Play();

        }
        public void PlayGameMusic()
        {
            using (var musicSoundPlayer = new SoundPlayer(GameMusicPath))
            {
                if (Model.IsMusicActive)
                {
                    musicSoundPlayer.PlayLooping();
                    return;
                }

                musicSoundPlayer.Stop();
            }
        }
    }
}
