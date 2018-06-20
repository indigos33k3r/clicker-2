﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiningManager : MonoBehaviour {
    #region Fields

    [SerializeField]
    MiningResource[] resourceMines;
    
    [SerializeField]
    GameObject titleText;

    #endregion

    #region Properties

    public static MiningManager Instance { get; private set; }

    #endregion

    #region Events

    public Action<string> OnResourceMined;

    #endregion

    #region Methods

    #region Unity

    void OnDisable () {
        Terminate ();
    }

    #endregion

    public void Initialize () {
        Instance = this;
        titleText.SetActive (true);
        foreach (var mine in resourceMines) {
            mine.OnResourceMined += AddItemToInventory;
            mine.Initialize ();
        }
    }

    void Terminate () {
        foreach (var mine in resourceMines) {
            mine.OnResourceMined -= AddItemToInventory;
        }
    }

    void AddItemToInventory (string resource) {
        if (OnResourceMined != null) {
            OnResourceMined (resource);
        }
    }

    #endregion
}