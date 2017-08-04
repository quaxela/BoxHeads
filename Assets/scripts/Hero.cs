using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	Collider onceki;
	int oncekiyol;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyHero() {
		Destroy(this.transform.gameObject);
	}
	
	void OnTriggerEnter(Collider other) {

		if (other != onceki) {
		if (other.tag=="yol") {
			int engelno=other.GetComponent<yol>().engelno;
			
			if (engelno != oncekiyol) { 
				GameObject.Find("GameController").SendMessage("HeroKonum", engelno);
				other.SendMessage("ustunde", SendMessageOptions.DontRequireReceiver);	
				oncekiyol=engelno;
			}
		}


		if (other.tag=="coin") {
			daireanim();
			other.SendMessage("gather", SendMessageOptions.DontRequireReceiver);	
			onceki =other;
		}
		if (other.tag=="cupcake") {
			daireanim();
			other.SendMessage("gather", SendMessageOptions.DontRequireReceiver);	
			onceki =other;
		}
		if (other.tag=="fast") {
			daireanim();
			other.SendMessage("gather", SendMessageOptions.DontRequireReceiver);	
			onceki =other;
		}
		if (other.tag=="slow") {
			daireanim();
			other.SendMessage("gather", SendMessageOptions.DontRequireReceiver);	
			onceki =other;
		}
		if (other.tag=="vortex") {
			daireanim();
			other.SendMessage("gather", SendMessageOptions.DontRequireReceiver);
			onceki =other;
		}
		}
	}
	void daireanim(){
		this.transform.FindChild("daire").GetComponent<SpriteRenderer>().enabled=true;
		this.transform.FindChild("daire").GetComponent<Animator>().SetTrigger("Click");
	}

	void OnTriggerExit(Collider other) {
		if (other.tag=="yol") {		

			other.SendMessage("yoket", SendMessageOptions.DontRequireReceiver);	
		}
	}
}
