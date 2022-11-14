using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject GrenadeObj;
    public const float g =4000f;

    private float time;
    public float speed = 3000;

    private float verticalSpeed;
    public float radius = 600F;
    public float power = 6000F; 

    public Collider[] colliders;
    public Vector3 explosionPos;
    
    private Animator animator;

    void Start()
    {
        float tempTime = 1;
        float riseTime, downTime;
        riseTime = downTime = tempTime ;
        verticalSpeed = g * riseTime;
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        time += Time.deltaTime;
        float test = verticalSpeed - g*time;
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        transform.Translate(transform.up * test * Time.deltaTime, Space.World); 
        Invoke("Explosion", 0F);
        
    }
    void Explosion()
    {
        Debug.Log("FIRE!!!");
        animator.SetTrigger("Fire");  
        /*animator.SetTrigger("Fire");
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
        } */   
    }  
}
