using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public bool Dragging { get; private set; }
	private Canvas canvas;

	[Tooltip("The 'Slot' the object is ontop of before dragging")]
    private Transform originalParent;

    public void OnBeginDrag(PointerEventData _eventData)
		{
			if(originalParent == null){}

			originalParent = transform.parent;
			if(canvas == null)
			{
				canvas = gameObject.GetComponentInParent<Canvas>();
			}
			
			transform.SetParent(canvas.transform, true);
			transform.SetAsLastSibling();

			Dragging = true;
		}

		public void OnDrag(PointerEventData _eventData)
		{
			if(Dragging)
			{
				transform.position = _eventData.position;
			}
		}

		public void OnEndDrag(PointerEventData _eventData)
		{
			Dragging = false;
			transform.SetParent(originalParent);
			transform.localPosition = Vector3.zero;
			List<RaycastResult> results = new();

			EventSystem.current.RaycastAll(_eventData, results);


			//Foreach loop
            //Check for position of mouse and instantiate Tower at this locaiton
		}


}
