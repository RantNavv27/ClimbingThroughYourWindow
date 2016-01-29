using UnityEngine;
using System.Collections;

public class GenerateObjects : MonoBehaviour {

	public GameObject[] Objects = new GameObject[10];
	// Use this for initialization
	void Start () {
		for (int x = 0; x < 10; x++) {
			Instantiate(Objects[x],new Vector3(Random.Range(1,30),0.5f,Random.Range(1,30)), Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}