namespace UltimateTankClash.Resources.Sounds
{
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Media;

    public static class SoundHandler
    {
        public static void HandleBackgroundSoundEffect(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
    }
}
