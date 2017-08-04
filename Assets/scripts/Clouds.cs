using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {


	public Transform cloud1;
	public Transform cloud2;
	public Transform cloud3;
	public Transform cloud4;
	public Transform cloud5;
	public Transform cloud6;
	public Transform cloud7;
	public Transform cloud8;
	Transform Cloud;


	void CloudAdd(){







		Vector3 cloudpos=new Vector3(15,-14,12);
		Cloud = Instantiate(cloud1, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(270,48,0));


		cloudpos=new Vector3(23,-14,-5);
		Cloud = Instantiate(cloud2, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(270,134,0));


		cloudpos=new Vector3(-13,-14,13);
		Cloud = Instantiate(cloud3, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(270,226,0));


		cloudpos=new Vector3(-5,-14,-16);
		Cloud = Instantiate(cloud4, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(300,290,240));


		cloudpos=new Vector3(-13,23,10);
		Cloud = Instantiate(cloud5, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(300,290,155));


		cloudpos=new Vector3(13,77,0);
		Cloud = Instantiate(cloud6, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(300,290,155));


		cloudpos=new Vector3(-10,60,-10);
		Cloud = Instantiate(cloud7, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(300,290,332));


		cloudpos=new Vector3(14,38,-10);
		Cloud = Instantiate(cloud8, cloudpos , Quaternion.identity) as Transform;
		Cloud.parent = this.transform; 
		Cloud.transform.Rotate(new Vector3(300,290,33));




	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
