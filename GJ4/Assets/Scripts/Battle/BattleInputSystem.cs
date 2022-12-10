using GJ4.Interfaces;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GJ4.Battle
{
    public class BattleInputSystem : MonoBehaviour, IInputSystem
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EventTrigger _eventTrigger;

        public event Action<PointerEventArgs> PointerDown;
        public event Action<PointerEventArgs> PointerDrag;
        public event Action<PointerEventArgs> PointerUp;

        private void Awake()
        {
            var pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
            pointerDown.callback.AddListener(data => { OnPointerDown((PointerEventData) data); });

            var pointerDrag = new EventTrigger.Entry { eventID = EventTriggerType.Drag };
            pointerDown.callback.AddListener(data => { OnPointerDrag((PointerEventData) data); });

            var pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
            pointerDown.callback.AddListener(data => { OnPointerUp((PointerEventData) data); });

            _eventTrigger.triggers.Add(pointerDown);
            _eventTrigger.triggers.Add(pointerDrag);
            _eventTrigger.triggers.Add(pointerUp);
        }

        private void OnPointerDown(PointerEventData eventData) => PointerDown?.Invoke(GetPointerEventArgs(eventData));

        private void OnPointerDrag(PointerEventData eventData) => PointerDrag?.Invoke(GetPointerEventArgs(eventData));

        private void OnPointerUp(PointerEventData eventData) => PointerUp?.Invoke(GetPointerEventArgs(eventData));

        private Vector3 WorldPosition(Vector2 position) => _camera.ScreenToWorldPoint(position);

        private PointerEventArgs GetPointerEventArgs(PointerEventData eventData) =>
            new PointerEventArgs(eventData.button, WorldPosition(eventData.position));
    }
}
