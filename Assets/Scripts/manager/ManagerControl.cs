using UnityEngine;
using System.Collections;

public class ManagerControl : MonoBehaviour {

	public float qtdCarros;
	public float timeMin;
	public float timeMax;

	public GameObject carro;

	private int gambiarra = 0;
		// Use this for initialization
	void Start () {
		
	}


	void changeTimeMin(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gambiarra == 120) {
			Instantiate(carro, new Vector3(0, 0, 0), Quaternion.identity);
			gambiarra = 0;
		}
		gambiarra++;
	}
}
