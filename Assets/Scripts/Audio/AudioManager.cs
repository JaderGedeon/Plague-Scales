using UnityEngine.Audio;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup[] mixerGroup;
    public bool inPause = false;

    private float m_timer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Start()
    {
        foreach(Sound sound in sounds)
        {
            if(sound.isMusic == true)
            {
                sound.source.outputAudioMixerGroup = mixerGroup[0];
            }
            else
            {
                sound.source.outputAudioMixerGroup = mixerGroup[1];
            }
        }
    }

    private void Update()
    {
        float randomRoar = Random.Range(1f, 5f);
        m_timer += 1.5f * Time.deltaTime;
        if (randomRoar < 3 &&  m_timer > 20)
        {
            Play("Roar");
            print("Com Roar");
            m_timer = 0;
        }
    }

    public void Play (string name)
    {
        if (!inPause)
        {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            if (sound == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            sound.source.Play();
        }
        
    }

    public void Pause()
    {
        foreach (Sound sound in sounds)
        {
            if (sound == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            sound.source.Pause();
        }
    }

    public void UnPause()
    {
        foreach (Sound sound in sounds)
        {
            if (sound == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            sound.source.UnPause();
        }
    }
}
