using UnityEngine;
using System.Collections;

namespace Soomla.Store.Example                                                                                                                  //Allows for access to Soomla API
{
	public class StoreAssets : IStoreAssets                                                                                       //Extend from IStoreAssets (required to define assets)
	{
		public int GetVersion() {                                                                                                               // Get Current Version
			return 0;
		}
		
		public VirtualCurrency[] GetCurrencies() {                                                                              // Get/Setup Virtual Currencies
			return new VirtualCurrency[]{};
		}
		
		public VirtualGood[] GetGoods() {                                                                                               // Add "TURN_GREEN" IAP to GetGoods
			return new VirtualGood[]{NO_ADS};
		}
		
		public VirtualCurrencyPack[] GetCurrencyPacks() {                                                               // Get/Setup Currency Packs
			return new VirtualCurrencyPack[]{};
		}
		
		public VirtualCategory[] GetCategories() {                                                                              // Get/ Setup Categories (for In App Purchases)
			return new VirtualCategory[]{};
		}
		
		//****************************BOILERPLATE ABOVE(modify as you see fit/ if nessisary)***********************
		public const string NO_ADS_PRODUCT_ID = "com.quaxel.cubeheads.noads";                              //create a string to store the "turn green" in app purchase
		public const string NO_ADS_ITEM_ID = "no_ads_item_id";        
		
		/** Lifetime Virtual Goods (aka - lasts forever **/
		
		// Create the 'TURN_GREEN' LifetimeVG In-App Purchase
		public static VirtualGood NO_ADS = new LifetimeVG(         
		                                                      "noads",                                                                                                                               // Name of IAP
		                                                      "Remove In Game Ads.",                                                                                   // Description of IAP
		                                                      "no_ads_item_id",                                                                                                               // Item ID (different from 'product id" used by itunes, this is used by soomla)
		                                                      
		                                                      // 1. assign the purchase type of the IAP (purchaseWithMarket == item cost real money),
		                                                      // 2. assign the IAP as a market item (using its ID)
		                                                      // 3. set the item to be a non-consumable purchase type
		                                                      
		                                                      //                  1.                                      2.                                              3.
		                                                      new PurchaseWithMarket(NO_ADS_PRODUCT_ID, 1.99)
		                                                      );
	}
}

