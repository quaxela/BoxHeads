	using System;
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	
	namespace Soomla.Store.Example
	{                                                                                                                                               //Allows for access to Soomla API                                                                              
		public class StoreWindowScript : MonoBehaviour
		{      
			
			void Start ()
			{
//				Application.LoadLevel ("test");                                                                                                                         //Load actual scene/
//				DontDestroyOnLoad(transform.gameObject);                                                                                                        //Allows this gameObject to remain during level loads, solving restart crashes
				StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreIntitialized;                  

				SoomlaStore.Initialize (new StoreAssets());
				//StoreEvents.OnItemPurchased += onItemPurchased;
				StoreEvents.OnMarketPurchase += onMarketPurchase;
			}
			

			public void onSoomlaStoreIntitialized(){

			}
	/*
			public void onItemPurchased(PurchasableVirtualItem pvi, string payload)
			{

				switch (pvi.ItemId)
				{
					case StoreAssets.NO_ADS_PRODUCT_ID:
					PlayerPrefs.SetInt ("noadsowned",1);
				    GameObject.Find("GameController").SendMessage("ReklamKaldir",SendMessageOptions.DontRequireReceiver);
					GameObject.Find("iAD").SendMessage("ReklamKaldir",SendMessageOptions.DontRequireReceiver);
					break;
				}
				
			}
		*/
		public void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string,string> extra)
		{
			
			switch (pvi.ItemId)
			{
			    case StoreAssets.NO_ADS_ITEM_ID:
				PlayerPrefs.SetInt ("noadsowned",1);
				GameObject.Find("GameController").SendMessage("ReklamKaldir",SendMessageOptions.DontRequireReceiver);
				GameObject.Find("iAD").SendMessage("ReklamKaldir",SendMessageOptions.DontRequireReceiver);
				break;
			}
			
		}
			/*
			void CheckIAP_PurchaseStatus(){
		
				if (StoreInventory.GetItemBalance("no_ads_item_id") >= 1)
				{
						//NoAdsIAPOwned  = true;   
				}
			}
			*/

		public void noadsbuy() {
			try {

				
				StoreInventory.BuyItem ("no_ads_item_id");      
			}
			catch (Exception e)
			{                                                   
				Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
			}

		}

		/*
		void OnGUI() {
			//Button To PURCHASE ITEM
			if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.4f, 150,150),"Make green?"))
			{
				try {
					Debug.Log("attempt to purchase");
					
					StoreInventory.BuyItem ("no_ads_item_id");                                                                          // if the purchases can be completed sucessfully
				}
				catch (Exception e)
				{                                                                                                                                                                               // if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
					Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
				}
			}
			//Button to RESTORE PURCHASES
			if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.8f, 150,150),"Restore\nPurchases")) {
				try
				{
					SoomlaStore.RestoreTransactions();                                                                                                      // restore purchases if possible
				}
				catch (Exception e)
				{
					Debug.Log ("SOOMLA/UNITY" + e.Message);                                                                                         // if restoring purchases fails (connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				}
			}
			

		}*/


		}
	}
	
