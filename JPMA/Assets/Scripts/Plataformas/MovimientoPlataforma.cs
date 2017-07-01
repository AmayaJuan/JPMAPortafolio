using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public bool moverHorizontal = true;

    int mov = 5;
    float speed = 2f;
    float posInicialX;
    float posInicialY;
    Player player;

    void Start ()
    {
        posInicialX = transform.position.x;
        posInicialY = transform.position.y;
        player = FindObjectOfType<Player>();
	}
	
	void Update ()
    {
        if(moverHorizontal)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, mov) + posInicialX, transform.position.y, 0);
        else
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, mov) + posInicialY, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Walu_Player")
            player.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Walu_Player")
            player.transform.parent = null;
    }
}
