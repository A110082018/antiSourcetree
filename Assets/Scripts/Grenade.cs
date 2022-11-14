using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject GrenadeObj;
    public const float g =100f;

    private float time;
    public float speed = 50;

    private float verticalSpeed;
    public float radius = 5.0F;
    public float power = 100.0F; 

    public Collider[] colliders;
    public Vector3 explosionPos;
    bool isHit = false;
    
    void Start()
    {
        float tempTime = 1;
        float riseTime, downTime;
        riseTime = downTime = tempTime ;
        verticalSpeed = g * riseTime;
    }

    
    void Update()
    {
        time += Time.deltaTime;
        float test = verticalSpeed - g*time;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        transform.Translate(transform.up * test * Time.deltaTime, Space.World); 
        if(isHit)
        {
            Invoke("Explosion",0);  
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "floor")
        {   
           isHit = true;
        }
        
    }
    void Explosion()
    {
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius);  //施加爆破力道
            }
            gameObject.GetComponent<Renderer>().enabled =false;
            Destroy(this.gameObject,1);
        }    
    }  
}
