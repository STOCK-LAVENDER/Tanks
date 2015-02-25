namespace UltimateTankClash.Resources.Sounds
{
    using System.Media;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    public static class SoundHandler
    {
        public static void HandleBackgroundSoundEffect(SoundEffect backgroundSoundEffect)
        {
            SoundEffectInstance instance = backgroundSoundEffect.CreateInstance();
            instance.IsLooped = true;
            instance.Play();
        }

        public static void HandleGunShot()
        {
            SoundPlayer soundPlayer = new SoundPlayer(MenuBackgroundMusic.Gun_Shot_Marvin_1140816320_1);
            soundPlayer.Play();
        }
        public static void HandleDestroyObjectSoundEffect()
        {
            SoundPlayer soundPlayer = new SoundPlayer(MenuBackgroundMusic.Grenade_Explosion_SoundBible_com_2100581469_1);
            soundPlayer.Play();
        }
    }
}
