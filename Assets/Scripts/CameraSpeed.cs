using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeed : MonoBehaviour
{
    public float cameraTime;
    public float spd=1.0f;

    public Transform camera1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateMAX start = FindObjectOfType<RotateMAX>();
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(cameraTime>0){
                GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            camera1.transform.Translate(spd*2*Time.deltaTime,spd*Time.deltaTime, spd*Time.deltaTime);
            cameraTime -= Time.deltaTime;
            }
            if(cameraTime<0)
            {
                camera1.transform.Translate(-spd * 2 * Time.deltaTime, -spd * Time.deltaTime, -spd * Time.deltaTime);
            }

            if (cameraTime < -3)
            {
                GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;
                spd = 0;
            }
        }
    }
}
