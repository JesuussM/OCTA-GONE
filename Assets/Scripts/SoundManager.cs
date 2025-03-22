using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public AudioSource musicSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 0;
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip, volume);
        }
    }

    public void PlayMusic(AudioClip musicClip, float volume)
    {
        if (musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.volume = volume;
            musicSource.Play();
        }
    }

    public IEnumerator FadeInMusic(AudioSource source)
    {
        float targetVolume = 0.75f;
        float startVolume = source.volume;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / 1f);
            yield return null;
        }

        source.volume = targetVolume;
    }

    public IEnumerator FadeOutMusic(AudioSource source)
    {
        float targetVolume = 0f;
        float startVolume = source.volume;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / 1f);
            yield return null;
        }

        source.volume = targetVolume;
    }
}
