using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform cameraTarget;
    public Vector3 cameraOffset;

    public Vector2 minCameraPosition;
    public Vector2 maxCameraPosition; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void awake()
    {
        //cameraTarget = GameObject.Find("Mario").GetComponent<Transform>();
        cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTarget != null)
        {
            Vector3 desiredPosition = cameraTarget.position + cameraOffset;

            float clampX = Mathf.Clamp(desiredPosition.x, minCameraPosition.x, minCameraPosition.x);
            float clampY = Mathf.Clamp(desiredPosition.y, minCameraPosition.y, minCameraPosition.y);

            Vector3 clampePosition = new Vector3(clampX, clampY, desiredPosition.z);

            transform.position = clampePosition;
        } 
    }
}
