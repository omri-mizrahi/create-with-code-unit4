using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    #region Variables
    public float powerupTime = 5f;
    public GameObject powerupIndicator;
    
    public static bool hasPowerup;
    public static string currPowerup;
    #endregion

    
    void Awake()
    {
        hasPowerup = false;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == Consts.Layers.POWERUPS) {
            Destroy(other.gameObject);
            StartPowerup(other.tag);
        }
    }

    void StartPowerup(string type) {
        CancelInvoke();
        hasPowerup = true;
        currPowerup = type;
        powerupIndicator.SetActive(true);
        Invoke(nameof(StopPowerup), powerupTime);
    }

    void StopPowerup() {
        hasPowerup = false;
        currPowerup = null;
        powerupIndicator.SetActive(false);
    }
}
