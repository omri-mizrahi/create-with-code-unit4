using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float force;
    public Transform focalPoint;

    float verticalInput;
    float horizontalInput;
    Rigidbody rb;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis(Consts.VERTICAL_INPUT);
        horizontalInput = Input.GetAxis(Consts.HORIZONTAL_INPUT);
    }

    void FixedUpdate() {
        rb.AddForce((force * Time.deltaTime * verticalInput) * focalPoint.forward);
        rb.AddForce((force * Time.deltaTime * horizontalInput) * focalPoint.right);
    }
}
