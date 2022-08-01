using UnityEngine;
using System.Collections.Generic;

public class SpawnMinions : MonoBehaviour
{
    #region Variables
    public List<GameObject> minions;
    public float interval = 5f;
    public int minionsEveryInterval = 2;
    #endregion

    void Start()
    {
        InvokeRepeating(nameof(SpawnMinionWave), 0, interval);
    }

    void SpawnMinionWave()
    {
        for (int i = 0; i < minionsEveryInterval; i++)
        {
            Utils.SpawnRandomPrefab(minions, transform.parent);
        }
    }
}