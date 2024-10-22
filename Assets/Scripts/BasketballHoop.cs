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
            score += 1;
            Debug.Log("점수: " + score);
        }
    }
}
