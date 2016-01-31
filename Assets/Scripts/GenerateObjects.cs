using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour {

	public GameObject[] Objects = new GameObject[10];
	// Use this for initialization
	void Start () {
		for (int x = 0; x < 20; x++) {
			GameObject item = Instantiate(Objects[x],new Vector3(Random.Range(0,60),0.5f,Random.Range(0,60)), Quaternion.identity) as GameObject;

			bool isOverlapped = false;
			Bounds bounds = item.GetComponent<Renderer>().bounds;
			Collider[] cols = Physics.OverlapSphere(item.transform.position, bounds.extents.magnitude);
			foreach(Collider col in cols) {
				if (col.gameObject == item) {
					continue; 
				}
				if (bounds.Intersects(col.gameObject.GetComponent<Renderer>().bounds)) {
					isOverlapped = true;
					break;
				}
			}
			if (isOverlapped) {
				//Destroy (item);
				item.transform.position = new Vector3(Random.Range(5,55),0.5f,Random.Range(5,55));
				Debug.Log ("test");
			}

	}
}

	// Update is called once per frame
	void Update () {

	}
}