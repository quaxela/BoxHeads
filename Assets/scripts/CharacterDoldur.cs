using UnityEngine;
using System.Collections;


public class CharacterDoldur : MonoBehaviour {


	public Transform herobox;
	// Use this for initialization
	void Start () {



			for (float heroboxposx = -1700; heroboxposx <= 100; heroboxposx+=180){
				
				//levelsayi++;
				//levelbox.GetComponent<LevelBoxController>().level=levelsayi;
				/*foreach (Transform trs in levelbox.transform) 
				{
					
					if (trs.gameObject.name == "levelboxback1" || trs.gameObject.name == "levelboxback2") 
					{
						foreach (Transform trs2 in trs.transform) 
						{
							if (trs2.gameObject.name == "sayitext1" || trs2.gameObject.name == "sayitext2") 
							{
								trs2.GetComponent<TextMesh>().text=levelsayi.ToString();
							}
						}
					}
				}*/
					
				(Instantiate(herobox, new Vector3(heroboxposx,0,0), Quaternion.identity)as Transform).parent  =GameObject.Find("HeroPanel").transform;		
				herobox.transform.rotation = Quaternion.Euler(0, 0, 0);
				
			}


	}
	
	// Update is called once per frame

}
