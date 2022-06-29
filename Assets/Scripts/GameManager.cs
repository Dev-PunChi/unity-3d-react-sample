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

    public Camera cam;
    private Vector3 _position;
    private Quaternion _quaternion;

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

    public void CameraMove()
    {
        Debug.Log("Camera Move");
        _position = new Vector3(111.818f, 23.80329f, 22.51221f);
        _quaternion = Quaternion.Euler(new Vector3(63.014f, -179.346f, 0));
    }

    private void Awake()
    {
        _position = Vector3.zero;
        _quaternion = Quaternion.identity;
    }


    private void LateUpdate()
    {
        if (_position != Vector3.zero)
        {
            cam.transform.position = _position;
            _position = Vector3.zero;
        }
        if (_quaternion != Quaternion.identity)
        {
            cam.transform.rotation = _quaternion;
            _quaternion = Quaternion.identity;
        }

    }
}