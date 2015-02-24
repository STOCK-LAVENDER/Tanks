namespace UltimateTankClash.Resources.Sounds
{
    using System.Media;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Media;

    public static class SoundHandler
    {
        public static void HandleBackgroundSoundEffect(Song song)
        {
            MediaPlayer.Play(song);
            
            MediaPlayer.Volume = 0.3f;
            MediaPlayer.IsRepeating = true;
        }

        public static void HandleDestroyObjectSoundEffect()
        {
            SoundPlayer soundPlayer = (new SoundPlayer(Resources.Sounds.MenuBackgroundMusic.Grenade_Explosion_SoundBible_com_2100581469_1));
            soundPlayer.Play();
        }
    }
}
