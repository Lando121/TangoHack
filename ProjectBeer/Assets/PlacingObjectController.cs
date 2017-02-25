using UnityEngine;
using System.Collections;

public class PlacingObjectController : MonoBehaviour
{
    public GameObject m_object;
    private TangoPointCloud m_pointCloud;
    private int placedObjects = 0;

    void Start()
    {
        m_pointCloud = FindObjectOfType<TangoPointCloud>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Trigger place kitten function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                if(placedObjects < 2)
                {
                    Debug.Log(placedObjects);
                    placedObjects++;
                    placeObject(t.position);

                }
            }
        }
    }

    void placeObject(Vector2 touchPosition)
    {
        // Find the plane.
        Camera cam = Camera.main;
        Vector3 planeCenter;
        Plane plane;
        if (!m_pointCloud.FindPlane(cam, touchPosition, out planeCenter, out plane))
        {
            Debug.Log("cannot find plane.");
            return;
        }

        // Place Object on the surface, and make it always face the camera.
            Vector3 up = plane.normal;
            Vector3 right = Vector3.Cross(plane.normal, cam.transform.forward).normalized;
            Vector3 forward = Vector3.Cross(right, plane.normal).normalized;
            Instantiate(m_object, planeCenter, Quaternion.LookRotation(forward, up));
        
      
    }
}