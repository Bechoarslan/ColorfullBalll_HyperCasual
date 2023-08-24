using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;

public class IAPManager : MonoBehaviour, IStoreListener
{
    IStoreController controller;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private string[] product;
    [SerializeField] private Sound soundManager;

   
    public void Start() 
    {
        IAPStart();
    }

    private void IAPStart()
    {
        
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);

        foreach (string item in product) 
        {
            builder.AddProduct(item,ProductType.Consumable);
        }
        
        UnityPurchasing.Initialize(this,builder);
        
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialized Failed");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new NotImplementedException();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log("Purchase Failed");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {

        if(String.Equals(purchaseEvent.purchasedProduct.definition.id,product[0],StringComparison.Ordinal)) 
        {
           int money = PlayerPrefs.GetInt("Money");
           PlayerPrefs.SetInt("Money", money+200);
           uiManager.CoinText();
           soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if(String.Equals(purchaseEvent.purchasedProduct.definition.id, product[1], StringComparison.Ordinal)) 
        {
            int money = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", money + 500);
            uiManager.CoinText();
            soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {

            int money = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", money + 1000);
            uiManager.CoinText();
            soundManager.CashSound();
            return PurchaseProcessingResult.Complete;
        }
        else if (String.Equals(purchaseEvent.purchasedProduct.definition.id, product[3], StringComparison.Ordinal))
        {
            if(PlayerPrefs.HasKey("NoAds")) 
            {
                PlayerPrefs.SetInt("NoAds", 1);
                uiManager.NoAds();
                soundManager.CashSound();
            }
            
            return PurchaseProcessingResult.Complete;
        }
        else  
        {
            return PurchaseProcessingResult.Pending;
        }
        
    }

    public void IAPButton(string id) 
    {
        Product product = controller.products.WithID(id);
        if(product != null && product.availableToPurchase) 
        {
            controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else 
        
        Debug.Log("not buying");
    }

}
