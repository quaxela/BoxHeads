using UnityEngine;
using System.Collections;

public class iAD : MonoBehaviour {
	public bool showOnTop = true;
	public bool dontDestroy = false;
	int reklamyok=0;

	#if UNITY_IPHONE
	private UnityEngine.iOS.ADBannerView banner;
	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetInt ("noadsowned") == 1) reklamyok=1;
		if (reklamyok==0)
		{
			if(dontDestroy)
			{
				GameObject.DontDestroyOnLoad(gameObject);
			}
		
			banner = new UnityEngine.iOS.ADBannerView(UnityEngine.iOS.ADBannerView.Type.Banner,showOnTop? UnityEngine.iOS.ADBannerView.Layout.Top : UnityEngine.iOS.ADBannerView.Layout.Bottom);
		
			UnityEngine.iOS.ADBannerView.onBannerWasLoaded += onBannerLoaded;
		}
	}
	
	// onBannerLoaded is declared here
	void onBannerLoaded () 
	{
		if (PlayerPrefs.GetInt ("noadsowned") == 1) reklamyok=1;
		if (reklamyok==0)
		{
			banner.visible = true;
		}
	}

	public void ReklamKaldir() 
	{
		if (PlayerPrefs.GetInt ("noadsowned") == 1) reklamyok=1;
		if (reklamyok==1)
		{
			banner.visible = false;
		}
	
	}

	#endif
}