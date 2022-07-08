using UnityEngine;

public static class Utils {
    public static void ApplyKnockback(GameObject target, Transform source, float force) {
        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        Vector3 knockbackDirection = (target.transform.position - source.position).normalized;
        targetRb.AddForce(force * knockbackDirection, ForceMode.Impulse);
    }
}
