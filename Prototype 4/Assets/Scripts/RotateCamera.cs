using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    #region Variables
    public float rotateSpeed;

    float horizontalInput;
    #endregion

    void Update()
    {
        horizontalInput = Input.GetAxis(Consts.HORIZONTAL_INPUT);
        transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
