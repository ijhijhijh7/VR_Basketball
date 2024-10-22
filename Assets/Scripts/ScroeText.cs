using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScroeText : MonoBehaviour
{
    public BasketballHoop basketballHoop; // BasketballHoop 스크립트 참조
    public TextMeshProUGUI scoreText; // UI Text 컴포넌트 참조

    private void Start()
    {
        // 초기 점수 표시
        UpdateScoreText();
    }

    private void Update()
    {
        // 매 프레임 점수를 업데이트
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // 점수 텍스트 업데이트
        scoreText.text = "Score: " + basketballHoop.score;
    }
}
