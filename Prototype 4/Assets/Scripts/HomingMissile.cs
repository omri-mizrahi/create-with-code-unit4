using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    #region Variables
    public float speed;
    public float force = 20f;
    public Vector3 rotationOffset = new Vector3(0, 90, 90);

    GameObject closestEnemy;
    Rigidbody rb;
    #endregion

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        closestEnemy = FindClosestEnemy();
    }

    void Update()
    {
        if(!closestEnemy) {
            closestEnemy = FindClosestEnemy();
        }
    }

    void FixedUpdate() {
        transform.LookAt(closestEnemy.transform);
        transform.Rotate(rotationOffset);
        transform.Translate((Time.fixedDeltaTime * speed) * transform.right, Space.Self);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Consts.Tags.ENEMY)) {
            Destroy(gameObject);
            Utils.ApplyKnockback(other.gameObject, transform, force);
        }
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
