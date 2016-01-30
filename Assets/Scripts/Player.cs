using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	float forward;
	float back;
	float right;
	float left;

	void Update ()
	{
	Vector3 slowdown = transform.forward;
	slowdown *= back + forward;
	GetComponent<Rigidbody>().velocity = slowdown;

	forward -= 0.2f;
	back += 0.2f;
	left += 0.1f;
	right -= 0.1f;

	if (Input.GetKey (KeyCode.W)) forward += 0.5f;
	if (Input.GetKey (KeyCode.S)) back -= 0.5f;
	if (Input.GetKey (KeyCode.A)) left = -0.3f;
	if (Input.GetKey (KeyCode.D)) right = 0.3f;

	forward = Mathf.Clamp (forward,0, 10);
	back = Mathf.Clamp (back,-7, 0);
	left = Mathf.Clamp (left,-0.3f, 0f);
	right = Mathf.Clamp (right,0, 0.3f);

	transform.Rotate (0, left * forward, 0);
	transform.Rotate (0, right * forward, 0);
	transform.Rotate (0, left * back, 0);
	transform.Rotate (0, right * back, 0);

	}
}
