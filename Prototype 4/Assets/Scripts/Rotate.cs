using UnityEngine;

public class Rotate : MonoBehaviour
{
    #region Variables
    public float speed;
    public Vector3 rotateAround;
    #endregion

    void Update()
    {
        transform.Rotate(rotateAround, speed * Time.deltaTime);
    }
}
