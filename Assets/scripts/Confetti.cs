using UnityEngine;
using System.Collections;

public class Confetti : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void confetti(){

		this.GetComponent<ParticleSystem>().Play();

	}
}
