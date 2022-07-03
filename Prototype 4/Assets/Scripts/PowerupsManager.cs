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
        if(other.CompareTag(Consts.Tags.POWERUP)) {
            Destroy(other.gameObject);
            StartPowerup(other.name);
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
        powerupIndicator.SetActive(false);
    }
}
