using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating_script : MonoBehaviour {

	public Animator animator;

	void Start () {
		animator = GetComponent <Animator> ();
	}
	
	public void Eat ()
	{
		animator.SetBool("Eat", true);
		StartCoroutine("ate");
	}

	IEnumerator ate ()
	{
		yield return new WaitForEndOfFrame();
		animator.SetBool("Eat", false);
	}
}
