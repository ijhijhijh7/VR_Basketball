using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballHoop : MonoBehaviour
{
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        // �󱸰��� ���� ����ߴ��� Ȯ��
        if (other.CompareTag("Basketball"))
        {
            score += 1;
            Debug.Log("����: " + score);
        }
    }
}
