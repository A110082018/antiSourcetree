using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //background move speed | Menu Button

    //background
    public float bg_speed1 = 0.3f;
    public float bg_speed2 = 0.2f;
    public GameObject bg_pic1;
    public GameObject bg_pic2;
    public GameObject bg_cloud1;
    public GameObject bg_cloud2;
    public GameObject bg_cloud3;
    public GameObject bg_cloud4;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move_bg();
    }

    private void move_bg()
    {
        //bg_pic
        if (bg_pic1.transform.position.x < -20 )
        {
            bg_pic1.transform.position = new Vector3(7,-1,0);
        }
        bg_pic1.transform.Translate(-bg_speed1 * Time.deltaTime, 0, 0);

        if (bg_pic2.transform.position.x < -20 )
        {
            bg_pic2.transform.position = new Vector3(7,-1,0);
        }
        bg_pic2.transform.Translate(-bg_speed1 * Time.deltaTime, 0, 0);

        //bg_cloud1&2
        if (bg_cloud1.transform.position.x < -11 )
        {
            bg_cloud1.transform.position = new Vector3(13,-2,-4);
        }
        bg_cloud1.transform.Translate(-bg_speed2 * Time.deltaTime, 0, 0);

        if (bg_cloud2.transform.position.x < -11 )
        {
            bg_cloud2.transform.position = new Vector3(13,-2,-4);
        }
        bg_cloud2.transform.Translate(-bg_speed2 * Time.deltaTime, 0, 0);

        //bg_cloud3&4
        if (bg_cloud3.transform.position.x < -7 )
        {
            bg_cloud3.transform.position = new Vector3(5,-1,-7);
        }
        bg_cloud3.transform.Translate(-bg_speed1 * Time.deltaTime, 0, 0);

        if (bg_cloud4.transform.position.x < -7 )
        {
            bg_cloud4.transform.position = new Vector3(5,-1,-7);
        }
        bg_cloud4.transform.Translate(-bg_speed1 * Time.deltaTime, 0, 0);
    }
}
