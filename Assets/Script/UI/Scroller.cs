using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    private bool _onDrag = false;

    private Vector3 _prevMousePosition;
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _prevMousePosition = Input.mousePosition;
            _onDrag = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _onDrag = false;
        }

        if (_onDrag)
        {
            OnDrag();
        }
    }

    public void OnDrag()
    {
        var delta = Input.mousePosition - _prevMousePosition;
        _prevMousePosition = Input.mousePosition;
        
        _mainCamera.transform.position += new Vector3(0, -delta.y * Constant.DragSpeed, 0);
        float clampY = Math.Clamp(_mainCamera.transform.position.y, -21, 21);
        _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, clampY, _mainCamera.transform.position.z);
    }
}
