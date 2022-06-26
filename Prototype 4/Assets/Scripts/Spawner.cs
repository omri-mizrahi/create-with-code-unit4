using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    #region Variables
    public float spawnRate = 2f;
    public List<GameObject> prefabs;
    public float spawnRadius = 10f;

    float spawnCooldown;
    bool prefabsListNotEmpty;
    #endregion

    void Awake() {
        prefabsListNotEmpty = prefabs.Count > 0;
    }

    void Start() {
        SetSpawnCooldown();
    }

    void Update() {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0 && prefabsListNotEmpty) {
            SetSpawnCooldown();
            SpawnRandomPrefab();
        }
    }

    void SpawnRandomPrefab() {
        GameObject rndPrefab = prefabs[Random.Range(0, prefabs.Count)];
        Vector3 pos = Random.insideUnitSphere * (spawnRadius);
        pos.y = rndPrefab.transform.position.y;
        Instantiate(rndPrefab, pos, rndPrefab.transform.rotation, transform);
    }

    void SetSpawnCooldown() {
        spawnCooldown = spawnRate;
    }
}
