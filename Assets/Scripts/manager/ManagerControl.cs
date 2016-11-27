using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManagerControl : MonoBehaviour {


	//variaveis para auxilio das contas
	private float qtdCarros;
	private float timeMin;
	private float timeMax;


	//sliders
	public Slider qtdCarros_slider;
	public Slider semParar_slider;


	private GameObject[] carros_pedagio;
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
	}

	void mudaValores(){
		CancelInvoke ();
		qtdCarros = qtdCarros_slider.value;
		InvokeRepeating("criarCarros", (qtdCarros - 1)*-800f/60.0f, (qtdCarros - 1)*-800f/60.0f);
		Debug.Log (qtdCarros_slider.value);
	}



	void changeTimeMin(){


	}

	void Update () {
		if (qtdCarros != qtdCarros_slider.value) {
			mudaValores ();
		}

	}

	void paraCarros(){
		for (int i = 0; i < index_carro_pedagio; i++) {
			carros_pedagio [i].GetComponent<CarManager> ().speed = 0;
		}
	}

	void aceleraCarros(){
		for (int i = 0; i < index_carro_pedagio; i++) {
			carros_pedagio [i].GetComponent<CarManager> ().speed = 10;
		}
	}

	void criarCarros(){
		float rand = Random.Range (0, 101);

		if (rand <= semParar_slider.value * 100) {
			GameObject newCar = Instantiate (carro, new Vector3 (45, 0, 0), Quaternion.identity) as GameObject;
		} else {
			GameObject newCar = Instantiate (carro, new Vector3 (-45, 0, 0), Quaternion.identity) as GameObject;
			//carros_pedagio[index_carro_pedagio] = newCar;
			//index_carro_pedagio++;
		}
	}

}



