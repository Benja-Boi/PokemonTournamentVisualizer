using UnityEngine;

public class SimpleMover : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float zoomSpeed = 3f;
    private Transform _transform;
    private Camera _cam;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetButton("Up"))
        {
            _transform.position += moveSpeed * Time.deltaTime * Vector3.up;
        }
        
        if (Input.GetButton("Down"))
        {
            _transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        }
        
        if (Input.GetButton("Right"))
        {
            _transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
        
        if (Input.GetButton("Left"))
        {
            _transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
        
        if (Input.GetButton("In"))
        {
            _cam.orthographicSize -= zoomSpeed * Time.deltaTime;
        }
        
        if (Input.GetButton("Out"))
        {
            _cam.orthographicSize += zoomSpeed * Time.deltaTime;
        }
    }
}
