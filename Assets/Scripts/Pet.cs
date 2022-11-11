using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    //Check Pet
    public float isHavePet;

    //fire
    public Transform firePoint;
    public GameObject bulletPrefab;
    public static float isKeepShooting = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KeepShooting());
    }

    // Update is called once per frame
    void Update()
    {
        CheckPet();
        FireControll();
    }

    //check Pet admission
    void CheckPet()
    {
        if (isHavePet == 1)
        {
            return;
        }
        else if (isHavePet == 0)
        {
            Destroy(gameObject);
        }
    }

    public void FireControll()
    {
        //switch button
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(isKeepShooting == 0)
            {
                Debug.Log("f>t");
                isKeepShooting = 1;
            }
            else if(isKeepShooting == 1)
            {
                Debug.Log("t>f");
                isKeepShooting = 0;
            }
        }
    }

    IEnumerator KeepShooting()
    {
        while(true)
        {
        if (isKeepShooting == 1)
        {
            Fire();
            Debug.Log("Fire");
        }
        yield return new WaitForSeconds(0.5f);
        Debug.Log("0.5f");
        }
    }
    
    public void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }
}
