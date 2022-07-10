using UnityEngine;
using System.Collections.Generic;

public static class Utils {
    public static void ApplyKnockback(GameObject target, Transform source, float force) {
        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        Vector3 knockbackDirection = (target.transform.position - source.position).normalized;
        targetRb.AddForce(force * knockbackDirection, ForceMode.Impulse);
    }

    public static void SpawnRandomPrefab(List<GameObject> prefabList, Transform parent) {
        GameObject rndPrefab = prefabList[Random.Range(0, prefabList.Count)];
        Vector3 pos = GenerateRandomPos();
        pos.y = rndPrefab.transform.position.y;
        GameObject.Instantiate(rndPrefab, pos, rndPrefab.transform.rotation, parent);
    }

    public static Vector3 GenerateRandomPos() {
        return Random.insideUnitSphere * (Consts.Config.SPAWN_RADIUS);
    }
}
