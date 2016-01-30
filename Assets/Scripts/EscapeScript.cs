using UnityEngine;
using System.Collections;

public class EscapeScript : MonoBehaviour {

	Transform player;
	Transform thisTransform;
	public float minDistance = 10;
	public float runSpeed = 10;

	//void Awake() {
	//	thisTransform = transform;
	//	thisTransform.position = new Vector3(2, 0, 2);
	//}

	void Start() {

		player = GameObject.FindGameObjectWithTag("Player").transform;
		thisTransform = this.transform;
	}

	void Update() {


		if(Vector3.Distance(player.position, thisTransform.position) < minDistance) {

			Vector3 dir = transform.position - player.position;
			transform.Translate(dir * runSpeed * Time.deltaTime);
		}
	}
}
