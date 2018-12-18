using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightbeam : MonoBehaviour {

	public float speed;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }
    void Update () {
		transform.position += Vector3.right * speed* Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Elite"){
			
			Elite_behaviour elite =	other.GetComponent<Elite_behaviour>();
            elite.life = elite.life - 1;
            audioManager.PlayAudioRandom("enemyDeath");
			Destroy(this.gameObject);

		}
	}
}
