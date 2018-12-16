﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectSpawner {
    public bool start;
    public List<Enemy> enemies;
    public int enemySelector;
    public float verticalSpawnRange;
    public float timeSinceStart = 15f;
   

    public float frequency;
	
	void Start ()
    {
        Invoke("StartCo",timeSinceStart);
    }

    void StartCo()
    {
        StartCoroutine(SpawnCoroutine());
    }

    //spawns an enemy with random properties
    IEnumerator SpawnCoroutine()
    {
        enemySelector = Random.Range(0, enemies.Count);
        Vector3 randomVector = new Vector3(transform.position.x, transform.position.y + Random.Range(-verticalSpawnRange, verticalSpawnRange), transform.position.z);
        GameObject.Instantiate(enemies[enemySelector],randomVector,transform.rotation);
        yield return new WaitForSeconds(frequency);
        StartCoroutine(SpawnCoroutine());
    }
}
