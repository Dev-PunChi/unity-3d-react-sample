using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CallReact(string userName, int score);

    // Start is called before the first frame update
    public int Score
    {
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

    public void UnityCall()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
    CallReact("Sample User", Score);
#endif
    }

    public void BtnClick()
    {
        Score++;
        UnityCall();
    }
}