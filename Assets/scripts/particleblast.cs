using UnityEngine;
using System.Collections;

public class particleblast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		StartCoroutine(destroyblast());
	}
	
	// Update is called once per frame
	IEnumerator destroyblast()
	{	
		yield return new WaitForSeconds(3);		
		Destroy(this.transform.gameObject);
	}

}
