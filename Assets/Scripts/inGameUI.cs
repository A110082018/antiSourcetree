using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameUI : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

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
    // player shoot
    public void Button_CharacterShot()
    {
        Debug.Log("Shoot!");
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();   
    }

    public void NextLevel()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemys.Length;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                return;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    
}
