using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Col_Cam1")
        {
            Debug.Log("Cambia Camara");
            //ToggleCamera();
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }

        if (other.gameObject.name == "Col_Cam2")
        {
            Debug.Log("Cambia Camara");
            //ToggleCamera();
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
        }

        if (other.gameObject.name == "Col_Cam3")
        {
            Debug.Log("Cambia Camara");
            //ToggleCamera();
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }
    }
}
