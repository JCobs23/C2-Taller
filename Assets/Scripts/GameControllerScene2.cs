using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerScene2 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtAppleScore;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        txtAppleScore.text = GameManager.Instance.Score.ToString();
    }
}
