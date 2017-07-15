using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public bool moverHorizontal = true;

    int mov = 6;
    float speed = 2f;
    float posInicialX;
    float posInicialY;
    Walu walu;

    void Start ()
    {
        posInicialX = transform.position.x;
        posInicialY = transform.position.y;
        walu = FindObjectOfType<Walu>();
	}
	
	void Update ()
    {
        if (GameManager.inGame)
        {
            if (moverHorizontal)
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed, mov) + posInicialX, transform.position.y, 0);
            else
                transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, mov) + posInicialY, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Walu")
            walu.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Walu")
            walu.transform.parent = null;
    }
}
