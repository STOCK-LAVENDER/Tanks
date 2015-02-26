namespace UltimateTankClash.Resources.Sounds
{
    using System.Media;
    using Microsoft.Xna.Framework.Audio;

    public static class SoundHandler
    {
        public static bool IsGameMuted;
        private static readonly SoundPlayer GunShotSoundPlayer = new SoundPlayer(MenuBackgroundMusic.Gun_Shot_Marvin_1140816320_1);
        private static readonly SoundPlayer DestroyHitSoundPlayer = new SoundPlayer(MenuBackgroundMusic.Grenade_Explosion_SoundBible_com_2100581469_1);
        private static SoundEffectInstance backgroundGameSoundInstance;

        public static void HandleBackgroundSoundEffect(SoundEffect backgroundSoundEffect)
        {
            backgroundGameSoundInstance = backgroundSoundEffect.CreateInstance();
            backgroundGameSoundInstance.IsLooped = true;
            backgroundGameSoundInstance.Play();
        }

        public static void MuteBackgroundSounds()
        {
            if (IsGameMuted)
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
            if (!IsGameMuted)
            {
                GunShotSoundPlayer.Play();    
            }
        }

        public static void HandleDestroyObjectSoundEffect()
        {
            if (!IsGameMuted)
            {
                DestroyHitSoundPlayer.Play();
            }
        }
    }
}
