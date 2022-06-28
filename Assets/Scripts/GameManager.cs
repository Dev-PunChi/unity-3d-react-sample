using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score { 
        get => score; 
        set 
        {
            score = value;
            sampleText.text = score.ToString();
            Debug.Log(score);
        }
    }
    private int score = 0;
    public TextMeshProUGUI sampleText;

    public void BtnClick()
    {
        Score++;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
