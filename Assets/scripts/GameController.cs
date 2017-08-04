using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using UnityEngine.SocialPlatforms;
//using UnityEngine.SocialPlatforms.GameCenter;
using System.Net;
using UnityEngine.Advertisements;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {


	public Transform MainCamera;
	private string leadertablo = "com.quaxel.cubeheads.leaderboard";

	int reklamgosterim=0;
	public GoogleAnalyticsV3 googleAnalytics;
	public AudioClip yolsound1;
	public AudioClip cupcakesound;
	public AudioClip coinsound;
	public AudioClip confettisound;
	public AudioClip turnsound;
	public AudioClip potionsound;
	public AudioClip rocketsound;
	public AudioClip descendingsound;
	public AudioClip runsound;
	public AudioClip exercisesound;
	public AudioClip buttonsound;
	public AudioClip button2sound;
	public AudioClip button3sound;
	public AudioClip fallsound;
	public AudioClip transitionsound1;
	//	public AudioClip transitionsound2;
	public AudioClip planesound;
	
	int listsize;
	public List<Engel> engellist=new List<Engel>();
	int sira;
//	float eskirndy1=15;
	public Transform yol;
	public int herokonum;
	int engelno;
	int rndtip=0;
	Transform engelclone;
	Transform tozbulut2;
	public Transform tozbulut1;
	Transform Hero;
	public Transform Heroprefab;
	public Transform YolContainer;
	Animator anim;
	public float speed = 5f;
	public float speed2 = 5f;

	public float rotateSpeed = 0F;
	Vector3 bas;

	private float degree=90F;
	private float angle;

	float eskikalinlik;
	int eskiuzunluk=0;
	int eskitip =-1;
	Vector3 eskiyolposition = new Vector3(0,0.25f,0);
	int soundlevel=0;

	int vortex_aktif=0;
	float vortexspeed=0;
	float vortexspeed2=0;
	float vortexaccel=1f;
	AudioSource audiosource;

	int highscore=0;
	int score=0;
	int coin=0;
	int internetvar=0;
	int menubas=0;
	int engeleklendi=0;
	Vector4 currentrenk= new Vector4(0.29f,0.40f,0.15f,1f);
	Vector4 renk0= new Vector4(0.29f,0.40f,0.15f,1f);
	Vector4 renk1= new Vector4(0.15f,0.40f,0.29f,1f);
	Vector4 renk2= new Vector4(0.03f,0.38f,0.94f,1f);
	Vector4 renk3= new Vector4(0.40f,0.15f,0.14f,1f);
	Vector4 renk4= new Vector4(0.69f,0.10f,0.85f,1f);
	Vector4 renk5= new Vector4(0.99f,0.40f,0.15f,1f);
	CharacterController controller;
	int herostate=0;
	public int reklamyok=0;


	/* bulut koordinatları
	15,-14,12
		23,-14,-5
			-13,-14,13
			-5,-14,-16
			-12,26,0
			13,77,0
			-10,60,-10
			14,38,-10
			*/
	const string TwitterAddress = "http://twitter.com/intent/tweet";
	/*
	private const string FACEBOOK_APP_ID = "123456789000";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";


	// Your app’s unique identifier.
	string AppID = "1467817350109679";
	
	// The link attached to this post.
	string Link = "https://play.google.com/store/apps/details?id=com.quaxel.arrows2";
	
	// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
	string Picture = "https://lh3.ggpht.com/cnx-1ZJ1tIj4Im1a_1IxZeRtl3aE4V_nhSl81q5riHD3FVSgxQkcPoOH3aU7ACt3z0A=w300-rw";
	
	// The name of the link attachment.
	string Name = "My New Score";
	
	// The caption of the link (appears beneath the link name).
	string Caption = "Swipe The Arrow for Android";
	
	// The description of the link (appears beneath the link caption). 
	string Description = "Swipe the black arrows in the same direction, the zebra arrows in the opposite direction.Sounds easy, right?";
	*/

	/*
	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		                     "&link=" + WWW.EscapeURL(linkParameter) +
		                     "&name=" + WWW.EscapeURL(nameParameter) +
		                     "&caption=" + WWW.EscapeURL(captionParameter) + 
		                     "&description=" + WWW.EscapeURL(descriptionParameter) + 
		                     "&picture=" + WWW.EscapeURL(pictureParameter) + 
		                     "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}
	*/

	public static void ShareToTwitter (string text, string url,string related, string lang="en")
	{
		Application.OpenURL(TwitterAddress +
		                    "?text=" + WWW.EscapeURL(text) +
		                    "&amp;url=" + WWW.EscapeURL(url) +
		                    "&amp;related=" + WWW.EscapeURL(related) +
		                    "&amp;lang=" + WWW.EscapeURL(lang));
	}


	/*
	void ShareScoreOnFB(){

		string adi= "My New Score 11";		
		Application.OpenURL("https://www.facebook.com/dialog/feed?"+
		                    "app_id="+AppID+
		                    "&link="+Link+
		                    "&picture="+Picture+
		                    "&name="+adi.Replace(" ","%20")+
		               		"&caption="+Caption.Replace(" ","%20")+
		               		"&description="+Description.Replace(" ","%20")+
		                    "&redirect_uri=https://facebook.com/");
		
	}
*/

	public void ReklamKaldir() 
	{
		GameObject.Find("noadsButtonText").GetComponent<Text>().enabled=false;
		GameObject.Find("noadsButton").GetComponent<Image>().enabled=false;

	}


	void Awake() {
	
		if (CheckForInternetConnection()==true) internetvar=1; else internetvar=0;
		
		soundlevel=PlayerPrefs.GetInt("soundlevel");
		//PlayerPrefs.Save();
		Application.targetFrameRate = 60;	

		Vector3 heropos=new Vector3(0,0.1f,0);
		Hero = Instantiate(Heroprefab, heropos , Quaternion.identity) as Transform;
		Hero.transform.Rotate(new Vector3(0,241,0));	
		coin = PlayerPrefs.GetInt("Coin");
		GameObject.Find("CoinText1").GetComponent<TextMesh>().text=coin.ToString();
		GameObject.Find("CoinText2").GetComponent<TextMesh>().text=coin.ToString();

		PlayerPrefs.SetString("heroisim0","Triathlon John");
		PlayerPrefs.SetString("heroisim1","Mr. Rowember");
		PlayerPrefs.SetString("heroisim2","Justin");
		PlayerPrefs.SetString("heroisim3","Personal Computer");
		PlayerPrefs.SetString("heroisim4","Green Fermit");
		PlayerPrefs.SetString("heroisim5","Springer");
		PlayerPrefs.SetString("heroisim6","Farmer");
		PlayerPrefs.SetString("heroisim7","Earth Soul");
		PlayerPrefs.SetString("heroisim8","Herbal Soul");
		PlayerPrefs.SetString("heroisim9","Basketball Player");
		PlayerPrefs.SetString("heroisim10","Priate ");
		PlayerPrefs.SetString("heroisim11","Sapphire");
		PlayerPrefs.SetString("heroisim12","Emerald");
		PlayerPrefs.SetString("heroisim13","Lava");
		PlayerPrefs.SetString("heroisim14","Viking");
		PlayerPrefs.SetString("heroisim15","Ninja");
		PlayerPrefs.SetString("heroisim16","Dr Acula");
		PlayerPrefs.SetString("heroisim17","Fragile Box");
		PlayerPrefs.SetString("heroisim18","Steelman");
		PlayerPrefs.SetString("heroisim19","Geeky Gervais");
		PlayerPrefs.SetString("heroisim20","Skele Tom");

		PlayerPrefs.SetInt("herofiyat0",0);
		PlayerPrefs.SetInt("herofiyat1",50);
		PlayerPrefs.SetInt("herofiyat2",50);
		PlayerPrefs.SetInt("herofiyat3",50);
		PlayerPrefs.SetInt("herofiyat4",100);
		PlayerPrefs.SetInt("herofiyat5",100);
		PlayerPrefs.SetInt("herofiyat6",100);
		PlayerPrefs.SetInt("herofiyat7",100);
		PlayerPrefs.SetInt("herofiyat8",100);
		PlayerPrefs.SetInt("herofiyat9",100);
		PlayerPrefs.SetInt("herofiyat10",250);
		PlayerPrefs.SetInt("herofiyat11",250);
		PlayerPrefs.SetInt("herofiyat12",250);
		PlayerPrefs.SetInt("herofiyat13",250);
		PlayerPrefs.SetInt("herofiyat14",250);
		PlayerPrefs.SetInt("herofiyat15",500);
		PlayerPrefs.SetInt("herofiyat16",500);
		PlayerPrefs.SetInt("herofiyat17",500);
		PlayerPrefs.SetInt("herofiyat18",500);
		PlayerPrefs.SetInt("herofiyat19",500);
		PlayerPrefs.SetInt("herofiyat20",1000);

		PlayerPrefs.SetInt("herodurum0",1);

		if (PlayerPrefs.GetInt ("noadsowned") == 1) reklamyok=1;
		if (reklamyok==1) ReklamKaldir();
	}



	void GameCenterLogin(){

		Social.localUser.Authenticate (ProcessAuthentication);
	}

	void ProcessAuthentication (bool success){
		if (success) {
			highscore = PlayerPrefs.GetInt ("highscore");
			Social.ReportScore(highscore, leadertablo, (bool success1) =>
		    {
				
			});
		}
	}

	void renkdegistir(){
		  if (currentrenk==renk4)currentrenk= renk0;
		else if (currentrenk==renk3)currentrenk= renk4;
		else if (currentrenk==renk2)currentrenk= renk3;
		else if (currentrenk==renk1)currentrenk= renk2;
		else if (currentrenk==renk0)currentrenk= renk1;



		Renk renk=new Renk();
		renk.renk=currentrenk;
		Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			if (go.tag=="yol")	go.SendMessage ("yolrenkdegistir",renk);

		}	
	}
	
	void LeaderboardOpen() 
	{
		//if (Application.internetReachability==NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability==NetworkReachability.ReachableViaCarrierDataNetwork ) {
			if (Social.localUser.authenticated)
			{
				//#if UNITY_IPHONE
				//TimeScope ts = new TimeScope();	
				//GameCenterPlatform.ShowLeaderboardUI(leadertablo,ts);
			    Social.ShowLeaderboardUI();
				//#endif
			}
			else
			{			
				GameCenterLogin();	
			}
		//}
	}
	
	
	
	void adinit(){
		if (reklamyok==0)
		{
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize ("25524");
		} else {
			Debug.Log("Platform not supported");
		}
		}
	}


	void Start () {
		#if UNITY_IPHONE

				
			GameCenterLogin();	
	
		if (reklamyok==0) adinit();
		#endif
		SoundLevel();
		anim = Hero.GetComponent<Animator>();
		//engelekle();
		controller = Hero.GetComponent<CharacterController>();
		audiosource =GetComponent<AudioSource>();
		DilAyarla();
		googleAnalytics.LogScreen("Open");
		GameObject.Find("Clouds").SendMessage("CloudAdd",SendMessageOptions.DontRequireReceiver);
		int mevcutcharacter = PlayerPrefs.GetInt("mevcutcharacter");
		GameObject.Find("hero(Clone)").transform.FindChild("Box006").transform.GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().materials[0].mainTexture = GameObject.Find("herosecim0").GetComponent<CharacterSecim>().textures[mevcutcharacter];


		/*ShareScoreOnFB();*/
		//ShareToTwitter("asdsa","http://itunes.apple.com/app/dire-wolf/id951209344","");
	}

	void DilAyarla() {
		string play_langt="Play";
		if (Application.systemLanguage.ToString()=="English")  play_langt ="Play";
		if (Application.systemLanguage.ToString()=="Turkish")  play_langt ="Oyna";
		if (Application.systemLanguage.ToString()=="German")   play_langt ="Spielen";
		if (Application.systemLanguage.ToString()=="French")   play_langt ="Jouer";
		if (Application.systemLanguage.ToString()=="Spanish")  play_langt ="Jugar";
		if (Application.systemLanguage.ToString()=="Italian")  play_langt ="Gioca";
		GameObject.Find("playButtonText").GetComponent<Text>().text  =play_langt;
		highscore = PlayerPrefs.GetInt ("highscore");
		GameObject.Find("highscoreText").GetComponent<TextMesh>().text=highscore.ToString();


	}

	public void RateThisGame()
	{	
		googleAnalytics.LogScreen("RateButtonClick");
		PlayerPrefs.SetInt ("rated",1);
		Application.OpenURL("itms-apps://itunes.apple.com/app/id951209344");	
		
	}


	IEnumerator speedstart(){	
		yield return new WaitForSeconds(4f);
		speed2=8f;


	}

	void FixedUpdate()
	{
		if (engeleklendi==1) gamemodeupdate();
	}

	// Update is called once per frame
	void Update () {


      if (herostate!=2 )		
		{

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Exercise1") ) {
			Hero.position = new Vector3(0,0.1f,0);
		}
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Exercise2") ) {
			Hero.position = new Vector3(0,0.1f,0);			
		}


		if (anim.GetCurrentAnimatorStateInfo(0).IsName("StartRun") ) {
		
		//	Hero.localEulerAngles = new Vector3(0,90,0);
		//	Debug.Log (anim.GetCurrentAnimationClipState(0).GetValue(0).ToString() );
		}


		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
		
		
			//CharacterController controller = Hero.GetComponent<CharacterController>();
			Vector3 forward = Hero.TransformDirection(Vector3.forward);
				if (herostate==1 )controller.SimpleMove(forward * speed);




			
			if (Input.GetKeyDown("left"))
			{
				turn_sound();
				degree -= 90f;
			}
			if (Input.GetKeyDown("right"))
			{
				turn_sound();
				degree += 90f;
			}

		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{

				turn_sound();
			bas = Input.mousePosition;
			if (bas.x< Screen.width/2)
			{
				//Hero.Rotate(0, -90, 0);	
					degree -= 90f;
			}
			else
			{
				//Hero.Rotate(0, 90, 0);				
					degree += 90f;
			}

		}
		#endif

		#if UNITY_IPHONE || UNITY_ANDROID
		foreach (Touch touch in Input.touches)
		{

			if (touch.phase == TouchPhase.Began )
			{	

				turn_sound();
				bas = touch.position;
				if (bas.x< Screen.width/2)
				{
						degree -= 90f;				
				}
				else
				{
						degree += 90f;				
				}
				
				
			}
		}			
		#endif
		

			Hero.rotation = Quaternion.Slerp(Hero.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime*((speed*speed/2)));


		}


		if (speed>=8.5f && Hero.FindChild("heroTrailer").GetComponent<TrailRenderer>().enabled==false) Hero.FindChild("heroTrailer").GetComponent<TrailRenderer>().enabled=true;
		else if(speed<8.5f && Hero.FindChild("heroTrailer").GetComponent<TrailRenderer>().enabled==true) Hero.FindChild("heroTrailer").GetComponent<TrailRenderer>().enabled=false;

		speed = Mathf.Lerp(speed, speed2, Time.deltaTime*2);
		vortexspeed = Mathf.Lerp(vortexspeed, vortexspeed2, Time.deltaTime/vortexaccel);
		MainCamera.GetComponent<VortexEffect>().angle=vortexspeed;


		}
	}


	void baslat()
	{

		StartCoroutine(particlestart());
		//Hero.Rotate(0, 225, 0);
		Hero.GetComponent<Animator>().SetTrigger("Start");

		//Hero.Rotate(0, 225, 0);
		herostate=1;
		GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuclose");
		engelekle();
		engeleklendi=1;
		


	}





	void HeroKonum(int no) 
	{
		herokonum=no;
		score++;
		GameObject.Find("ScoreText1").GetComponent<TextMesh>().text=score.ToString();
		GameObject.Find("ScoreText2").GetComponent<TextMesh>().text=score.ToString();
	}


	void gamemodeupdate() 
	{

		if (sira<listsize ) {
			
			if (engellist[sira].engelno-10< herokonum && engellist[sira].durum ==0) 
			{
				
				if (1==1)
				{
					if (engellist[sira].engelno%5==0) renkdegistir();
					engellist[sira].renk =currentrenk;
					Vector3 engelpos=engellist[sira].position;
					engelclone = Instantiate(yol, engelpos , Quaternion.identity) as Transform;
					engelclone.SendMessage("ayarla", engellist[sira]);	
					engelclone.parent=YolContainer.transform;

					engellist[sira].goster();

				}
				sira ++;
			}
		}
		else 
		{
			engelekle();
		}
	
	}

	
	void engelekle() 
	{	



		int sinir=engelno+3;
		engellist.Clear();		
		sira = 0;
		int no=0;


		while (engelno < sinir)
		{		

			//if (score<100)
			float miktar = ((float)engelno/50f);
			if (miktar>2) miktar=2;
			float kalinlik=UnityEngine.Random.Range(1.75f-(miktar/2),3.5f-miktar);

		
			do
			{
			  rndtip=UnityEngine.Random.Range(1,5);
			}
			while (Mathf.Abs(eskitip-rndtip)==2 || rndtip==eskitip || rndtip==3);

			//Debug.Log (rndtip.ToString());
			//rndtip=0;

			int uzunluk=(UnityEngine.Random.Range(2,4))*2;
			Engel item=new Engel();

			engelno++;
			no++;
			item.renk = currentrenk;
			item.engelno =  engelno;
			item.no = no;
			item.durum = 0;
			item.kalinlik=kalinlik;
			item.uzunluk=uzunluk;
			if (rndtip==1) item.yoltip = 1;	
			else if (rndtip==2) item.yoltip = 2; 
			else if (rndtip==3) item.yoltip = 3; 
			else if (rndtip==4) item.yoltip = 4; 
				
			//Debug.Log (rndtip.ToString());
			float xpos=0;
			float zpos=0;
			float kayma=0;
			if (eskitip==-1) {
				rndtip=1;
				item.yoltip = 1;	
				zpos=eskiyolposition.z;
				xpos=eskiyolposition.x+6;
			}
			if (eskitip==1) {
				if (rndtip==1) kayma=((eskikalinlik-kalinlik)/4);
				if (rndtip==2) kayma=((2-eskikalinlik)/2);
				if (rndtip==4) kayma=((2-eskikalinlik)/2);
				zpos=eskiyolposition.z+kayma;		
				xpos=eskiyolposition.x+((eskiuzunluk-1)+(kalinlik/2));						
			}
			if (eskitip==2) {
				if (rndtip==2) kayma=((eskikalinlik-kalinlik)/4);
				if (rndtip==1) kayma=((2-eskikalinlik)/2);
				if (rndtip==3) kayma=((2-eskikalinlik)/2);
				zpos=eskiyolposition.z+((eskiuzunluk-1)+(kalinlik/2));
				xpos=eskiyolposition.x+kayma;							
			}
			if (eskitip==3) {
				zpos=eskiyolposition.z+kayma;	
				xpos=eskiyolposition.x-((eskiuzunluk-1)+(kalinlik/2));
			}
			if (eskitip==4) {
				if (rndtip==4) kayma=((eskikalinlik-kalinlik)/4);
				if (rndtip==1) kayma=((2-eskikalinlik)/2);
				if (rndtip==3) kayma=((2-eskikalinlik)/2);
				zpos=eskiyolposition.z-((eskiuzunluk-1)+(kalinlik/2));
				xpos=eskiyolposition.x+kayma;	
			}

			float ypos=eskiyolposition.y;
			item.position = new Vector3(xpos,ypos,zpos);

			engellist.Add(item);

			eskikalinlik=kalinlik;
			eskitip=rndtip;
			eskiuzunluk=uzunluk;
			eskiyolposition=item.position;


		}
		listsize = engellist.Count;		
	}


	public void destroyObjects() {
		if (reklamgosterim == 3 && reklamyok==0) {
			if(Advertisement.isReady()) {
				googleAnalytics.LogScreen("UnityReklam");
				Advertisement.Show(null, new ShowOptions {
					pause = true,
					resultCallback = result => {
						
					}
				});
			}
		}
		UnityEngine.Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("DestroyObject", SendMessageOptions.DontRequireReceiver);
		}	
	}

	public void destroyHero() {
		
		UnityEngine.Object[] objects = FindObjectsOfType (typeof(GameObject));
		foreach (GameObject go in objects) {
			go.SendMessage ("DestroyHero", SendMessageOptions.DontRequireReceiver);
		}	
	}

	
	IEnumerator resetgame(){	
		yield return new WaitForSeconds(0.8f);
		MainCamera.GetComponent<VortexEffect>().angle=0;
		Vector3 heropos=new Vector3(0,0.1f,0);
		Hero = Instantiate(Heroprefab, heropos , Quaternion.identity) as Transform;
		Hero.transform.Rotate(new Vector3(0,241,0));	
		anim = Hero.GetComponent<Animator>();
		controller = Hero.GetComponent<CharacterController>();
		int mevcutcharacter = PlayerPrefs.GetInt("mevcutcharacter");
		GameObject.Find("hero(Clone)").transform.FindChild("Box006").transform.GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().materials[0].mainTexture = GameObject.Find("herosecim0").GetComponent<CharacterSecim>().textures[mevcutcharacter];

		GameObject.Find("Clouds").SendMessage("CloudAdd",SendMessageOptions.DontRequireReceiver);	
		MainCamera.SendMessage("resetgame2",SendMessageOptions.DontRequireReceiver);
		GameObject.Find("blackout").GetComponent<Animator>().SetTrigger("open");
		GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuopen");
		engellist.Clear();
		eskiuzunluk=0;
		eskitip =-1;
		eskiyolposition = new Vector3(0,0.25f,0);
		MainCamera.transform.position=(new Vector3(Hero.position.x-8,Hero.position.y+10,Hero.position.z-9));
		MainCamera.transform.LookAt(Hero.position);//makes the camera look to it
		exercise_sound();
		engelno=0;
		score=0;		
		GameObject.Find("ScoreText1").GetComponent<TextMesh>().text=score.ToString();
		GameObject.Find("ScoreText2").GetComponent<TextMesh>().text=score.ToString();
		herokonum=0;
		degree=90;
		speed2=6;
		speed=6;
		menubas=0;

		highscore = PlayerPrefs.GetInt ("highscore");
		GameObject.Find("highscoreText").GetComponent<TextMesh>().text=highscore.ToString();

	}

	IEnumerator resetgame2(){	
		yield return new WaitForSeconds(0.8f);
		MainCamera.GetComponent<VortexEffect>().angle=0;
		Vector3 heropos=new Vector3(0,0.1f,0);
		Hero = Instantiate(Heroprefab, heropos , Quaternion.identity) as Transform;
		Hero.transform.Rotate(new Vector3(0,241,0));
		int mevcutcharacter = PlayerPrefs.GetInt("mevcutcharacter");
		GameObject.Find("hero(Clone)").transform.FindChild("Box006").transform.GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().materials[0].mainTexture = GameObject.Find("herosecim0").GetComponent<CharacterSecim>().textures[mevcutcharacter];
		anim = Hero.GetComponent<Animator>();
		controller = Hero.GetComponent<CharacterController>();
		GameObject.Find("Clouds").SendMessage("CloudAdd",SendMessageOptions.DontRequireReceiver);		
		MainCamera.SendMessage("resetgame2",SendMessageOptions.DontRequireReceiver);
		GameObject.Find("blackout").GetComponent<Animator>().SetTrigger("open");
		//GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuopen");
		engellist.Clear();
		eskiuzunluk=0;
		eskitip =-1;
		eskiyolposition = new Vector3(0,0.25f,0);
		MainCamera.transform.position=(new Vector3(Hero.position.x-8,Hero.position.y+10,Hero.position.z-9));
		MainCamera.transform.LookAt(Hero.position);//makes the camera look to it
		exercise_sound();
		engelno=0;
		score=0;		
		GameObject.Find("ScoreText1").GetComponent<TextMesh>().text=score.ToString();
		GameObject.Find("ScoreText2").GetComponent<TextMesh>().text=score.ToString();
		herokonum=0;
		degree=90;
		speed2=6;
		speed=6;
		menubas=0;
		highscore = PlayerPrefs.GetInt ("highscore");
		GameObject.Find("highscoreText").GetComponent<TextMesh>().text=highscore.ToString();
		menubas=1;
			
		StartCoroutine(particlestart());
		//Hero.Rotate(0, 225, 0);
		Hero.GetComponent<Animator>().SetTrigger("Start");
		//Hero.Rotate(0, 225, 0);
		herostate=1;

		engelekle();
		engeleklendi=1;

		MainCamera.SendMessage("baslat",SendMessageOptions.DontRequireReceiver);
	}

	public void ClickEvent (string buttonname)
	{  

		if (buttonname == "btn_sound") {						

	
			soundlevel = PlayerPrefs.GetInt("soundlevel");
			audiosource.volume = soundlevel;
			if (soundlevel ==0) {
				PlayerPrefs.SetInt("soundlevel", 1);
			}
			else
			{
				PlayerPrefs.SetInt("soundlevel", 0);
			}
			
			SoundLevel();

		}

		if (buttonname == "btn_characters"  && menubas==0) {						
			menubas=1;
			GameObject.Find("Panel2").GetComponent<Animator>().SetTrigger("menuclose");
			MainCamera.SendMessage("character_secim1",SendMessageOptions.DontRequireReceiver);
			GameObject.Find ("PanelCharacter").transform.localPosition = new Vector3(0,0,50);
			audiosource.PlayOneShot(transitionsound1,1-soundlevel);	
			
			int mevcutcharacter = PlayerPrefs.GetInt("mevcutcharacter");
			
			int durum = PlayerPrefs.GetInt("herodurum"+mevcutcharacter.ToString());
			
			if (durum ==0) {
				GameObject.Find("buyHeroText").GetComponent<Text>().enabled=true;
				GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=true;
				GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=true;
				int fiyat = PlayerPrefs.GetInt("herofiyat"+mevcutcharacter.ToString());			
				GameObject.Find("buyHeroText").GetComponent<Text>().text=fiyat.ToString();
				
			}
			else {
				GameObject.Find("buyHeroText").GetComponent<Text>().enabled=false;
				GameObject.Find("buyHeroButton").GetComponent<Image>().enabled=false;
				GameObject.Find("buyHeroCoin").GetComponent<SpriteRenderer>().enabled=false;
			}

		}
		if (buttonname == "btn_herosecimtoanamenu") {						
			menubas=0;
			int mevcutcharacter = PlayerPrefs.GetInt("mevcutcharacter");
			GameObject.Find("hero(Clone)").transform.FindChild("Box006").transform.GetComponent<SkinnedMeshRenderer>().GetComponent<Renderer>().materials[0].mainTexture = GameObject.Find("herosecim0").GetComponent<CharacterSecim>().textures[mevcutcharacter];
			MainCamera.SendMessage("character_secim2",SendMessageOptions.DontRequireReceiver);
			GameObject.Find ("PanelCharacter").transform.localPosition = new Vector3(0,0,-2000);
			GameObject.Find("buyHeroButton").GetComponent<Button>().interactable=true;
			audiosource.PlayOneShot(transitionsound1,1-soundlevel);	
		}

		
		if (buttonname == "btn_play"  && menubas==0) {						
			menubas=1;
			baslat();
			MainCamera.SendMessage("baslat",SendMessageOptions.DontRequireReceiver);
		}

		if (buttonname == "btn_anamenu"  && menubas==0) {						
			menubas=1;
			destroyObjects();
			destroyHero();		
			engeleklendi=0;
			MainCamera.SendMessage ("resetgame", SendMessageOptions.DontRequireReceiver);
			GameObject.Find("EndGamePanel").GetComponent<Animator>().SetTrigger("close");
			GameObject.Find("blackout").GetComponent<Animator>().SetTrigger("close");
			googleAnalytics.LogScreen("Play");		
			StartCoroutine(resetgame());
		

		}

		if (buttonname == "btn_rate" ) {
			RateThisGame();
		}


		if (buttonname == "btn_characterbuy" ) {
		
		}


		if (buttonname == "btn_noads" ) {
			GameObject.Find("IAPStore").SendMessage("noadsbuy",SendMessageOptions.DontRequireReceiver);
		}

		if (buttonname == "btn_replay" && menubas==0) {
			menubas=1;

			destroyObjects();
			destroyHero();
			engeleklendi=0;
			MainCamera.SendMessage ("resetgame", SendMessageOptions.DontRequireReceiver);
			GameObject.Find("EndGamePanel").GetComponent<Animator>().SetTrigger("close");
			GameObject.Find("blackout").GetComponent<Animator>().SetTrigger("close");
			googleAnalytics.LogScreen("Play");		
			StartCoroutine(resetgame2());
			highscore = PlayerPrefs.GetInt ("highscore");

			#if UNITY_IPHONE || UNITY_ANDROID
				if (Social.localUser.authenticated)
				{
					Social.ReportScore(highscore, leadertablo, (bool success1) =>
				    {
						
					});
				}
			#endif			

			/*
			if (CheckForInternetConnection()==true) internetvar=1; else internetvar=0;

			int oyunsayisi= PlayerPrefs.GetInt("oyunsayisi");
			oyunsayisi++;
			PlayerPrefs.SetInt("oyunsayisi",oyunsayisi);
			PlayerPrefs.Save();
			menubas=1;
			GameObject.Find("btn_play").transform.GetComponent<Animator>().SetTrigger("Click");
			float floatParameter = 0.25f;
			string stringParameter = "PlayGame";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));
			*/
		}

		if (buttonname == "btn_twitter" ) {						
			ShareToTwitter("Box Heads game highscore :"+highscore.ToString(),"http://itunes.apple.com/app/box-heads-cupcake-addict/id977041946","");
		}

		if (buttonname == "btn_facebook" ) {						
//			ShareScoreOnFB();
		}
				
		if (buttonname == "btn_leaderboard" ) {						
			LeaderboardOpen();
		}

        /*
		if (buttonname == "btn_leaderboard" && menubas==0) {
			//googleAnalytics.LogScreen("Leaderboard");
			float floatParameter = 0.25f;
			string stringParameter = "LeaderboardOpen";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));			
		}

		if (buttonname == "btn_pause" && panelacik==0) {
			panelacik=1;
			if (hero.GetComponent<AudioSource>().isPlaying == true) {
				hero.GetComponent<AudioSource>().Stop(); 
				hero.GetComponent<AudioSource>().loop=false;
			}
			GameObject.Find("HeroWolf").GetComponent<kurt>().pausebutton=1;
			GameObject.Find("btn_pause").transform.GetComponent<Animator>().SetTrigger("Click");
			float floatParameter = 0.25f;
			string stringParameter = "PauseGame";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));
			StartCoroutine(pauserelease());						
		}
		
		if (buttonname == "btn_sound"  && menubas==0) {						
			GameObject.Find("btn_sound").transform.GetComponent<Animator>().SetTrigger("Click");
			float floatParameter = 0.25f;
			string stringParameter;
			
			soundlevel = PlayerPrefs.GetInt("soundlevel");
			if (soundlevel ==0) {
				PlayerPrefs.SetInt("soundlevel", 1);
			}
			else
			{
				PlayerPrefs.SetInt("soundlevel", 0);
			}
			
			stringParameter = "SoundLevel";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));
		}
		
		
		if (buttonname == "btn_restart") {
			panelacik=0;
			float floatParameter = 0.25f;
			string stringParameter = "RestartGame";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));
			
		}
		
		
		
		if (buttonname == "btn_rateyes") {
			RateThisGame();
			panelacik=0;
			menubas=0;
			ResumeGame();
			
		}
		
		if (buttonname == "btn_rateno") {
			
			panelacik=0;
			menubas=0;
			ResumeGame();
			
		}
		
		
		if (buttonname == "btn_menu") {
			
			GameObject.Find("btn_play").transform.GetComponent<Animator>().SetTrigger("Click");
			
			float floatParameter = 0.5f;
			panelacik=0;
			if (alive==0) {
				GameObject.Find("clawson").GetComponent<Animator>().SetTrigger("start");
				
				ResumeGame();
				
				string stringParameter = "RestartGame";
				object[] parms = new object[2]{floatParameter, stringParameter};
				StartCoroutine(menubuttonwait(parms));
			}
			else
			{
				
				ResumeGame();
			}
			
		}
		if (buttonname == "btn_shop") {
			
			GameObject.Find("btn_play").transform.GetComponent<Animator>().SetTrigger("Click");
			float floatParameter = 0.25f;
			string stringParameter = "Shop";
			object[] parms = new object[2]{floatParameter, stringParameter};
			StartCoroutine(menubuttonwait(parms));			
		}*/
	}



	public void exercise_sound() 
	{
		audiosource.clip=exercisesound;
		audiosource.Play();//OneShot(exercisesound,1-soundlevel);
		audiosource.volume = 1-soundlevel;
		audiosource.loop=true;
	}



	public void run_sound() 
	{
	
		//audiosource.clip=runsound;
		//audiosource.Play();//OneShot(exercisesound,1-soundlevel);
		//audiosource.volume = 1-soundlevel;
		//audiosource.loop=true;
	}
	public void yol_sound1() 
	{
		//	audiosource.PlayOneShot(yolsound1,1-soundlevel);	
	}
	public void cupcake_sound() 
	{
		audiosource.PlayOneShot(cupcakesound,1-soundlevel);	
		score=score+5;

		GameObject.Find("ScoreText1").GetComponent<TextMesh>().text=score.ToString();
		GameObject.Find("ScoreText2").GetComponent<TextMesh>().text=score.ToString();

	}
	
	public void fast_sound() 
	{
		speed2=speed+3;
		if (speed2>11) speed2=11;
		audiosource.PlayOneShot(rocketsound,1-soundlevel);	
		StartCoroutine(speedfastend());
	}
	
	IEnumerator speedfastend(){	
		yield return new WaitForSeconds(5f);
		speed2=8f;
	}
	
	
	public void slow_sound() 
	{
		audiosource.PlayOneShot(cupcakesound,1-soundlevel);	
		speed2=speed-3;
		if (speed2<8) speed2=8;
	}

	public void plane_sound(float distance) 
	{
		audiosource.PlayOneShot(planesound,1-soundlevel-((distance-65)/70));	
		
	}

	public void vortex_effect1(){
		audiosource.PlayOneShot(potionsound,1-soundlevel);	
		
		vortexspeed=0;
		vortexspeed2=50;
		vortexaccel = 0.5f;
		MainCamera.GetComponent<VortexEffect>().enabled=true;
		StartCoroutine(vortex_effect2());
	}
	
	IEnumerator vortex_effect2(){
		yield return new WaitForSeconds(3.0f);
		vortexaccel = 0.5f;
		vortexspeed=50;
		vortexspeed2=0;	
	}
	
	public void vortex_effect21(){
		vortexspeed=50;
		vortexspeed2=0;
		vortexaccel = 0.5f;
	}
	
	
	public void coin_sound() 
	{
		audiosource.PlayOneShot(coinsound,1-soundlevel);	
		coin++;
		GameObject.Find("CoinText1").GetComponent<TextMesh>().text=coin.ToString();
		GameObject.Find("CoinText2").GetComponent<TextMesh>().text=coin.ToString();
		PlayerPrefs.SetInt("Coin",coin);

	}
	public void confetti_sound() 
	{
		audiosource.PlayOneShot(confettisound,1-soundlevel);	
	}
	public void turn_sound() 
	{

		audiosource.PlayOneShot(turnsound,1-soundlevel);	
	}

	public void descending_sound() 
	{
		audiosource.PlayOneShot(descendingsound,1-soundlevel);	
	}
	public void button_sound() 
	{
		audiosource.PlayOneShot(buttonsound,1-soundlevel);	
	}
	public void button2_sound() 
	{
		audiosource.PlayOneShot(button2sound,1-soundlevel);	
	}
	public void button3_sound() 
	{
		audiosource.PlayOneShot(button3sound,1-soundlevel);	
	}
	public void fall_sound() 
	{
		///// reklam gosterim
		/// 
		
		reklamgosterim = PlayerPrefs.GetInt ("reklamgosterim");
		reklamgosterim++;
		if (reklamgosterim == 4) reklamgosterim=0;
		PlayerPrefs.SetInt("reklamgosterim",reklamgosterim);
		PlayerPrefs.Save();
		
		//////
		/// 
		/// 
		speed2=0;
		audiosource.Stop();
		audiosource.PlayOneShot(fallsound,1-soundlevel);	

		StartCoroutine(tozbulutsphere());
	}
	IEnumerator tozbulutsphere(){	
	
		yield return new WaitForSeconds(1.3f);
		herostate=2;

		tozbulut2 = Instantiate(tozbulut1, new Vector3(Hero.transform.position.x,-300,Hero.transform.position.z), Quaternion.identity) as Transform;
		tozbulut2.transform.position = new Vector3(Hero.transform.position.x,Hero.transform.position.y-30,Hero.transform.position.z);
		Hero.FindChild("Box006").GetComponent<Renderer>().enabled=false;
		Hero.FindChild("heroTrailer").GetComponent<Renderer>().enabled=false;
		Hero.GetComponent<CharacterController>().enabled=false;
		tozbulut2.GetComponent<Animator>().SetTrigger("Carpma");
		menubas=0;
		GameObject.Find("AScoreText1").GetComponent<TextMesh>().text  ="Score : "+score.ToString();
		GameObject.Find("AScoreText2").GetComponent<TextMesh>().text  ="Score : "+score.ToString();

		GameObject.Find("ABestScoreText1").GetComponent<TextMesh>().text  ="Best Score : "+highscore.ToString();
		GameObject.Find("ABestScoreText2").GetComponent<TextMesh>().text  ="Best Score : "+highscore.ToString();


		GameObject.Find("EndGamePanel").GetComponent<Animator>().SetTrigger("open");

		highscore = PlayerPrefs.GetInt ("highscore");
		if (score>=highscore) {
			highscore=score;
			PlayerPrefs.SetInt("highscore",highscore);
		}
	}

	IEnumerator particlestart(){	
		StartCoroutine(FadeMusic());
		yield return new WaitForSeconds(1.5f);
		audiosource.volume = 1;
		confetti_sound();
		GameObject.Find ("ParticleConfetti1").SendMessage("confetti",SendMessageOptions.DontRequireReceiver);	
		GameObject.Find ("ParticleConfetti2").SendMessage("confetti",SendMessageOptions.DontRequireReceiver);
		GameObject.Find ("ParticleConfetti3").SendMessage("confetti",SendMessageOptions.DontRequireReceiver);
		GameObject.Find ("ParticleConfetti4").SendMessage("confetti",SendMessageOptions.DontRequireReceiver);
		StartCoroutine(speedstart());
	}

	IEnumerator FadeMusic()
	{
		while(audiosource.volume > .1F)
		{
			audiosource.volume = Mathf.Lerp(audiosource.volume,0F,Time.deltaTime*2);
			yield return 0;
		}
		audiosource.volume = 0;
		audiosource.Stop();

	}


	public void SoundLevel()
	{
		soundlevel = PlayerPrefs.GetInt("soundlevel");
		if (soundlevel==0) {
			GameObject.Find("soundicon1").GetComponent<Renderer>().enabled=true;
			GameObject.Find("soundicon2").GetComponent<Renderer>().enabled=false;		

		}
		else
		{
			//audiosource.Stop ();
		
			GameObject.Find("soundicon1").GetComponent<Renderer>().enabled=false;
			GameObject.Find("soundicon2").GetComponent<Renderer>().enabled=true;
		}
	}

	public static bool CheckForInternetConnection()
	{
		try
		{
			using (var client = new System.Net.WebClient())
				using (var stream = client.OpenRead("http://www.google.com"))
			{
				return true;
			}
		}
		catch
		{
			return false;
		}
	}
	



}

public class Renk {
	
	public Vector4 renk;
}

public class Engel {
	
	public int uzunluk;
	public int aci;
	public float kalinlik;
	public int engelno;
	public int no;
	public int durum;
	public int yoltip;
	public Vector3 position;
	public Vector4 renk;
	public void goster(){
		durum = 1;
	}
	
	
}
