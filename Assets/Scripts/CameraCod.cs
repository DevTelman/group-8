using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraCod : MonoBehaviour
{
 
    public Transform target;   

   
    public float offsetX = 3f;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}

