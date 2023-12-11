using System;
using _01.Scripts.UI.UIEvents;
using _01.Scripts.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using static _01.Scripts.UI.UIEvents.UIEventType;

namespace _01.Scripts.Managers
{
    public static class EventManager
    {
        public static event Func<GameObject, Transform, GameObject> OnInstantiatePrefab;
        public static GameObject OnInstantiate(GameObject prefab, Transform parent)
        {
           return OnInstantiatePrefab?.Invoke(prefab, parent);
        }

        public static void BindEvent(GameObject gameObject, Action<PointerEventData> action = null,  UIEvent type = UIEvent.Click)
        {
            UIEventsHandler eventsHandler= UtilityToGetAddComponent.GetOrAddComponent<UIEventsHandler>(gameObject);

            switch (type)
            {
                case UIEvent.Click:
                    eventsHandler.OnClickHandler -= action;
                    eventsHandler.OnClickHandler += action;
                    break;
                case UIEvent.Press:
                    eventsHandler.OnPressedHandler -= action;
                    eventsHandler.OnPressedHandler += action;
                    break;
                case UIEvent.PointerDown:
                    eventsHandler.OnPointerDownHandler -= action;
                    eventsHandler.OnPointerDownHandler += action;
                    break;
                case UIEvent.PointerUp:
                    eventsHandler.OnPointerUpHandler -= action;
                    eventsHandler.OnPointerUpHandler += action;
                    break;
                case UIEvent.Drag:
                    eventsHandler.OnDragHandler -= action;
                    eventsHandler.OnDragHandler += action;
                    break;
                case UIEvent.BeginDrag:
                    eventsHandler.OnBeginDragHandler -= action;
                    eventsHandler.OnBeginDragHandler += action;
                    break;
                case UIEvent.EndDrag:
                    eventsHandler.OnEndDragHandler -= action;
                    eventsHandler.OnEndDragHandler += action;
                    break;
                case UIEvent.PointerEnter:
                    eventsHandler.OnPointerEnterHandler -= action;
                    eventsHandler.OnPointerEnterHandler += action;
                    break;
                default:
                    Debug.Log($"Known Event Type : {type}");
                    break;
            }
        }
    }
}