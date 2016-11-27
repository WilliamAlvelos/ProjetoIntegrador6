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
		yield return new WaitForSeconds(time);
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
				float timeToPAY = Random.Range (timerMin_slider.value, timerMax_slider.value);
				PegaDinheiro(timeToPAY);
				pago = true;
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

	void OnTriggerEnter(Collider other){
		Debug.Log ("bastao collider enter");
		abre = true;
	}

	void OnTriggerExit(Collider other){
		Debug.Log (" Collider exit");
		fecha = true;
	}

}
