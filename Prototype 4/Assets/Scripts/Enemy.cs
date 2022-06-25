using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public float force;
    public Transform player;

    Rigidbody rb;
    Transform _transform;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _transform = transform;
    }

    void FixedUpdate() {
        Vector3 playerPos = player.position;
        Vector3 movementVector = playerPos - _transform.position;
        rb.AddForce((force * Time.deltaTime) * movementVector);
    }
}
