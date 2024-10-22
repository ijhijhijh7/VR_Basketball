using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // ���� ������ �� ������ �ӵ� ����
    public void OnRelease()
    {
        rb.velocity = Vector3.zero;  // ���� �� ���� �ӵ��� �ʱ�ȭ
    }
}
