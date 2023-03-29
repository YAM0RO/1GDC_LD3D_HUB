using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItemsManager : MonoBehaviour
{
    public int ItemPrice;
    public GameObject AchatSuccess;
    public GameObject AchatFailed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyItems()
    {
        if(ItemPrice <= MoneyManager.MoneyAmmount)
        {
            AchatFailed.SetActive(false);
            AchatSuccess.SetActive(true);
            MoneyManager.MoneyAmmount -= ItemPrice;
        }
        else
        {
            AchatFailed.SetActive(true);
            AchatSuccess.SetActive(false);
        }
    }
}
