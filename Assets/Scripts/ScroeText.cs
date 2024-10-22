using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScroeText : MonoBehaviour
{
    public BasketballHoop basketballHoop; // BasketballHoop ��ũ��Ʈ ����
    public TextMeshProUGUI scoreText; // UI Text ������Ʈ ����

    private void Start()
    {
        // �ʱ� ���� ǥ��
        UpdateScoreText();
    }

    private void Update()
    {
        // �� ������ ������ ������Ʈ
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // ���� �ؽ�Ʈ ������Ʈ
        scoreText.text = "Score: " + basketballHoop.score;
    }
}
