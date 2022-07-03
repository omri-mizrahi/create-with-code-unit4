using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    #region Variables
    public float speed;

    GameObject closestEnemy;
    Rigidbody rb;
    #endregion

    void Awake()
    {
        closestEnemy = FindClosestEnemy();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(closestEnemy.transform);
        Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
        direction.y = 0;
        rb.velocity = (Time.deltaTime * speed) * direction;
        /* TODO:
        0. add rigidbody to missile prefab, assign prefab in "MissilePowerup"
        1. check to see if current code works
        2. think what to do when no enemy was foudn in FindClosestEnemy, maybe destry self
        3. add a knockback when missile collides with enemy
        4. add "missilePowerup" pickup to the spawner
        */
    }

    GameObject FindClosestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Consts.Tags.ENEMY);
        float minDist = float.PositiveInfinity;
        GameObject closestEnemy = null;
        Vector3 currPos = transform.position;
        foreach(GameObject enemy in enemies) {
            float dist = Vector3.Distance(currPos, enemy.transform.position);
            if(dist < minDist) {
                closestEnemy = enemy;
                minDist = dist;
            }
        }
        return closestEnemy;
    }
}
