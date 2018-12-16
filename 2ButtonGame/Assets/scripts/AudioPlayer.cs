using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
	public AudioSource audioSource;
    public List<AudioClip>  audioClips;


	public int nonRepeatNumber;
	bool hasPlayed;
	int randomNumber;
	List<int> oldRandoms;
	public float pitchRandomization;
	public float[] oldVolume;
    public int count=0;
    public string[] namesForTargeting; // Should be made to match in list order with audioClips so either name all files or just mind the ordering in the editor
    Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
 


 
	// Use this for initialization
	void Start () {
        oldRandoms = new List<int>();
        int nameCounter = 0;
        //super weird way to add names for targeting audioclips by name but couldt not figure it out
       foreach (string name in namesForTargeting)
        {

            clips.Add(name, audioClips[nameCounter]);
                nameCounter++;
        }



    }



    private void Awake()
{


    }

    //plays a random audioClip not including the last X played, where is the nonRepeatNumber value
    public void PlayRandom()
	{
		randomNumber = Random.Range (0, audioClips.Count);

		if (nonRepeatNumber < audioClips.Count) {
			
			while (oldRandoms.IndexOf (randomNumber) != -1) {
				randomNumber = Random.Range (0, audioClips.Count);
			}

			oldRandoms.Add (randomNumber); 
			audioSource.pitch = 1 + Random.Range (-pitchRandomization, pitchRandomization);
            audioSource.clip = audioClips[randomNumber];   
			audioSource.Play();
            count = randomNumber;
			//Debug.Log (audioSources [randomNumber] + " is playing");
		} else 
		{
			Debug.Log ("numberOfPreviouslyPlayedToAvoid is too high");
		}

		if (oldRandoms.Count >= nonRepeatNumber) 
		{
			oldRandoms.RemoveAt(0);  
		}
	}
    //players in sequence from start
    public void PlayNext()
    {
        audioSource.clip = audioClips[count];
        count++;
    }
    // plays a specifik audioclip looking for parent object name as a string
    public void PlayTarget(string targetName)
    {

        audioSource.PlayOneShot(clips[targetName]);


    }
    //stops audio
    public void StopAll()
	{
		for (int i = 0; i < audioClips.Count; i++) 
		{
			oldVolume [i] = audioSource.volume;
			audioSource.volume = 0; 
			 
			audioSource.Stop();  
			audioSource.volume = oldVolume[i] ; 
		}
	}
    public void ResetCounter()
    {
        count = 0;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
