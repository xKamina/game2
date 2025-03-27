using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Cantidad de manzanas conseguidas")]
    public Text currentApples;

    [Tooltip("Cantidad de vidas")]
    public Text currentLife;

    [Tooltip("Cantidad de cajas conseguidas")]
    public Text currentBoxes;

    public Text gemScore;
        
    public int apples = 0;
    public int boxes = 0;
    public int life;
    public int totalBoxes;    
    public static GameManager Instance { get; private set; }    

    private void Awake()
    {
        Instance = this; 
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {        
        apples = 0;
        boxes = 0;
        life = 5;
        totalBoxes = 15;           
    }

    private void Update()
    {

        currentApples.text = apples.ToString();
        currentBoxes.text = boxes.ToString();
        currentLife.text = life.ToString();        

        if (apples >= 50)
        {
            apples = 0;
            life++;           
        }             
        
    }     

    public void LoseLife(int amount)
    {
        life -= amount;
    }
}




