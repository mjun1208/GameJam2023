using UnityEngine;
using UnityEngine.EventSystems;

public class Scroller : MonoBehaviour, IDragHandler
{
    [SerializeField] private Camera _mainCamera;

    public void OnDrag(PointerEventData eventData)
    {
        _mainCamera.transform.position += new Vector3(0, -eventData.delta.y * Constant.DragSpeed, 0);
    }
}
