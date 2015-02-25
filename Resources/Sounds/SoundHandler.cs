namespace UltimateTankClash.Resources.Sounds
{
    using System.Media;
    using System.Windows.Forms;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    public static class SoundHandler
    {
        private static SoundEffectInstance backgroundGameSoundInstance;

        private static readonly SoundPlayer GunShotSoundPlayer = new SoundPlayer(MenuBackgroundMusic.Gun_Shot_Marvin_1140816320_1);

        private static readonly SoundPlayer DestroyHitSoundPlayer = new SoundPlayer(MenuBackgroundMusic.Grenade_Explosion_SoundBible_com_2100581469_1);

        public static bool isGameMuted;

        public static void HandleBackgroundSoundEffect(SoundEffect backgroundSoundEffect)
        {
            backgroundGameSoundInstance = backgroundSoundEffect.CreateInstance();
            backgroundGameSoundInstance.IsLooped = true;
            backgroundGameSoundInstance.Play();
        }

        public static void MuteBackgroundSounds()
        {
            if (isGameMuted)
            {
                backgroundGameSoundInstance.Pause();
                DestroyHitSoundPlayer.Stop();
                GunShotSoundPlayer.Stop();
            }
            else
            {
                backgroundGameSoundInstance.Resume();
            }
        }

        public static void HandleGunShot()
        {
            if (!isGameMuted)
            {
                GunShotSoundPlayer.Play();    
            }
        }

        public static void HandleDestroyObjectSoundEffect()
        {
            if (!isGameMuted)
            {
                DestroyHitSoundPlayer.Play();
            }
        }
    }
}
