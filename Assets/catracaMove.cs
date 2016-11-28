using UnityEngine;
using System.Collections;

public class catracaMove : MonoBehaviour {
	public int speed;


	private bool abre = false;
	private bool aberto = false;
	private bool fecha = false;

	private bool pago = false;



	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		//transform.Translate(new Vector3(0, 0, Time.deltaTime*speed));

		if (abre) {
			this.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed * 9));
			//Debug.Log ( "a" + this.transform.rotation.z);

			if (this.transform.rotation.z <= -0.0042) {
				abre = false;
				aberto = true;
			}

		}
		if(fecha && !abre){
			this.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed * -9));
			//Debug.Log ( "b" + this.transform.rotation.z);

			if (this.transform.rotation.z >= -0.003119439) {
				aberto = false;
				fecha = false;
				pago = false;
				//ManagerControl.Instance.aceleraCarros (); 
			}
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("bastao collider enter");
		abre = true;
	}

	void OnTriggerExit(Collider other){
		Debug.Log (" Collider exit");
		fecha = true;
	}
}
