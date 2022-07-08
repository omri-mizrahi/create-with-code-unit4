using UnityEngine;

public class KnockbackPowerup : MonoBehaviour
{
    #region Variables
    public float force = 20f;
    #endregion

    void OnCollisionEnter (Collision collision) {
        if(collision.gameObject.CompareTag(Consts.Tags.ENEMY) && PowerupsManager.CurrPowerup == Consts.Powerups.KNOCKBACK) {
            Utils.ApplyKnockback(collision.gameObject, transform, force);
        }
    }
}
