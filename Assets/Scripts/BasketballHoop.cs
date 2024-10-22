using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballHoop : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        // 농구공이 링을 통과했는지 확인
        if (other.CompareTag("Basketball"))
        {
            // 보너스 시간 활성화 시 2점 추가
            if (FindObjectOfType<TimeManager>().bonusTimeActive)
            {
                score += 2; // 2점 추가
            }
            else
            {
                score += 1; // 일반 점수 추가
            }

            Debug.Log("점수: " + score);
        }
    }
}
