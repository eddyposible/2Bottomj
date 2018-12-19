using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Spawner : MonoBehaviour {
	
	[ReorderableList]
	public List<GameObject> Enemies;

	[Header("Max and Min of Zone Y")]
	public float maxZone;
	public float minZone;
	public float realMinZone;
	public float realMaxZone;

	[Header("Timer:")]
	public float timeSinceStart = 10f;
	public float frequency;

	void Start () {
		Invoke("StartSpawning",timeSinceStart);
	}
	
	void StartSpawning()
	{
		StartCoroutine(Spawn());
	}

	void Update()
	{
		realMinZone = transform.position.y - minZone;
		realMaxZone = transform.position.y + maxZone;
	}

	IEnumerator Spawn ()
	{
		int enemySelector = Random.Range(0, Enemies.Count);
		GameObject.Instantiate(Enemies[enemySelector],new Vector3(transform.position.x,Random.Range(realMinZone,realMaxZone),transform.position.z),Quaternion.identity);
        yield return new WaitForSecondsRealtime(frequency);
        StartCoroutine(Spawn());
	}
}
