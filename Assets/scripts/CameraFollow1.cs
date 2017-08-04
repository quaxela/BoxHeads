using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFollow1 : MonoBehaviour {

	//Vector3 stageDimensions;
	int alive=1;
	float heroyer;
	int gamestate=0;
	Vector4 colorEnd = new Vector4(0.6f,0.9f,0.9f,1);
	Vector3 campos;


	Transform target;//the target object
	private float speedMod = 0.5f;//a speed modifier
	private Vector3 point;//the coord to the point where the camera looks at
	
	void Start() {//Set up things on the start method
		target=GameObject.Find("hero(Clone)").transform;
		point = target.position;//get target's coords
		transform.LookAt(point);//makes the camera look to it
		StartCoroutine(start2());

	}

	IEnumerator start2(){
		
		yield return new WaitForSeconds(2.0f);
		GameObject.Find("blackout").GetComponent<Animator>().SetTrigger("open");
		gamestate=-1;
		GameObject.Find("GameController").SendMessage("descending_sound",SendMessageOptions.DontRequireReceiver);
		StartCoroutine(start3());
	}

	IEnumerator start3(){
		
		yield return new WaitForSeconds(3f);
		GameObject.Find("GameController").SendMessage("exercise_sound",SendMessageOptions.DontRequireReceiver);
		
	}

	void character_secim1()
	{
		//campos=(new Vector3(-3.3f,1,5));
		gamestate=5;	
		StartCoroutine(character_cam1());		
	}
	void character_secim2()	
	{   

		campos=(new Vector3(target.position.x-8,target.position.y+10,target.position.z-9));
		GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuopen");
		gamestate=7;
		StartCoroutine(character_cam2());
	}

	IEnumerator character_cam1(){
		
		yield return new WaitForSeconds(1.0f);
		gamestate=6;
	}

	IEnumerator character_cam2(){
		
		yield return new WaitForSeconds(1.0f);
		gamestate=0;	


	}


	

	void baslat()
	{
		gamestate=1;	
		StartCoroutine(baslama1());
		
	}

	void resetgame()
	{
		gamestate=4;			
	}

	void resetgame2()
	{
		target=GameObject.Find("hero(Clone)").transform;
		point = target.position;//get target's coords
		transform.LookAt(point);//makes the camera look to it
		gamestate=0;	

		
	}

	IEnumerator baslama1(){
		
		yield return new WaitForSeconds(2.2f);
		//GameObject.Find("GameController").SendMessage("run_sound",SendMessageOptions.DontRequireReceiver);	
		gamestate=2;
		StartCoroutine(baslama2());
	
	}

	IEnumerator baslama2(){
		
		yield return new WaitForSeconds(0.5f);
		GameObject.Find("GameController").SendMessage("run_sound",SendMessageOptions.DontRequireReceiver);

	}

	void FixedUpdate () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
	
		if (gamestate==-1) {
			point = target.position;//get target's coords
			transform.LookAt(point);//makes the camera look to it
			this.transform.position = new Vector3 (this.transform.position.x,this.transform.position.y-0.74f,this.transform.position.z);
			this.transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),10 * Time.deltaTime * speedMod*2);

		}


		if (gamestate==0) {

			this.transform.RotateAround (point,new Vector3(0.0f,1.0f,0.0f),-10 * Time.deltaTime * speedMod*2);

		}

		if (gamestate==1) {

			point = target.position;//get target's coords
			transform.LookAt(point);//makes the camera look to it
			this.transform.position = Vector3.Lerp(this.transform.position, campos, Time.deltaTime* speedMod*5);
			transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(40, 45, 0), Time.deltaTime* speedMod*5);

		}
		
		if (gamestate==2) {
			this.transform.position = Vector3.Lerp(this.transform.position, campos, Time.deltaTime*3);
			transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(40, 45, 0), Time.deltaTime* speedMod*3);
		}

		if (gamestate==3) {

			Vector3 pos = target.transform.position-transform.position;
			//point = Quaternion.LookRotation(pos);
			transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(pos), Time.deltaTime* speedMod*20);

		}

		if (gamestate==5) {
			string isim =PlayerPrefs.GetString("heroisim"+PlayerPrefs.GetInt("mevcutcharacter").ToString());
			GameObject.Find("HeroNameText").GetComponent<Text>().text=isim.ToString();
			this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-3f,1,-5), Time.deltaTime*10);
			transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(8, 20, 0), Time.deltaTime* speedMod*10);
		}

		if (gamestate==6) {
		

		}
		
		if (gamestate==7) {


			//target=GameObject.Find("hero(Clone)").transform;
			point = target.position;//get target's coords
			transform.LookAt(point);//makes the camera look to it

			this.transform.position = Vector3.Lerp(this.transform.position, campos, Time.deltaTime*10);
			transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(40, 45, 0), Time.deltaTime* speedMod*10);
		}

		if (gamestate==4) {

		}
		else if (gamestate<4)
		{
			if (target.position.y<-2 && gamestate==2) {
				gamestate=3;
				GameObject.Find("GameController").SendMessage("fall_sound",SendMessageOptions.DontRequireReceiver);
			}

			if (this.transform.position.y<11 && gamestate==-1) {
				gamestate=0;
				GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuopen");
			}

			if (!target) return;

			if (alive==1) 
			{			
				campos=(new Vector3(target.position.x-8,target.position.y+10,target.position.z-9));
			}
		}
	/*
	
	void Start () {
		/*	gamemode = PlayerPrefs.GetInt ("gamemode");
		Vector2 topRightCorner = new Vector2(1, 1);
		Vector2 bottomLeftCorner = new Vector2(0, 0);
		Vector2 edgeVector1 = Camera.main.ViewportToWorldPoint(topRightCorner);
		Vector2 edgeVector2 = Camera.main.ViewportToWorldPoint(bottomLeftCorner);
		//stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(edgeVector1.x-edgeVector2.x, Screen.currentResolution.height,0));
		heroyer= (edgeVector1.x-edgeVector2.x)/3.5f;
*/    
		//StartCoroutine(renkdegistir());
	//}
	/*

	IEnumerator renkdegistir(){
	
		yield return new WaitForSeconds(2f);
		float r=1;
		float g=0;
		float b=1;
		do{
			r = UnityEngine.Random.Range(0.55f,0.8f);
			g = UnityEngine.Random.Range(0.55f,0.7f);
			b = UnityEngine.Random.Range(0.55f,0.9f);
		}while (Mathf.Abs(r-g)>.3f || Mathf.Abs(r-b)>.3f || Mathf.Abs(g-b)>.3f  );
		colorEnd = new Vector4(r,g,b,1);
		StartCoroutine(renkdegistir());

	}

	// Update is called once per frame
	void Update () {
	
		this.camera.backgroundColor = Color.Lerp(this.camera.backgroundColor, colorEnd, Time.deltaTime);
		RenderSettings.fogColor =Color.Lerp(RenderSettings.fogColor, colorEnd, Time.deltaTime);
		this.transform.position = Vector3.Lerp(this.transform.position, campos, Time.deltaTime*5);
	}


	void camstop(){
		alive=0;
	}
	void camstart(){
		alive=1;
	}	

*/
}
}