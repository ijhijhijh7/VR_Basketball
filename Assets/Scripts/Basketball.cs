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

    // 공이 던져질 때 물리적 속도 적용
    public void OnRelease()
    {
        rb.velocity = Vector3.zero;  // 던질 때 기존 속도를 초기화
    }
}
