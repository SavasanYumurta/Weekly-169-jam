using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Gemi, Top;
    public Transform takip1, takip2;
    private Camera cam;
    public bool topVarmi,bos;
    public void Start()
    {
        cam = this.GetComponent<Camera>();
        bos = true;
    }
    public void Update()
    {
        if (topVarmi)
        {
            this.transform.SetParent(null);
            takip1 = Gemi;
            takip2 = Top;
            FixedCameraFollowSmooth(cam, takip1, takip2);
        }
        else if (bos)
        {
            bos = false;
            this.transform.SetParent(Gemi);
            this.transform.localPosition = new Vector3(5.77002f, 3.13001f,-10);
            cam.orthographicSize = 10;
        }
    }
    // Follow Two Transforms with a Fixed-Orientation Camera
    public void FixedCameraFollowSmooth(Camera cam, Transform t1, Transform t2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
