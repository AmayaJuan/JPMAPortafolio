using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public bool moverHorizontal = true;

    public int mov;

    public float speed;

    float posInicialX;
    float posInicialY;

    void Start ()
    {
        posInicialX = transform.position.x;
        posInicialY = transform.position.y;
	}
	
	void Update ()
    {
        if(moverHorizontal)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, mov) + posInicialX, transform.position.y, 0);
        else
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, mov) + posInicialY, 0);
    }
}
