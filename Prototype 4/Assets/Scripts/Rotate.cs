using UnityEngine;

public class Rotate : MonoBehaviour
{
    #region Variables
    public float speed = 100f;
    public Vector3 rotateAround = new Vector3(0, 1, 0);
    #endregion

    void Update()
    {
        transform.Rotate(rotateAround, speed * Time.deltaTime);
    }
}
