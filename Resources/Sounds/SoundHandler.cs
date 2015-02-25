namespace UltimateTankClash.Resources.Sounds
{
    using System.Media;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Media;

    public static class SoundHandler
    {
        public static void HandleBackgroundSoundEffect()
        {
            SoundPlayer soundPlayer = new SoundPlayer(MenuBackgroundMusic.Failing_Defense);
            soundPlayer.PlayLooping();
        }

        public static void HandleDestroyObjectSoundEffect()
        {
            SoundPlayer soundPlayer = new SoundPlayer(MenuBackgroundMusic.Grenade_Explosion_SoundBible_com_2100581469_1);
            soundPlayer.Play();
        }
    }
}
