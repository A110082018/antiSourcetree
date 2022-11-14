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

    //pet follow
    public float speed = 500.0f; 
    private Rigidbody rb; 
    public GameObject petObject;            //要跟隨的物件
    public List<Vector3> positionList;
    public int distance = 50;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KeepShooting());
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPet();
        FireControll();
        move();
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

    void move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 push = new Vector3(h, 0, v) * speed;
        rb.AddForce(push * Time.deltaTime);

        positionList.Add(transform.position);       //紀錄玩家每偵位置
        if (positionList.Count > distance)          //集合的數字超過一定數字後意旨玩家與寵物的距離過遠時 就讓寵物照著玩家軌跡走，並清除先前紀錄的位置
        {
            positionList.RemoveAt(0);               
            petObject.transform.position = positionList[0];
        }
        
    }

}
