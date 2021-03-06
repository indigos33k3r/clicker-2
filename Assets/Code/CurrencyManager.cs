﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {
    #region Fields

    [SerializeField]
    TextMeshProUGUI currencyText;

    [SerializeField]
    TextMeshProUGUI premiumCurrencyText;
    
    [SerializeField]
    ParticleSystem particles;

    int currencyAmount;
    int premiumCurrencyAmount;

    #endregion

    #region Properties

    public static CurrencyManager Instance { get; private set; }

    CurrencyDefaults[] Currency { get; set; }

    #endregion

    #region Events

    #endregion

    #region Methods

    #region Unity

    #endregion

    public void Initialize () {
        Instance = this;

        //TODO: temp until added to json
        Currency = DataConvert.SetCurrencyDefaults (2);
        Currency[0].Currency = "gold";
        currencyAmount = Currency[0].Amount = 0;
        Currency[0].Currency = "diamond";
        premiumCurrencyAmount = Currency[0].Amount = 50;

        currencyText.text = currencyAmount.ToString ();
        premiumCurrencyText.text = premiumCurrencyAmount.ToString ();
    }

    public void IncreaseCurrency (string currency, int amount) {
        switch (currency) {
            case "gold":
                currencyAmount += amount;
                currencyText.text = currencyAmount.ToString ();
                particles.Play ();
                break;
            case "diamonds":
                premiumCurrencyAmount += amount;
                premiumCurrencyText.text = premiumCurrencyAmount.ToString ();
                break;
        }
    }
    
    public void DecreaseCurrency (string currency, int amount) {
        switch (currency) {
            case "gold":
                currencyAmount -= amount;
                currencyText.text = currencyAmount.ToString ();
                break;
            case "diamonds":
                premiumCurrencyAmount -= amount;
                premiumCurrencyText.text = premiumCurrencyAmount.ToString ();
                break;
        }
    }

    #endregion
}