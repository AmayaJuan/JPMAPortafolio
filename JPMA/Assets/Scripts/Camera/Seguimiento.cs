using UnityEngine;

public class Seguimiento : MonoBehaviour
{
	public Transform objetivo;
	public float suavidad;
	private float velY = 0;
	private float velX = 0;
	public Vector2 limiteIzquierdo;
	public Vector2 limiteDerecho;

	public bool restringirX = false;
	public bool restringirY = false;

	float newPositionY;
	float newPositionX;

	void Update ()
    {
		newPositionY = Mathf.SmoothDamp (transform.position.y, objetivo.position.y, ref velY, suavidad);
		newPositionX = Mathf.SmoothDamp (transform.position.x, objetivo.position.x, ref velX, suavidad);

		if(newPositionX > limiteDerecho.x || newPositionX < limiteIzquierdo.x || restringirX)
			newPositionX = transform.position.x;

		if(newPositionY > limiteDerecho.y || newPositionY < limiteIzquierdo.y || restringirY)
			newPositionY = transform.position.y;

		transform.position = new Vector3 (newPositionX, newPositionY, transform.position.z);
	}
}
