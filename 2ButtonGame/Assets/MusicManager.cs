using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource[] mainMusicGroup;
    public AudioSource[] eliteMusicGroup;

    public AudioPlayer stingers;
    public float crossFadeTime;
    public float fadeInTime;
    public float fadeInTimeLong;
    public float fadeOutTime;
    public float musicMasterVolume =0.5f;//should be between 0 and 1
    private readonly float EPSILON = float.MinValue;
    private AudioSource[] currentMusicGroup;
    public int intensityLevel;

    // Use this for initialization
    void Start()
    {
        foreach(AudioSource aS in mainMusicGroup)
        {
            if(musicMasterVolume <= 1)
            {
                aS.volume = musicMasterVolume;
               
            }
        }
        foreach (AudioSource aS in eliteMusicGroup )
        {
            if (musicMasterVolume <= 1)
            {
                aS.volume = musicMasterVolume;
            }
        }
    }
    //specialized funktions for different scenarios

    public void PlayMainMusicFromStart()
    {
        StartMusic(mainMusicGroup, false, fadeInTime);
        currentMusicGroup = mainMusicGroup;
    }
    public void GoToEliteMusicFromMain()
    {
        PlayStinger("Stinger_Elite");
        StopAllCoroutines();
        FadeToStop(mainMusicGroup);
        StopMusic(eliteMusicGroup);
        StartMusic(eliteMusicGroup, true, fadeInTimeLong);
        currentMusicGroup = eliteMusicGroup;
    }

    public void GoToMainMusicFromElite()
    {
        StopAllCoroutines();
        FadeToStop(eliteMusicGroup);
        StartMusic(mainMusicGroup, true, fadeInTime);
        currentMusicGroup = mainMusicGroup;
    }
    public void IntensityUp()
    {

        if (currentMusicGroup.Length >intensityLevel)
        {
            intensityLevel++;
            StopAllCoroutines();
            SetMusicIntensity(currentMusicGroup, intensityLevel);
            print("intensity level :" + intensityLevel);
        }
   
    }
    public void IntensityDown()
    {
        
        if (intensityLevel>0)
        {
            intensityLevel--;
            StopAllCoroutines();
            SetMusicIntensity(currentMusicGroup, intensityLevel);
        }
   
    }
    public void SetIntensity(int intensity)
    {
        print("set intensity" + intensity);
        intensityLevel = intensity;
        StopAllCoroutines();
        SetMusicIntensity(currentMusicGroup, intensity);

    }
    public void StopAllMusic()
    {
        StopMusic(mainMusicGroup);
        StopMusic(eliteMusicGroup);
    }




    //general purpose functions for starting, stopping, fading and setting intensity

    public void StartMusic(AudioSource[] musicGroup, bool fadeIn, float fadeInTime)
    {
        for (int i = 0; i < musicGroup.Length; i++)
        {
            if (i == 0)
            {
                if (fadeIn)
                {
                    StartCoroutine(FadeIn(musicGroup[i], fadeInTime));
                }
                else
                {
                    musicGroup[i].volume = 1;
                }
            }
            else
            {
                musicGroup[i].volume = 0;

            }
        }

        for (int i = 0; i < musicGroup.Length; i++)
        {
            musicGroup[i].Play();
        }
    }
    public void SetMusicIntensity(AudioSource[] musicGroup, int layer)
    {
        //needs to fade between layers
        for (int i = 0; i < musicGroup.Length; i++)
        {
            if (i == layer)
            {
                StartCoroutine(FadeIn(musicGroup[i], crossFadeTime));

            }
            else
            {
                StartCoroutine(FadeOut(musicGroup[i], crossFadeTime));
            }
        }

    }


    public void PlayStinger(string stingerName)
    {
        stingers.PlayTarget(stingerName);
    }

    public void FadeOutGroup(AudioSource[] group)
    {
        for (int i = 0; i < group.Length; i++)
        {
            StartCoroutine(FadeOut(group[i], fadeOutTime));
        }
    }
    public void FadeInGroup(AudioSource[] group)
    {
        foreach (AudioSource aS in group)
        {
            StartCoroutine(FadeIn(aS, fadeInTime));
        }
    }


    public void StopMusic(AudioSource[] musicGroup)
    {
        // needs to stop all music;
        for (int i = 0; i < musicGroup.Length; i++)
        {
            musicGroup[i].Stop();
        }

    }
    public void FadeToStop(AudioSource[] group)
    {
        for (int i = 0; i < group.Length; i++)
        {
            StartCoroutine(FadeOutToStopCoroutine(group[i], fadeOutTime));
        }
    }
    // Update is called once per frame
    void Update()
    {
        //controls for testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartMusic(mainMusicGroup, false, fadeInTime);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopMusic(mainMusicGroup);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SetMusicIntensity(mainMusicGroup, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetMusicIntensity(mainMusicGroup, 1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetMusicIntensity(mainMusicGroup, 2);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            PlayStinger("Stinger_Elite");
            StopAllCoroutines();
            FadeToStop(mainMusicGroup);
            StopMusic(eliteMusicGroup);
            StartMusic(eliteMusicGroup, true, fadeInTimeLong);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StopAllCoroutines();
            SetMusicIntensity(eliteMusicGroup, 1);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {

            StopAllCoroutines();
            FadeToStop(eliteMusicGroup);
            StartMusic(mainMusicGroup, true, fadeInTime);

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            GoToMainMusicFromElite();
        }



    }
    public IEnumerator FadeOut(AudioSource audioSource, float fadeTime) //should fade out the music according to fadetime
    {
     
        print("Fadeout: " + audioSource);
        float startVolume = audioSource.volume;
        if (audioSource.volume == 0)
        {

            yield return null;

        }

        while (audioSource.volume > EPSILON)
        {
            if (audioSource.volume < 0.05)
            {
             //  print("fade out har set");
                audioSource.volume = 0;
                yield return null;
            }
            else
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;



                yield return null;
            }
        }


    }
    public IEnumerator FadeOutToStopCoroutine(AudioSource audioSource, float fadeTime) // fadeout to stop
    {
        print("Fadeout: " + audioSource);
        float startVolume = audioSource.volume;

        if(audioSource.volume ==0)
        {
            
            yield return null;
            
        }

        while (audioSource.volume > EPSILON)
        {
            if (audioSource.volume < 0.05)
            {

                audioSource.volume = 0;
                audioSource.Stop();
                yield return null;
            }
            else
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;



                yield return null;
            }
        }
       


    }
    public IEnumerator FadeIn(AudioSource audioSource, float fadeTime) // should fade in the music according to fadetime
    {
        float targetVolume = musicMasterVolume;

        if(audioSource.volume == targetVolume)
        {
            yield return null;
        }

        while (audioSource.volume < 0.999)
        {
            if (audioSource.volume > 0.95)
            {
                print("fadein hard set");
                audioSource.volume = targetVolume;
                yield return null;
            }
            else
            {
                audioSource.volume += targetVolume * Time.deltaTime / fadeTime;



                yield return null;
            }
        }


    }


}
