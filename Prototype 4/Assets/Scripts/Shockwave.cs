using UnityEngine;

public class Shockwave : MonoBehaviour
{
    #region Variables
    public float speed = 5f;
    public float maxSize = 15f;
    public float forceMultiplier = 5f;

    Vector3 scaleChange;
    #endregion

    void Awake()
    {
        scaleChange = new Vector3(speed, 0, speed);
    }

    void Update()
    {
        transform.localScale += scaleChange * Time.deltaTime;
        if(transform.localScale.x >= maxSize) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(Consts.Tags.ENEMY)) {
            float size = transform.localScale.x;
            float force = (maxSize + 1f - size) * forceMultiplier;
            Utils.ApplyKnockback(other.gameObject, transform, force);
        }
    }
}
