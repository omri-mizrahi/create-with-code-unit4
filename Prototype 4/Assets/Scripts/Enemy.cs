using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public float force;
    
    Transform player;
    Rigidbody rb;
    Transform _transform;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _transform = transform;
        player = GameObject.FindWithTag(Consts.Tags.PLAYER).transform;
    }

    void FixedUpdate() {
        Vector3 playerPos = player.position;
        Vector3 movementVector = playerPos - _transform.position;
        float magnitude = movementVector.magnitude;
        if (magnitude > 1) {
            movementVector = movementVector / 2f;
        }
        rb.AddForce((force * Time.deltaTime) * movementVector);
    }
}
