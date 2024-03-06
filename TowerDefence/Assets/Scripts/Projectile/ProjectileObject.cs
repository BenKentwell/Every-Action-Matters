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
        transform.localScale *= projectileScriptable.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = endPoint - transform.position ;
        dir.Normalize();
        transform.Translate(dir * projectileScriptable.speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, endPoint) < 0.5f)
            Destroy(gameObject);
    }

    public void SetEndPoint(Vector3 _point)
    {
        
        endPoint = _point;
    }

}
