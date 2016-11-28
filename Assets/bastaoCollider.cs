using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class bastaoCollider : MonoBehaviour {

	public int speed;

	private bool abre = false;
	private bool aberto = false;
	private bool fecha = false;

	private bool pago = false;

	public Slider timerMax_slider;
	public Slider timerMin_slider;


	// Use this for initialization
	void Start () {
		timerMax_slider.value = 1;

		//this.transform.rotation = new Quaternion ();
	}
		


	IEnumerator PegaDinheiro(float time) {
		print(Time.time);
		Debug.Log (time);
		yield return new WaitForSeconds(time);
		print(Time.time);
		pago = true;
		aceleraCarros ();
		yield return new WaitForSeconds(3f);
		fecha = true;

		//tenta parar todos carros da manager co
	}
	// Update is called once per frame
	void Update () {
		//transform.Translate(new Vector3(0, 0, Time.deltaTime*speed));

		if (abre) {

			if (pago) {
				this.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed * 9));
				if (this.transform.rotation.z >= 0.95) {
					abre = false;
					aberto = true;
				}
			}
			else
			{
				Debug.Log ("bastao collider enter");

				
			}

		}
		if(fecha && !abre){
			this.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * speed * -9));
			Debug.Log (this.transform.rotation.z);

			if (this.transform.rotation.z <= 0.72) {
				aberto = false;
				fecha = false;
				pago = false;
			}
		}
	}


	void paraCarros(){
		CarManager[] yourScriptArray = FindObjectsOfType(typeof(CarManager)) as CarManager[];
		foreach (CarManager yourScriptName in yourScriptArray ) {
			yourScriptName.speed = 0;
		}
	}

	void aceleraCarros(){
		CarManager[] yourScriptArray = FindObjectsOfType(typeof(CarManager)) as CarManager[];
		foreach (CarManager yourScriptName in yourScriptArray ) {
			yourScriptName.speed = 64;
		}
	}

	void OnTriggerEnter(Collider other){
		paraCarros ();
		//supondo 5s o tempo para a pessoa pagar
		float timeToPAY = Random.Range (timerMin_slider.value, timerMax_slider.value * 5);
		StartCoroutine(PegaDinheiro(timeToPAY));
		abre = true;
	}

	void OnTriggerExit(Collider other){
		other.gameObject.AddComponent<CarSemParar> ();
		other.gameObject.GetComponent<CarSemParar> ().speed = 64;

		Debug.Log (" Collider exit");
	}

}
