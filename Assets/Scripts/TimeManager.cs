using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 타이머 텍스트를 위한 TextMeshProUGUI
    public BasketballHoop basketballHoop; // BasketballHoop 스크립트 참조

    private float timeRemaining = 30f; // 초기 시간 30초
    private bool timerRunning = false;
    public bool bonusTimeActive = false; // 보너스 시간이 활성화되었는지 확인
    private bool gameEnded = false; // 게임 종료 여부 확인

    private void Start()
    {
        timerRunning = true; // 타이머 시작
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine()
    {
        while (timeRemaining > 0)
        {
            UpdateTimerText();
            yield return new WaitForSeconds(1f); // 1초 대기
            timeRemaining -= 1f; // 1초씩 줄어듦

            // 시간이 10초 남았을 때 텍스트 색상 변경
            if (timeRemaining <= 10)
            {
                timerText.color = Color.red;
            }
        }

        // 시간이 다 지났을 때의 처리
        OnTimeExpired();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString(); // 남은 시간 표시
    }

    private void OnTimeExpired()
    {
        // 시간이 다 지났을 때 점수 체크
        if (basketballHoop.score >= 10)
        {
            timeRemaining += 15f; // 15초 추가
            bonusTimeActive = true; // 보너스 시간 활성화

            // 노란색으로 변경하고 x2 표시
            timerText.color = Color.yellow;
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + " (x2 Score)";

            Debug.Log("보너스 시간이 시작되었습니다! 현재 점수: " + basketballHoop.score);
        }
        else
        {
            Debug.Log("점수: " + basketballHoop.score + ". 추가 시간이 없습니다.");
            gameEnded = true; // 게임 종료 상태로 설정
            StartCoroutine(ResetScoreAfterDelay(3f)); // 3초 후 점수 초기화
        }

        // 남은 시간이 0이 되었으므로, 타이머를 멈춤
        timerRunning = false;
        UpdateTimerText(); // 최종 남은 시간 업데이트
    }

    private IEnumerator ResetScoreAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 3초 대기
        basketballHoop.score = 0; // 점수 초기화
        Debug.Log("점수가 초기화되었습니다.");
    }

    private void Update()
    {
        if (bonusTimeActive)
        {
            // 보너스 시간이 활성화되면 카운트다운
            timeRemaining -= Time.deltaTime;

            // 보너스 시간이 끝났을 때 처리
            if (timeRemaining <= 0)
            {
                bonusTimeActive = false;
                timerRunning = false; // 타이머 멈춤

                // 보너스 시간이 끝난 후 점수 초기화하는 코루틴 시작
                StartCoroutine(ResetScoreAfterDelay(3f));
                return;
            }

            UpdateTimerText(); // 타이머 텍스트 업데이트
        }
        else if (!timerRunning && timeRemaining <= 0 && !gameEnded)
        {
            gameEnded = true; // 게임 종료 상태로 설정
            StartCoroutine(ResetScoreAfterDelay(3f));
        }
    }
}
