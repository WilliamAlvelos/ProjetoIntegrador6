using UnityEngine;
using System.Collections;

public class ManagerControl : MonoBehaviour {

	public float qtdCarros;
	public float timeMin;
	public float timeMax;

	public GameObject carro;

	private int gambiarra = 0;


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
		
	}




	void changeTimeMin(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gambiarra == 200) {
			//VERIFICAR SE O CARRO VAI PARA O SEM PARAR AI FICA EM X = 45 SE FOR PARA O NORMAL X = -45
			GameObject newCar = Instantiate (carro, new Vector3(45, 0, 0), Quaternion.identity) as GameObject;
			//newCar.GetComponent<Renderer> ().material.color = new Color (0.99F, 0.99F, 0.99F, 1F);
			gambiarra = 0;
		}
		gambiarra++;
	}
}
