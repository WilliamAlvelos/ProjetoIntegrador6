using UnityEngine;
using System.Collections;

public class catracaMove : MonoBehaviour {
	public int speed;

	private bool abre = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(new Vector3(0, 0, Time.deltaTime*speed));

		if (abre) {
			this.transform.GetChild (0).gameObject.transform.Rotate (new Vector3 (Time.deltaTime * speed * -9, 0, 0));
			if(this.transform.GetChild (0).gameObject.transform.rotation.x >= 0.70){
				abre = false;
			}

			Debug.Log (this.transform.GetChild (0).gameObject.transform.rotation.x);

		} else {

			this.transform.GetChild (0).gameObject.transform.Rotate (new Vector3 (Time.deltaTime * speed * 9, 0, 0));
			if (this.transform.GetChild (0).gameObject.transform.rotation.x <= 0.50) {
				abre = true;
			}
		}
	}
}
