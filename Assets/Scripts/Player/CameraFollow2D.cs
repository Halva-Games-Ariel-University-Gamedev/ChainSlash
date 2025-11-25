using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;   // assign Player here in inspector
    public float smooth = 10f; // 0 = instant, higher = smoother

    void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = targetPos;

        transform.rotation = Quaternion.identity;
    }
}
