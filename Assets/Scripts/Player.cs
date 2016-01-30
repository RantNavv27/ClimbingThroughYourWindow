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


	if (Input.GetKey (KeyCode.W)) {

		forward += 0.5f;
		GetComponent<Rigidbody>().AddForce (transform.forward * forward);

	}
	if (Input.GetKey (KeyCode.S)) {

		back -= 0.5f;
		GetComponent<Rigidbody>().AddForce (transform.forward * back);

	}
	if (Input.GetKey (KeyCode.A)) {

		left = -0.3f;
		Invoke("TurnSlowDown", 1f);
		//forward -= 0.32f;
	} else if (Input.GetKey (KeyCode.D)) {

		right = 0.3f;
		Invoke("TurnSlowDown", 1f);
		//forward -= 0.32f;
	}

	if (forward >= 10.0f) {
		forward = 10.0f;
	}
	if (forward <= 0.0f) {
		forward = 0.0f;
	}
	if (back <= -7.0f) {
		back = -7.0f;
	}
	if (back >= 0.0f) back = 0.0f;
	if (right >= 0.3f) {
		right = 0.3f;
	}
	if (right <= 0.0f) {
		right = 0.0f;
	}
	if (left <= -0.3f) {
		left = -0.3f;
	}
	if (left >= 0.0f) {
		left = 0.0f;
	}

	transform.Rotate (0, left * forward, 0);
	transform.Rotate (0, right * forward, 0);
	transform.Rotate (0, left * back, 0);
	transform.Rotate (0, right * back, 0);

}
}
