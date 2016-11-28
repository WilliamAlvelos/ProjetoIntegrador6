using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ManagerControl : MonoBehaviour {


	//variaveis para auxilio das contas
	private float qtdCarros;
	private float timeMin;
	private float timeMax;

	private bool first = true;

	//sliders
	public Slider qtdCarros_slider;
	public Slider semParar_slider;

	private static List<GameObject> carros_pedagio;


	//private GameObject[] carros_pedagio;
	private int index_carro_pedagio = 0;

	public GameObject carro;


	private static ManagerControl _instance;
	public static ManagerControl Instance{
		get{
			if (_instance == null) {
				_instance = FindObjectOfType (typeof(ManagerControl)) as ManagerControl;

				if (_instance == null) {
					var go = new GameObject ("_managerControl");
					DontDestroyOnLoad (go);
					_instance = go.AddComponent<ManagerControl> ();

				}
			}
			return _instance; 
		}
	}


	// Use this for initialization
	void Start () {
		qtdCarros = qtdCarros_slider.value;
		qtdCarros_slider.maxValue = 0.9f;
	}

	void mudaValores(){
		CancelInvoke ();
		qtdCarros = qtdCarros_slider.value;
		float valueCars = ((qtdCarros * 3f)+ 6f);
		Debug.Log (valueCars);

		InvokeRepeating("criarCarros", valueCars,valueCars);
	}



	void changeTimeMin(){


	}

	void Update () {
		if (qtdCarros != qtdCarros_slider.value) {
			mudaValores ();
		}

	}

	public void paraCarros(){
		foreach(GameObject go in carros_pedagio){
			Debug.Log (go.name);
		}
	}

	public void aceleraCarros(){
		foreach(GameObject go in carros_pedagio){
			go.GetComponent<CarManager> ().speed = 10;
		}
	}

	void criarCarros(){
		float rand = Random.Range (0, 101);
		if (rand <= semParar_slider.value * 100) {
			GameObject newCar = Instantiate (carro, new Vector3 (45, 0, 0), Quaternion.identity) as GameObject;
			newCar.AddComponent<CarSemParar> ();
			newCar.GetComponent<CarSemParar> ().speed = 64;

		} else {
			GameObject newCar = Instantiate (carro, new Vector3 (-45, 0, 0), Quaternion.identity) as GameObject;
			newCar.AddComponent<CarManager> ();
			if (first) {
				newCar.GetComponent<CarManager> ().speed = 64;
			} else {
				CarManager[] yourScriptArray = FindObjectsOfType(typeof(CarManager)) as CarManager[];
				foreach (CarManager yourScriptName in yourScriptArray ) {
					newCar.GetComponent<CarManager> ().speed = yourScriptName.speed;
				}
			}

			first = false;


				//carros_pedagio.Add (newCar);
			//index_carro_pedagio++;
		}
	}

}



