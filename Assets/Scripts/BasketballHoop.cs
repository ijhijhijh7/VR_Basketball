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
            // ���ʽ� �ð� Ȱ��ȭ �� 2�� �߰�
            if (FindObjectOfType<TimeManager>().bonusTimeActive)
            {
                score += 2; // 2�� �߰�
            }
            else
            {
                score += 1; // �Ϲ� ���� �߰�
            }

            Debug.Log("����: " + score);
        }
    }
}
