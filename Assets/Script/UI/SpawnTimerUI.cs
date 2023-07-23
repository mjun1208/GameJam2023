using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimerUI : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CraftingTable _craftingTable;
    [SerializeField] private RectTransform _canvas;
    
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ViewportPosition = _mainCamera.WorldToViewportPoint(_craftingTable.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * _canvas.sizeDelta.x) - (_canvas.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * _canvas.sizeDelta.y) - (_canvas.sizeDelta.y * 0.5f)) + 85);
        _rectTransform.anchoredPosition = WorldObject_ScreenPosition;
    }
}
