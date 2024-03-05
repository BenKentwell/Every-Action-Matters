using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public Sprite spriteUI;
    public bool Dragging { get; private set; }
	private Canvas canvas;

	[Tooltip("A Prefab for which tower to spawn onto the world when ending drag"),SerializeField]
	 private GameObject towerToSpawn;

	[Tooltip("The 'Slot' the object is ontop of before dragging")]
    private Transform originalParent;
	public GameObject towerButton;

	public AudioClip onDragSound;
	public AudioClip onPlaceSound;
	
	private AudioSource audioSource;

	private void Start()
	{
		GetComponent<Image>().sprite = spriteUI;
		audioSource = GameObject.FindWithTag("AudioManager").GetComponent<AudioSource>();
	}

    public void OnBeginDrag(PointerEventData _eventData)
	{
		audioSource.clip = onDragSound;
		audioSource.Play();
		
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
	private void Update()
	{
		Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	public void OnEndDrag(PointerEventData _eventData)
	{
		Dragging = false;
		transform.SetParent(originalParent);
		transform.localPosition = Vector3.zero;
		// List<RaycastResult> results = new();

		// EventSystem.current.RaycastAll(_eventData, results);

		// foreach(RaycastResult result in results)
		// {
		// 	if(!result.gameObject.CompareTag("Road"))
		// 	{
		// 		Instantiate(towerToSpawn, result., quaternion.identity);
		// 		Object.Destroy(this.gameObject);
		// 	}
		// 		return;
		// }

			
		RaycastHit hit = new();
		Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
		Instantiate(towerToSpawn,vec , quaternion.identity);

		audioSource.Stop();
		
		audioSource.clip = onPlaceSound;
		audioSource.Play();

		if(towerButton)
		{
			Destroy(towerButton);
		}
		
		Object.Destroy(this.gameObject);
		return;		
	}
}
