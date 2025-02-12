using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Header("GameObject")]
    public Transform player1;
    public Transform player2;
    private Camera cam;

    [Header("Parametre")]
    public float smoothSpeed = 0.1f; // Vitesse follow camera
    private Vector3 velocity;
    

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 midPoint = (player1.position + player2.position) / 2f;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(midPoint.x, midPoint.y, transform.position.z), ref velocity, smoothSpeed);
    }
}
