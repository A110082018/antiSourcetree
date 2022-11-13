using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameUI : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button_Menu()
    {

    }
    public void Button_Pet()
    {
        if(Pet.isKeepShooting == 0)
            {
                Debug.Log("f>t");
                Pet.isKeepShooting = 1;
            }
            else if(Pet.isKeepShooting == 1)
            {
                Debug.Log("t>f");
                Pet.isKeepShooting = 0;
            }
    }
    public void Button_CharacterShot()
    {
        Debug.Log("Shoot!");
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
        
    }
}
