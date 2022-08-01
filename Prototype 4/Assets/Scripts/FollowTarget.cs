using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowTarget : MonoBehaviour
{
    #region Variables
    public float force;
    public string targetTag = "Player";
    
    Transform target;
    Rigidbody rb;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag(targetTag).transform;
    }

    void FixedUpdate() {
        Vector3 targetPos = target.position;
        Vector3 movementVector = targetPos - transform.position;
        float magnitude = movementVector.magnitude;
        if (magnitude > 1) {
            movementVector = movementVector / 2f;
        }
        rb.AddForce((force * Time.fixedDeltaTime) * movementVector);
    }
}
