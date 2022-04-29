using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float distance;
    float xmove, ymove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraView();
    }
    void CameraView()
    {
        xmove += Input.GetAxis("Mouse X");
        ymove -= Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(ymove, xmove, 0); 
        Vector3 reverseDistance = new Vector3(0, 0, distance);
        transform.position = playerTransform.position - transform.rotation * reverseDistance;
    }
}
