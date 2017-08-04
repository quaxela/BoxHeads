using UnityEngine;
using System.Collections;

public class ucak : MonoBehaviour {
	int yon=1;
	int yonvect = 1;
	int sfx_plane = 0;

	// Use this for initialization
	void Start () {
	//	GameObject.Find("hero(Clone)").transform.position.x
		float yuksek = Random.Range(-3,-12);
     	this.transform.position = new Vector3(GameObject.Find("hero(Clone)").transform.position.x+30,yuksek,GameObject.Find("hero(Clone)").transform.position.z-100);
		sfx_plane = 1;
	}
	
	// Update is called once per frame
	void Update () {


		this.GetComponent<Rigidbody>().velocity= Vector3.forward*25*yonvect;
		if (GameObject.Find("hero(Clone)") != null) {

			if(this.transform.position.z > GameObject.Find("hero(Clone)").transform.position.z+200 && yon==1) {
				float yuksek = Random.Range(-3,-12);
				this.transform.position = new Vector3(GameObject.Find("hero(Clone)").transform.position.x+(yuksek*-8),yuksek,GameObject.Find("hero(Clone)").transform.position.z+200+(yuksek*-5));
				this.transform.Rotate(new Vector3(0,0,180));
				yonvect=-1;
				yon=2;
				sfx_plane =0;
			}
			if(this.transform.position.z < GameObject.Find("hero(Clone)").transform.position.z-200 && yon==2) {
				float yuksek = Random.Range(-3,-12);
				this.transform.position = new Vector3(GameObject.Find("hero(Clone)").transform.position.x+(yuksek*-8),yuksek,GameObject.Find("hero(Clone)").transform.position.z-200-(yuksek*-5));
				this.transform.Rotate(new Vector3(0,0,180));
				yon=1;
				yonvect=1;
				sfx_plane =0;
			}

			if(GameObject.Find("hero(Clone)").transform.position.z+70 > this.transform.position.z  && GameObject.Find("hero(Clone)").transform.position.z-70 < this.transform.position.z && sfx_plane==0) 
			{
				float distance = Vector3.Distance (this.transform.position, GameObject.Find("hero(Clone)").transform.position);
				Debug.Log("uzaklık"+distance.ToString());
				GameObject.Find("GameController").SendMessage("plane_sound", distance,SendMessageOptions.DontRequireReceiver);
				sfx_plane=1;
			}
		}

	}
}
