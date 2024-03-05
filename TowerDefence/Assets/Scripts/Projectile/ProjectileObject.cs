using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ProjectileObject : MonoBehaviour
{
    public Projectile projectileScriptable;
    public Vector3 endPoint;
    public int damage;
    public SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        //damage = projectileScriptable + Bonus
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = projectileScriptable.texture;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * projectileScriptable.speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, endPoint) < 0.2f)
            Destroy(gameObject);
    }

    public void SetEndPoint(Vector3 _point)
    {
        
        endPoint = _point;
    }

}
