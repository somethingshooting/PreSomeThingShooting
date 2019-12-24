using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Score, _HightScore;

    private GameManager GameManager;

    float _timer = 0;
    bool _viewedHightscore = false;

    private void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        ShowCurrentScore();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if ((_timer > 3 || Input.GetMouseButtonDown(0)) && !_viewedHightscore)
        {
            ShowHightScore();
            _viewedHightscore = true;
        }
    }

    private void ShowCurrentScore()
    {
        _Score.text = GameManager.Score.ToString();
    }

    private void ShowHightScore()
    {
        transform.Find("ScorePanel").gameObject.SetActive(false);
        transform.Find("HightScorePanel").gameObject.SetActive(true);
        _HightScore.text = GameManager.HightScore.ToString();
    }
}
