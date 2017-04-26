using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    public bool pisadaConConcha;
    public bool pisadaSinConcha;

    public GameObject tortuga;

	void Start ()
    {
       // GetComponent<TortugaConConcha>();
       // GetComponent<TortugaSinConcha>();
    }
	
	void FixedUpdate ()
    {
       // pisadaConConcha = tortuga.gameObject.GetComponent<TortugaConConcha>().pisada;
        //pisadaSinConcha = tortuga.gameObject.GetComponent<TortugaSinConcha>().pisada;

        if (pisadaConConcha)
        {
            //GetComponent<TortugaConConcha>().enabled = false;
           // GetComponent<TortugaSinConcha>().enabled = true;
        }

        if (!pisadaConConcha)
        {
           // GetComponent<TortugaConConcha>().enabled = true;
           // GetComponent<TortugaSinConcha>().enabled = false;
        }
    }
}
