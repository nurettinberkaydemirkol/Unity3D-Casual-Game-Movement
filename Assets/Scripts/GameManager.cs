using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int Coin;

    public Text coinInfoText;
   
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Coin = PlayerPrefs.GetInt("Coin");


        coinInfoText.text = Coin.ToString();
    }

    void Update()
    {
        
    }
}
