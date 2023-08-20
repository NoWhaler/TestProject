using UnityEngine;
using UnityEngine.EventSystems;

namespace Main.Scripts.Movement
{
    public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _handle;

        private Vector2 _inputDirection = Vector2.zero;
        public Vector2 InputDirection => _inputDirection;

        private void Start()
        {
            _background = GetComponent<RectTransform>();
            _handle = transform.GetChild(0).GetComponent<RectTransform>();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _inputDirection = Vector2.zero;
            _handle.anchoredPosition = Vector2.zero;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_background,
                    eventData.position, eventData.pressEventCamera,
                    out var position)) return;
            
            var sizeDelta = _background.sizeDelta;
            
            position.x /= sizeDelta.x;
            position.y /= sizeDelta.y;

            if (position.magnitude < 0.1f)
            {
                position = Vector2.zero;
            }
            
            if (position.magnitude > 1.0f)
            {
                position = position.normalized;
            }

            var x = sizeDelta.x / 4f * position.x;
            var y = sizeDelta.y / 4f * position.y;
                
            _inputDirection = new Vector2(x, y);
                
            _handle.anchoredPosition = new Vector2(_inputDirection.x, _inputDirection.y);
        }
    }
}
