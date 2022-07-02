using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region Variables
    public List<GameObject> enemies;
    public List<GameObject> powerups;
    public float spawnRadius = 10f;

    bool prefabsListNotEmpty;
    int waveSize;
    #endregion

    void Awake() {
        prefabsListNotEmpty = enemies.Count > 0;
        waveSize = 1;
    }

    void Update() {
        if (transform.childCount == 0 && prefabsListNotEmpty) {
            SpawnWave(waveSize);
            waveSize++;
        }
    }


    void SpawnWave(int waveSize) {
        for(int i = 0; i < waveSize; i++) {
            SpawnRandomPrefab(enemies, transform);
            if(i % 2 == 1) {
                SpawnRandomPrefab(powerups, null);
            }
        }
    }

    void SpawnRandomPrefab(List<GameObject> prefabList, Transform parent) {
        GameObject rndPrefab = prefabList[Random.Range(0, prefabList.Count)];
        Vector3 pos = GenerateRandomPos();
        pos.y = rndPrefab.transform.position.y;
        Instantiate(rndPrefab, pos, rndPrefab.transform.rotation, parent);
    }

    Vector3 GenerateRandomPos() {
        return Random.insideUnitSphere * (spawnRadius);
    }
}
