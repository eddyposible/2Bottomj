using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating_script : MonoBehaviour {

	public Animator animator;
    public AudioManager audioManager;
	void Start () {
		animator = GetComponent <Animator> ();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
	
	public void Eat ()
	{
		animator.SetBool("Eat", true);

        audioManager.PlayAudioRandom("eatSound");

		StartCoroutine("ate");
	}

	IEnumerator ate ()
	{
		yield return new WaitForEndOfFrame();
		animator.SetBool("Eat", false);
	}
}
