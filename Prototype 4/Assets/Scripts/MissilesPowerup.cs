using UnityEngine;

public class MissilesPowerup : MonoBehaviour
{
    #region Variables
    public GameObject missilePrefab;
    #endregion

    void Update()
    {
        if(Input.GetButtonDown(Consts.Input.USE_POWERUP) && PowerupsManager.CurrPowerup == Consts.Powerups.MISSILES) {
            ShootMissile();
        }
    }

    void ShootMissile() {
        Vector3 pos = transform.position;
        pos.y = missilePrefab.transform.position.y;
        Instantiate(missilePrefab, pos, missilePrefab.transform.rotation);
    }
}
