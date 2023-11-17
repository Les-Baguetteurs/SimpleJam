using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }

    public AudioMixerGroup mixerGroup;

    private Sound scheduledSound;
    private AudioSource[] audioSources = new AudioSource[2];
    private int flip = 0;

    private double nextEventTime;

    public Sound[] sounds;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // This can probably go away now that we're using the audio in scheduler now but it stays for now
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    void Start()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
		nextEventTime = AudioSettings.dspTime;
        SetScheduledSound("stage1");
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // I feel like this wasn't such a good idea

        // s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        // s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Play();
    }

    void Update()
    {
        if (AudioSettings.dspTime + 1 > nextEventTime)
        {
            ScheduleScheduledSound();
        }
    }

    public void SetScheduledSound(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        scheduledSound = s;
    }

    private void ScheduleScheduledSound()
    {
        double startTime = nextEventTime;
		audioSources[flip].clip = scheduledSound.clip;
        audioSources[flip].PlayScheduled(nextEventTime);
		
        nextEventTime += audioSources[flip].clip.length;
        flip = 1 - flip;
    }
    public void OnGameOver()
    {
        SetScheduledSound("stage1");
    }
}
