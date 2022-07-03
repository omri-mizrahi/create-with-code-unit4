using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    #region Variables
    public float rotateSpeed;

    float horizontalInput;
    #endregion

    void Update()
    {
        horizontalInput = Input.GetAxis(Consts.Input.HORIZONTAL);
        transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
