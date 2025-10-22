using UnityEngine;

public class CameraController : MonoBehaviour
{
    // private Transform target;
    public PlayerPosition pos;

    [Header("Follow settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset;

    void Start()
    {
        // target = PlayerMovement.instance.gameObject.transform;
    }
    private void LateUpdate()
    {
        if (pos == null)
            return;

        Vector3 desiredPosition = new Vector3(
            pos.position.x + offset.x,
            pos.position.y + offset.y,
            -10f
        );

        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;
    }
}
