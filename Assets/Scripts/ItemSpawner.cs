using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Purpose: Spawn Random Item in Time Intervals
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] AnimationCurve diffCurve;
    [SerializeField] GameObject[] items;
    [SerializeField] Transform spawnPos;
    [SerializeField] float spawnTimer;
    bool onSpawnCooldown = false;

    // Update is called once per frame
    void Update()
    {
        if(!onSpawnCooldown){
            Spawn();
        }
    }

    //Spawn a random item
    void Spawn(){
        int randomIndex = Random.Range(0, items.Length);
        Instantiate(items[randomIndex], transform);
        StartCoroutine(StartSpawnCooldown());
    }

    //Keep Track of Spawner Cooldown
    IEnumerator StartSpawnCooldown(){
        onSpawnCooldown = true;

        //Reduces the spawn timer based on score
        spawnTimer = diffCurve.Evaluate(ScoreManager._instance.score);
        yield return new WaitForSeconds(spawnTimer);
        onSpawnCooldown = false;
    }
}
