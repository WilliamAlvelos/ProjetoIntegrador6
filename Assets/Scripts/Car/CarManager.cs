using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour {
	public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 0, Time.deltaTime*speed));

		this.transform.GetChild (0).gameObject.transform.Rotate(new Vector3(Time.deltaTime*speed*-9,0,0));
		this.transform.GetChild (1).gameObject.transform.Rotate(new Vector3(Time.deltaTime*speed*-9,0,0));
		this.transform.GetChild (2).gameObject.transform.Rotate(new Vector3(Time.deltaTime*speed*-9,0,0));
		this.transform.GetChild (3).gameObject.transform.Rotate(new Vector3(Time.deltaTime*speed*-9,0,0));

	}


	void OnTriggerEnter(Collider other) {
		Debug.Log ("trigger enter");
	}
}
