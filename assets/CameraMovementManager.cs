using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

[RequireComponent(typeof(Camera))]
public class CameraMovementManager : MonoBehaviour
{
    public Vector3 originPos;
    public float originSize;
    private Vector3 _memoryPos;
    private float _memorySize;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void RememberSettings()
    {
        _memoryPos = transform.position;
        _memorySize = _camera.orthographicSize;
    }

    public void SnapToOrigin()
    {
        transform.position = originPos;
        _camera.orthographicSize = originSize;
    }

    public void SnapToMemory()
    {
        transform.position = _memoryPos;
        _camera.orthographicSize = _memorySize;
    }
}
