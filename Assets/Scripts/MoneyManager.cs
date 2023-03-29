using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static int MoneyAmmount;
    public Text moneyLabel;
    void Start()
    {
        MoneyAmmount = 500;
    }

    // Update is called once per frame
    void Update()
    {
        moneyLabel.text = MoneyAmmount.ToString();
    }
}
