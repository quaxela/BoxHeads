using UnityEngine;
using System.Collections;

public class coinscript : MonoBehaviour {


	Transform blastclone;
	public Transform blast;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0,200*Time.deltaTime);
	}

	public void gather() {
		if (this.tag=="cupcake"){	GameObject.Find("GameController").SendMessage("cupcake_sound", SendMessageOptions.DontRequireReceiver);
			Vector3 blastpos=this.transform.position;
			blastclone = Instantiate(blast, blastpos , Quaternion.identity) as Transform;
		}
		if (this.tag=="coin"){	
			GameObject.Find("GameController").SendMessage("coin_sound", SendMessageOptions.DontRequireReceiver);
			Vector3 blastpos=this.transform.position;
			blastclone = Instantiate(blast, blastpos , Quaternion.identity) as Transform;
		
		}
		if (this.tag=="fast"){
			GameObject.Find("GameController").SendMessage("fast_sound", SendMessageOptions.DontRequireReceiver);
			Vector3 blastpos=this.transform.position;
			blastclone = Instantiate(blast, blastpos , Quaternion.identity) as Transform;

		}
		if (this.tag=="slow")	GameObject.Find("GameController").SendMessage("slow_sound", SendMessageOptions.DontRequireReceiver);
		if (this.tag=="vortex"){
			GameObject.Find("GameController").SendMessage("vortex_effect1", SendMessageOptions.DontRequireReceiver);
			Vector3 blastpos=this.transform.position;
			blastclone = Instantiate(blast, blastpos , Quaternion.identity) as Transform;
			
		}
		Destroy(this.gameObject, 0.1f);
	}
}
