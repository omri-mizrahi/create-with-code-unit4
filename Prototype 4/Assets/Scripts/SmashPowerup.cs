using UnityEngine;

/* TODO:
4. implemetn the knockback wave mechanic - search for enemis by tag, loop them and knockback by distance 
        (low distance = stronger knocback, too much distnce = 0 knocbkac)
*/

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
        if(collision.gameObject.CompareTag(Consts.Tags.GROUND) && !isGrounded) {
            isGrounded = true;
            if(shouldSendShockwave) {
                SendShockwave(collision.GetContact(0).point);
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
