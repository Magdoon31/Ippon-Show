using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class player : MonoBehaviour
{
    public static player Instance;
    [Header("Health")]
    public Health health;
    public PlayerHealthBarUI healthBar;
    public int HPLevel { get; private set; }

    [Header("Deck")]
    public List<CardData> originalDeck = new List<CardData>();
    public List<CardData> deck = new List<CardData>();

    void Awake()
    {
        Instance = this;
    }
    protected void Start()
    {
        health.currentHP = health.maxHP;
        DeckManager.Instance.ResetDeck();
    }
    private void Update()
    {
        Health health = GetComponent<Health>();
        health.UpdateHPLevel();
    }
}

