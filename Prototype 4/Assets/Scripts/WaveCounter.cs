using UnityEngine;
using TMPro;

public class WaveCounter : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI waveText;
    #endregion

    void Awake()
    {
        waveText = GetComponent<TextMeshProUGUI>();
    }

    void LateUpdate()
    {
        waveText.text = Spawner.WaveCount.ToString();
    }
}
