using UnityEngine;

public class PowerupsManager : MonoBehaviour
{
    #region Variables
    public float powerupTime = 5f;
    public GameObject powerupIndicator;
    
    public static string CurrPowerup;
    #endregion

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == Consts.Layers.POWERUPS) {
            Destroy(other.gameObject);
            StartPowerup(other.tag);
        }
    }

    void StartPowerup(string type) {
        CancelInvoke();
        CurrPowerup = type;
        powerupIndicator.SetActive(true);
        Invoke(nameof(StopPowerup), powerupTime);
    }

    void StopPowerup() {
        CurrPowerup = null;
        powerupIndicator.SetActive(false);
    }
}
