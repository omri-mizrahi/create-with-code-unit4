using UnityEngine;

public class KnockbackPowerup : MonoBehaviour
{
    #region Variables
    public float force = 20f;
    #endregion

    void OnCollisionEnter (Collision other) {
        if(other.gameObject.CompareTag(Consts.Tags.ENEMY) && PowerupsManager.CurrPowerup == Consts.Powerups.KNOCKBACK) {
            ApplyKnockback(other.gameObject);
        }
    }

    void ApplyKnockback(GameObject enemy) {
        Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
        Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;
        enemyRb.AddForce(force * knockbackDirection, ForceMode.Impulse);
    }
}
