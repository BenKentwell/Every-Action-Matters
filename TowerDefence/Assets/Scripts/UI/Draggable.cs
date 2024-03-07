using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
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
    [SerializeField] private GameObject childImage;
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
        childImage.SetActive(true);
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
		audioSource.Stop();
        childImage.SetActive(false);
        Dragging = false;
		transform.SetParent(originalParent);
		transform.localPosition = Vector3.zero;
		
		RaycastHit hit = new();
		Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
		//Check if tower can be placed. not ontop of roads or other towers
		//if(cannotplace)
		Collider2D[] results = new Collider2D[7];
        ContactFilter2D filter2D = new ContactFilter2D();
        filter2D.NoFilter();
        int objects = Physics2D.OverlapCircle(vec, 0.5f,filter2D, results );
        if(objects > 0)
        {
			foreach(Collider2D coll in results)
			{
				if(coll.gameObject.CompareTag("Placed"))
				{
					return;
				}
			}
		}

		Instantiate(towerToSpawn,vec , quaternion.identity);

		
		
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
