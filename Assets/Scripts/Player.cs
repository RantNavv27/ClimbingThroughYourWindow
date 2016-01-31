using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	float forward;
	float back;
	float right;
	float left;
	float count = 0;

	bool sacrifced;

	GameObject currentSacrifice;
	public GameObject altar;

	bool grabbed = false;

	void Start ()
	{
		//altar = GameObject.FindGameObjectsWithTag("Altar") as GameObject;
	}

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

	forward = Mathf.Clamp (forward,0, 12);
	back = Mathf.Clamp (back,-7, 0);
	left = Mathf.Clamp (left,-0.3f, 0f);
	right = Mathf.Clamp (right,0, 0.3f);

	transform.Rotate (0, left * forward, 0);
	transform.Rotate (0, right * forward, 0);
	transform.Rotate (0, left * back, 0);
	transform.Rotate (0, right * back, 0);

	transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.0F, 60.0F), 0, Mathf.Clamp(transform.position.z, 0.0F, 80.0F));

	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Altar" && grabbed == true && currentSacrifice != null) 
		{
			//sacrifced = true;
			grabbed = false;
			currentSacrifice.transform.GetComponent<Animator>().SetBool("grabbed", false);//= !enabled;
			currentSacrifice.transform.position = new Vector3 (altar.transform.position.x + 2, 2f, altar.transform.position.z);
			currentSacrifice.transform.rotation = Quaternion.Euler(-90,90,0);
			currentSacrifice.transform.parent = null;
			//currentSacrifice.transform.GetComponent<Animator>().enabled = !enabled;
			Invoke ("SacrificeDeath", 2);

			//Destroy (currentSacrifice);
			count++;
			GameObject.Find ("/Canvas/Score").GetComponent<UnityEngine.UI.Text> ().text = "Score:" + count;
		}
	}
	void SacrificeDeath ()
	{
		Destroy (currentSacrifice);
	}
}
