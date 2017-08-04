using UnityEngine;
using System.Collections;

public class backcube : MonoBehaviour {

	 Transform Hero;

	Vector4 colorEnd = new Vector4(0.6f,0.9f,0.9f,1);
	// Use this for initialization
	void Start () {
	
	
		Hero=GameObject.Find("hero(Clone)").transform;
	}


	public void DestroyObject() {
		Destroy(this.transform.gameObject);
	}


	IEnumerator renkdegistir(){
	
	yield return new WaitForSeconds(2f);
	float r=1;
	float g=0;
	float b=1;
	do{
		r = UnityEngine.Random.Range(0.2f,0.8f);
		g = UnityEngine.Random.Range(0.2f,0.7f);
		b = UnityEngine.Random.Range(0.2f,0.9f);
	}while (Mathf.Abs(r-g)>.3f || Mathf.Abs(r-b)>.3f || Mathf.Abs(g-b)>.3f  );
	colorEnd = new Vector4(r,g,b,1);
	StartCoroutine(renkdegistir());
	
}

	// Update is called once per frame
	void FixedUpdate () {
		//this.transform.renderer.material.color = Color.Lerp(this.transform.renderer.material.color, colorEnd, Time.deltaTime);



		//this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z+0.1f) ;

		if (this.transform.position.x < Hero.transform.position.x-20) {
			float x= Random.Range(30f,70f);
			float y= Random.Range(-10f,-20f);
			float z= Random.Range(-15f,50f);
			this.GetComponent<Animator>().SetTrigger("open");
			this.transform.position = new Vector3(Hero.transform.position.x+x,y, Hero.transform.position.z+z) ;
		}
	}
}
