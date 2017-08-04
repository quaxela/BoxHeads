using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void buttonDown() {
		if (this.tag=="butontext") {
			if (this.name=="playButtonText") 
			{
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,-12,-1);
			}
			if (this.name=="rateButtonText") 
			{
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,-12,-1);
			}
			if (this.name=="noadsButtonText") 
			{
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,-12,-1);
			}
			if (this.name=="buyHeroButton") 
			{
				
			}
		}
		if (this.tag=="butonicon")
		{
			if (this.name=="soundicon1") 
			{
				GameObject.Find("soundicon1").transform.localPosition = new Vector3(0,-12,-1);
				GameObject.Find("soundicon2").transform.localPosition = new Vector3(0,-12,-1);
			}
			if (this.name=="twittericon") 
			{
				this.transform.localPosition= new Vector3(0,-12,-1);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_twitter");
			}
			if (this.name=="leadericon") 
			{
				this.transform.localPosition= new Vector3(0,-12,-1);
			}
			if (this.name=="gamesicon") 
			{
				this.transform.localPosition= new Vector3(0,-12,-1);
			}
			if (this.name=="anamenuicon") 
			{
				this.transform.localPosition= new Vector3(0,-12,-1);
			}
			
			else
			{
				this.transform.localPosition= new Vector3(0,-12,-1);
				
			}
		}
	}
	
	public void buttonUp() {
		
		if (this.tag=="butontext")
		{
			if (this.name=="playButtonText") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,-1);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_play");
				
			}
			if (this.name=="rateButtonText") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,-1);
			}
			if (this.name=="noadsButtonText") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,-1);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_noads");
			}
			if (this.name=="buyHeroButton") 
			{
				GameObject.Find("GameController").SendMessage("button3_sound",SendMessageOptions.DontRequireReceiver);
				int characterno = PlayerPrefs.GetInt("sonsecim");
				int fiyat = PlayerPrefs.GetInt("herofiyat"+characterno.ToString());
				int coin = PlayerPrefs.GetInt("Coin");
				if (fiyat<=coin) {
					//GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_characterbuy");
					PlayerPrefs.SetInt("mevcutcharacter",characterno);
					GameObject.Find("buyHeroText").GetComponent<Text>().enabled=false;
					GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=false;
					GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=false;
					PlayerPrefs.SetInt("herodurum"+characterno.ToString(),1);
					coin =coin-fiyat;
					PlayerPrefs.SetInt("Coin",coin);
					GameObject.Find("CoinText1").GetComponent<TextMesh>().text=coin.ToString();
					GameObject.Find("CoinText2").GetComponent<TextMesh>().text=coin.ToString();
					//GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=false;
					//					this.transform.parent.GetComponent<Image>().color =  new  Color(1.0f, 1.0f, 1.0f, 1f);
				}
			}
		}
		if (this.tag=="butonicon")
		{
			
			if (this.name=="soundicon1") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				//GameObject.Find("GameController").SendMessage("SoundLevel",SendMessageOptions.DontRequireReceiver);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_sound");
				GameObject.Find("soundicon1").transform.localPosition = new Vector3(0,0,-1);
				GameObject.Find("soundicon2").transform.localPosition = new Vector3(0,0,-1);
			}
			if (this.name=="leadericon") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			if (this.name=="leadericon2") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_anamenu");
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			if (this.name=="replayicon") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_replay");
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			
			if (this.name=="settingsicon") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			if (this.name=="twittericon") 
			{
				GameObject.Find("GameController").SendMessage("button_sound",SendMessageOptions.DontRequireReceiver);
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			if (this.name=="anamenuicon") 
			{
				
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_herosecimtoanamenu");
				this.transform.localPosition= new Vector3(0,0,-1);
			}
			if (this.name=="gamesicon") 
			{
				
				GameObject.Find("GameController").SendMessage ("ClickEvent", "btn_characters");
				this.transform.localPosition= new Vector3(0,0,-1);
			}
		}
		
		
	}
}

