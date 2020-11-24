using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of Waves
    [SerializeField] List<WaveConfig> waveConfigsList;
    [SerializeField] bool looping = false;

    int startingWave = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        var currentWave = waveConfigsList[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        do
        {
            //start the coroutine to 0 (1st wave)
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //looping == true
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach(WaveConfig currentWave in waveConfigsList)
        { 
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave)); 
        }  
    }

    //call a coroutine to spawn enemies in wavetospawn
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn enemy from waveToSpawn at the poition
            //specified by the 1st waypoint(0) of waveToSpawn
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);
            //The wave will be selected from newEnemy and the Enemy applied to it
            //the wave will be selected from script and not from Unity
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }
}









































































































































