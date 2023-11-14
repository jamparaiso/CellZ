using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;

    private void Update()
    {
        transform.position = target.position + offSet;
    }

}//class
