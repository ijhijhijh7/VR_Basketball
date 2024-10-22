using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Ÿ�̸� �ؽ�Ʈ�� ���� TextMeshProUGUI
    public BasketballHoop basketballHoop; // BasketballHoop ��ũ��Ʈ ����

    private float timeRemaining = 30f; // �ʱ� �ð� 30��
    private bool timerRunning = false;
    public bool bonusTimeActive = false; // ���ʽ� �ð��� Ȱ��ȭ�Ǿ����� Ȯ��

    private void Start()
    {
        timerRunning = true; // Ÿ�̸� ����
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (timeRemaining > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1f); // 1�� ���
            timeRemaining -= 1f; // 1�ʾ� �پ��

            // �ð��� 10�� ������ �� �ؽ�Ʈ ���� ����
            if (timeRemaining <= 10)
            {
                timerText.color = Color.red;
            }
        }

        // �ð��� �� ������ ���� ó��
        OnTimeExpired();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString(); // ���� �ð� ǥ��
    }

    private void OnTimeExpired()
    {
        // �ð��� �� ������ �� ���� üũ
        if (basketballHoop.score >= 10)
        {
            timeRemaining += 15f; // 15�� �߰�
            bonusTimeActive = true; // ���ʽ� �ð� Ȱ��ȭ

            // ��������� �����ϰ� x2 ǥ��
            timerText.color = Color.yellow;
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + " (x2 ����)";

            Debug.Log("���ʽ� �ð��� ���۵Ǿ����ϴ�! ���� ����: " + basketballHoop.score);
        }
        else
        {
            Debug.Log("����: " + basketballHoop.score + ". �߰� �ð��� �����ϴ�.");
        }

        // ���� �ð��� 0�� �Ǿ����Ƿ�, Ÿ�̸Ӹ� ����
        timerRunning = false;
        UpdateTimerText(); // ���� ���� �ð� ������Ʈ
    }

    private void Update()
    {
        if (bonusTimeActive)
        {
            // ���ʽ� �ð��� Ȱ��ȭ�Ǹ� ī��Ʈ�ٿ�
            timeRemaining -= Time.deltaTime;

            // ���ʽ� �ð��� ������ �� ó��
            if (timeRemaining <= 0)
            {
                bonusTimeActive = false;
                timerRunning = false; // Ÿ�̸� ����
                timerText.text = "���ʽ� �ð��� ����Ǿ����ϴ�!"; // ���ʽ� �ð� ���� �޽���
            }

            UpdateTimerText(); // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        }
    }
}
