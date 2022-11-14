using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameUI : MonoBehaviour
{
    // pet shoot
    public Transform firePoint;
    public GameObject bulletPrefab;
    

    // pause
    public Button PauseButton;
    public GameObject PauseWindow;
    private bool isPause;
    public Text PauseTitle;

    // pause
    public void Button_Menu()
    {
        PauseGame();
        
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

    public void BacktoGame()
    {
        PauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPause = !isPause;
    }

    public void BacktoTitle()
    {
        isPause = !isPause;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        PauseButton.onClick.AddListener(PauseGame);
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();   
    }

    // if no more enemy then next level
    public void NextLevel()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int enemyCount = enemys.Length;
        Debug.Log(enemyCount);
        if (enemyCount == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    void PauseGame()
    {
        isPause = !isPause;
        Debug.Log("1");
        

        
        if (isPause == true)
        {
            PauseWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
            InvokeRepeating("showHide", 0.5f, 0.5f);
            Debug.Log("2");
        }
    }
    void showHide()
    {
        
        if(PauseTitle.text == "Want to ESCAPE ?")
        {
            PauseTitle.text = " ";
        }
        else
        {
            PauseTitle.text = "Want to ESCAPE ?";
        }
    }
    
}
