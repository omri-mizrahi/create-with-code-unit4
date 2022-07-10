using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    #region Variables
    public GameObject projectile;
    public float interval = 2f;
    #endregion

    void Awake()
    {
        InvokeRepeating(nameof(ShootProjectile), interval, interval);
    }

    void ShootProjectile()
    {
        Vector3 pos = transform.position;
        pos.y = projectile.transform.position.y;
        Instantiate(projectile, pos, projectile.transform.rotation);
    }
}
