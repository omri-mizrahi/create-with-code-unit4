using UnityEngine;

public class KnockbackPowerup : MonoBehaviour
{
    #region Variables
    public float force = 20f;
    #endregion

    void OnCollisionEnter (Collision other) {
        if(other.gameObject.CompareTag(Consts.Tags.ENEMY) && PowerupsManager.currPowerup == Consts.Powerups.KNOCKBACK) {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;
            enemyRb.AddForce(force * knockbackDirection, ForceMode.Impulse);
        }
    }
}
