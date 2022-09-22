using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX, soundFX2,musicAudioSource;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip, starClip;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        musicAudioSource.Stop();
        soundFX.Play();
    }

    public void StarSound()
    {
        soundFX2.clip = starClip;
        soundFX2.Play();
    }
}