using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSecim : MonoBehaviour {
	public Texture[] textures;
	public int characterno;
	public int durum;
	// Use this for initialization
	void Start () {

		GameObject.Find("buyHeroText").GetComponent<Text>().enabled=false;
		GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=false;
		GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=false;

		durum = PlayerPrefs.GetInt("herodurum"+characterno.ToString());

		if (durum ==0) {
			this.transform.GetComponent<Image>().color =  new  Color(0.4f, 0.4f, 0.4f, 1f);
		}
		else
		{
		
		}
			
	}




	// Update is called once per frame
	void Update () {
	
	}


	public void buttonDown() {

	}
	
	public void buttonUp() {

		string isim =PlayerPrefs.GetString("heroisim"+characterno.ToString());
		GameObject.Find("HeroNameText").GetComponent<Text>().text=isim.ToString();
		GameObject.Find("GameController").SendMessage("button2_sound",SendMessageOptions.DontRequireReceiver);
		if (durum ==0) {

			this.transform.GetComponent<Image>().color =  new   Color(0.4f, 0.4f, 0.4f, 1f);
			GameObject.Find("buyHeroText").GetComponent<Text>().enabled=true;
			GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=true;
			GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=true;
			int fiyat = PlayerPrefs.GetInt("herofiyat"+characterno.ToString());

			GameObject.Find("buyHeroText").GetComponent<Text>().text=fiyat.ToString();
			PlayerPrefs.SetInt("sonsecim",characterno);
		}
		else
		{
			PlayerPrefs.SetInt("mevcutcharacter",characterno);
			GameObject.Find("buyHeroText").GetComponent<Text>().enabled=false;
			GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=false;
			GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=false;
		}


		//if (this.name =="herosecim1") {
		GameObject.Find("hero(Clone)").transform.FindChild("Box006").transform.GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().materials[0].mainTexture = GameObject.Find("herosecim0").GetComponent<CharacterSecim>().textures[characterno];
		//}
	}

}
