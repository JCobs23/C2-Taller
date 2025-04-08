using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerScene1 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtGemaScore;
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
        txtGemaScore.text=GameManager.Instance.Score.ToString();
    }
}
