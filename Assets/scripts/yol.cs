using UnityEngine;
using System.Collections;

public class yol : MonoBehaviour {
	public int uzunluk;
	public int aci;
	public float kalinlik;
	public int engelno;
	int renk=0;
	public Transform coin;
	public Transform cupcake;
	public Transform roket;
	public Transform salyangoz;
	public Transform vortex;
	Transform coin1;

	//Color colorStart = Color.red;
	Color colorEnd =  new Vector4(0.43f,0.45f,0.1f,1);
	//Color colorEnd =  new Vector4(0.15f,0.4f,0.29f,1f);
	Color renk2= new Vector4(0.15f,0.40f,0.29f,1f);
	public float duration = 1.0F;
	int degistir =0;
	int ayarlandi=0;
	void Start()
	{

	


	}

	public void DestroyObject() {
		Destroy(this.transform.gameObject);
	}


	public void yolrenkdegistir(Renk renk){

		degistir=1;
		renk2= renk.renk;
	}

	void Update() {


	//	if (degistir==1 && renk!=1 && ayarlandi==1) this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().GetComponent<Renderer>().materials[0].color = Color.Lerp(this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().GetComponent<Renderer>().materials[0].color, renk2, Time.deltaTime*3);

		if (renk==1)this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().GetComponent<Renderer>().materials[0].color = Color.Lerp(this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().GetComponent<Renderer>().materials[0].color, colorEnd, Time.deltaTime*3);
	}


	// Update is called once per frame
	public void ayarla (Engel engel) {

		uzunluk=engel.uzunluk;
		kalinlik=engel.kalinlik;
		engelno= engel.engelno;

		if (engel.yoltip==1) {aci=0; }
		if (engel.yoltip==2) {aci=270;}
		if (engel.yoltip==3) {aci=180;}
		if (engel.yoltip==4) {aci=90; }

		//this.transform.FindChild("mesafe").GetComponent<TextMesh>().text=engelno.ToString();

		this.transform.FindChild("cube").transform.localScale=new Vector3(uzunluk,1.0f,kalinlik);
	//	this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().materials[0].mainTextureScale = new Vector2(uzunluk/2,kalinlik/2);
	//	this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().materials[1].mainTextureScale = new Vector2(uzunluk/2,1);
//		this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().materials[2].mainTextureScale = new Vector2(kalinlik/2,1);

		this.transform.FindChild("cube").transform.localPosition=new Vector3((uzunluk/2)-1,-1.0f,0);
		this.transform.Rotate(new Vector3(0,aci,0));	
		this.transform.GetComponent<BoxCollider>().size = new Vector3(uzunluk,2,kalinlik);
		this.transform.GetComponent<BoxCollider>().center=  new Vector3((uzunluk/2)-1,1,0);

		int varmi=UnityEngine.Random.Range(1,3);
		int eklendi=0;

		int objeyer=UnityEngine.Random.Range(1,3);
		if (objeyer==1) objeyer=1; 
		if (objeyer==2) objeyer=-1;

		if (engelno%54==0&& eklendi==0) {
			Vector3 engelpos=new Vector3(uzunluk/2-1,0.5f,kalinlik/4*objeyer);			

			coin1 = Instantiate(vortex, engelpos , Quaternion.identity) as Transform;
			coin1.parent = this.transform;
			coin1.localPosition = engelpos;
			eklendi=1;
		}
		if (engelno%20==0&& eklendi==0) {
			Vector3 engelpos=new Vector3(uzunluk/2-1,0.5f,0);			

			coin1 = Instantiate(roket, engelpos , Quaternion.identity) as Transform;
			coin1.parent = this.transform;
			coin1.localPosition = engelpos;
			eklendi=1;
		}
		/*
		if (engelno%37==0 && eklendi==0) {
			Vector3 engelpos=new Vector3(uzunluk/2-1,0.5f,kalinlik/4*objeyer);			

			coin1 = Instantiate(salyangoz, engelpos , Quaternion.identity) as Transform;
			coin1.parent = this.transform;
			coin1.localPosition = engelpos;
			eklendi=1;
		}
		*/

		if (kalinlik>0.7f && varmi==2&& eklendi==0) {
			Vector3 engelpos=new Vector3(uzunluk/2-1,0.5f,kalinlik/4*objeyer);

			int ekletip=UnityEngine.Random.Range(1,3);
			if (ekletip==1)	coin1 = Instantiate(coin, engelpos , Quaternion.identity) as Transform;
			if (ekletip==2)	coin1 = Instantiate(cupcake, engelpos , Quaternion.identity) as Transform;
			if (ekletip==3)	coin1 = Instantiate(roket, engelpos , Quaternion.identity) as Transform;
			if (ekletip==4)	coin1 = Instantiate(salyangoz, engelpos , Quaternion.identity) as Transform;
			coin1.parent = this.transform;
			coin1.localPosition = engelpos;
			eklendi=1;
			//coin1.Rotate(90, 0, 0);
		}
		ayarlandi=1;
		//this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().materials[0].color = engel.renk;
	}

	void ustunde(){

		//this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().renderer.material.color =  new Vector4(0.5f,0.2f,0.18f,0);
		//colorEnd = new Vector4(0.30f,0.32f,0.18f,1);
		// colorEnd =  new Vector4(0.15f,0.37f,0.37f,1);
		//colorEnd = new Vector4(0.37f,0.37f,0.15f,1);
		/*
		if (aci==0) GameObject.Find("GameController").SendMessage("yol_sound1", SendMessageOptions.DontRequireReceiver);
		if (aci==90) GameObject.Find("GameController").SendMessage("yol_sound2", SendMessageOptions.DontRequireReceiver);
		if (aci==270) GameObject.Find("GameController").SendMessage("yol_sound3", SendMessageOptions.DontRequireReceiver);
		*/




		StartCoroutine(ustunde2());
	}

	IEnumerator ustunde2(){

		yield return new WaitForSeconds(0.25f);

		colorEnd = new Vector4(0.5f,0.2f,0.18f,0);
		renk=1;
		//colorEnd = new Vector4(0.43f,0.45f,0.1f,1);
	}

	public void yoket() {

		GameObject.Find("GameController").SendMessage("yol_sound1", SendMessageOptions.DontRequireReceiver);

		colorEnd = new Vector4(0.30f,0.05f,0.45f,0);
		StartCoroutine(yoket2());
	}

	IEnumerator yoket2(){

		yield return new WaitForSeconds(0.2f);


		this.transform.GetComponent<Rigidbody>().useGravity=true;
		this.transform.GetComponent<Rigidbody>().isKinematic=false;
		Destroy(this.gameObject, 2f);
		//Debug.Log("engelno:"+engelno);
		//this.transform.FindChild("cube").transform.GetComponent<MeshRenderer>().renderer.material.color = new Vector4(0.25f,0.1f,0.1f,1);
		//colorEnd = new Vector4(0.5f,0.2f,0.18f,0);
	}
}

