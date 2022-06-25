using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float force;
    public Transform focalPoint;

    float verticalInput;
    Rigidbody rb;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis(Consts.VERTICAL_INPUT);
    }

    void FixedUpdate() {
        rb.AddForce((force * Time.deltaTime * verticalInput) * focalPoint.forward);
    }
}
