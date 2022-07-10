using UnityEngine;

public class SmashPowerup : MonoBehaviour
{
    #region Variables
    public float jumpForce = 20f;
    public float maxHeight = 10f;
    public float fallVelocityMultiplier = 3f;
    public GameObject shockwave;

    Vector3 fallGravity;
    bool shouldSmash;
    bool isGrounded;
    bool shouldSendShockwave;
    Rigidbody rb;
    #endregion

    void Awake()
    {
        fallGravity = (fallVelocityMultiplier - 1) * Physics.gravity;
        shouldSmash = false;
        isGrounded = true;
        shouldSendShockwave = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        shouldSmash = Input.GetButtonDown(Consts.Input.USE_POWERUP) && isGrounded && PowerupsManager.CurrPowerup == Consts.Powerups.SMASH;
    }

    void FixedUpdate() {
        if(shouldSmash) {
            Smash();
            shouldSmash = false;
        }

        if(!isGrounded && (rb.velocity.y < 0 || transform.position.y >= maxHeight)) {
            ApplyFallGravity();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(!isGrounded) {
            if (collision.gameObject.CompareTag(Consts.Tags.GROUND)) {
                isGrounded = true;
            }
            if(shouldSendShockwave) {
                Vector3 shockwavePos = collision.GetContact(0).point;
                shockwavePos.y = 0;
                SendShockwave(shockwavePos);
            }
        }
    }

    void ApplyFallGravity() {
        rb.velocity = new Vector3(rb.velocity.x, fallGravity.y, rb.velocity.z);
    }

    void Smash() {
        Jump();
        shouldSendShockwave = true;
    }

    void Jump() {
        isGrounded = false;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void SendShockwave(Vector3 pos) {
        Instantiate(shockwave, pos, Quaternion.identity);
    }

}
