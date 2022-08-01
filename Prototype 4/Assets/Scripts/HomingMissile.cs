using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    #region Variables
    public string targetTag = "Enemy";
    public float speed;
    public float force = 20f;
    public Vector3 rotationOffset = new Vector3(0, 90, 90);

    GameObject closestTarget;
    Rigidbody rb;
    #endregion

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        closestTarget = FindClosestTarget();
    }

    void Update()
    {
        if(!closestTarget) {
            closestTarget = FindClosestTarget();
        }
    }

    void FixedUpdate() {
        transform.LookAt(closestTarget.transform);
        transform.Rotate(rotationOffset);
        transform.Translate((Time.fixedDeltaTime * speed) * transform.right, Space.Self);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(targetTag)) {
            Destroy(gameObject);
            Utils.ApplyKnockback(other.gameObject, transform, force);
        }
    }

    GameObject FindClosestTarget() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        float minDist = float.PositiveInfinity;
        GameObject closestTarget = null;
        Vector3 currPos = transform.position;
        foreach(GameObject target in targets) {
            float dist = Vector3.Distance(currPos, target.transform.position);
            if(dist < minDist) {
                closestTarget = target;
                minDist = dist;
            }
        }
        return closestTarget;
    }
}
