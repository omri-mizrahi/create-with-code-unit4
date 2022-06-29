using UnityEngine;

public class KnockbackAbillity : MonoBehaviour
{
    #region Variables
    public float powerupTime = 5f;
    public float force = 20f;
    public GameObject PowerupIndicator;

    bool hasPowerup;
    #endregion

    void Awake()
    {
        hasPowerup = false;
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Consts.Tags.POWERUP)) {
            Destroy(other.gameObject);
            StartPowerup();
        }
    }

    void OnCollisionEnter (Collision other) {
        if(other.gameObject.CompareTag(Consts.Tags.ENEMY) && hasPowerup) {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
            enemyRb.AddForce(force * knockbackDirection, ForceMode.Impulse);
        }
    }

    void StartPowerup() {
        CancelInvoke();
        hasPowerup = true;
        PowerupIndicator.SetActive(true);
        Invoke(nameof(StopPowerup), powerupTime);
    }

    void StopPowerup() {
        hasPowerup = false;
        PowerupIndicator.SetActive(false);
    }
}
