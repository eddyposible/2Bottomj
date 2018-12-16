using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class AudioManager : MonoBehaviour {

    public List<AudioPlayer> audioPlayersList;



    // Use this for initialization
    void Start () {





    }
    private void Awake()
    {
        if (!Application.isPlaying) { }
        audioPlayersList = new List<AudioPlayer>();
        foreach (AudioPlayer aP in GetComponentsInChildren(typeof(AudioPlayer)))
        {
            audioPlayersList.Add(aP);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}

    //All play methods should be passed  to the audiomanager using the name of 
    //the gameObject containing the desired AudioPlayer

    public void PlayAudioRandom(string name)
    {
        foreach(AudioPlayer aP in audioPlayersList)
        {
            if (aP.gameObject.name.Equals(name))
            {
               
                aP.PlayRandom();
            }

        }
      
        
    }
    public void PlayAudioSequence(string name)
    {
        foreach (AudioPlayer aP in audioPlayersList)
        {
            if (aP.gameObject.name.Equals(name))
            {
            
                aP.PlayNext();
            }

        }


    }
    public void ResetSequence(string name)
    {
        foreach (AudioPlayer aP in audioPlayersList)
        {
            if(aP.gameObject.name.Equals(name))
            {
                aP.ResetCounter();
            }
        }
    }
    public void StopAudioPlayer(string name)
    {
        foreach (AudioPlayer aP in audioPlayersList)
        {
            if (aP.gameObject.name.Equals(name))
            {
               
                aP.StopAll();
            }

        }


    }
   

  
}
