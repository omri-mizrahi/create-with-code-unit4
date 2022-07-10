using UnityEngine;
using System.Collections.Generic;

/*
TODO:
1. create a boss prefab that spawns minions
2. add boss prefab to bosses list in spawner
3. test
4. create and add another boss prefab that shoots projectiles
*/

public class Spawner : MonoBehaviour
{
    #region Variables
    public List<GameObject> enemies;
    public List<GameObject> powerups;
    public List<GameObject> bosses;
    [Tooltip("Boss battle every X waves")]
    public int bossWaveInterval = 5;
    
    public float spawnRadius = 10f;
    public int enemyToPowerupRatio = 3;
    public int powerupToBossRatio = 2;

    bool enemiesNotEmpty;
    bool bossesNotEmpty;
    bool powerupsNotEmpty;
    int waveCount;
    #endregion

    void Awake() {
        enemiesNotEmpty = enemies.Count > 0;
        bossesNotEmpty = bosses.Count > 0;
        powerupsNotEmpty = powerups.Count > 0;
        waveCount = 1;
    }

    void Update() {
        if (transform.childCount == 0 && enemiesNotEmpty) {
            if (waveCount % bossWaveInterval == 0 && bossesNotEmpty) {
                SpawnBoss();
            } else {
            SpawnWave(waveCount);
            }
            waveCount++;
        }
    }

    void SpawnBoss() {
        Utils.SpawnRandomPrefab(bosses, transform);
        if (powerupsNotEmpty) {
            for (int i = 0; i < powerupToBossRatio; i++) {
                Utils.SpawnRandomPrefab(powerups, null);
            }
        }
    }

    void SpawnWave(int waveSize) {
        for (int i = 1; i <= waveSize; i++) {
            Utils.SpawnRandomPrefab(enemies, transform);
            if(i % enemyToPowerupRatio == 0 && powerupsNotEmpty) {
                Utils.SpawnRandomPrefab(powerups, null);
            }
        }
    }
}
