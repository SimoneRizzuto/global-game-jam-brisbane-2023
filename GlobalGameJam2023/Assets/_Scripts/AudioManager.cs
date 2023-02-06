using System;
using UnityEngine;
using UnityEngine.Audio;


/// <summary>
/// Author/Editors: Adrian Barrett
/// 
/// Description: This script handles sounds in an slightly more accessible way. 
/// 
/// </summary>

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.group;
            s.source.playOnAwake = s.playOnAwake;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (s.playOnAwake) s.source.Play();
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void ChangeMusic(string newMusic)
    {
        foreach (Sound s in sounds)
        {
            if(s.source.isPlaying && s.music)
            {
                s.source.Stop();
            }
        }
        Play(newMusic);
    }

    public void StopAllAudio()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
