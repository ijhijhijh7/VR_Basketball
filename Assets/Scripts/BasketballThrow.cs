using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BasketballThrow : MonoBehaviour
{
    public float maxSpeed = 100f;             // 최대 속도
    public float minSpeed = 20f;              // 최소 속도
    public float speedMultiplier = 30f;       // 속도 조절을 위한 배수

    private Vector3 previousPosition;        // 이전 프레임의 컨트롤러 위치
    private Vector3 currentSpeed;            // 현재 컨트롤러 속도 벡터

    private XRGrabInteractable grabInteractable;   // 농구공에 적용된 XR Grab Interactable
    private Rigidbody rb;                          // 농구공의 Rigidbody

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();   // XR Grab Interactable 컴포넌트 가져오기
        rb = GetComponent<Rigidbody>();                          // 농구공의 Rigidbody
    }

    private void FixedUpdate()
    {
        // 잡고 있을 때만 컨트롤러의 위치 변화로 속도 계산
        if (grabInteractable.isSelected && grabInteractable.interactorsSelecting.Count > 0)
        {
            // 컨트롤러 위치 기반 속도 계산
            Vector3 currentPosition = grabInteractable.interactorsSelecting[0].transform.position;
            currentSpeed = (currentPosition - previousPosition) / Time.fixedDeltaTime;
            previousPosition = currentPosition;
        }
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        // 공을 놓을 때 컨트롤러의 속도를 적용해 던짐
        if (rb != null && grabInteractable.interactorsSelecting.Count > 0)
        {
            float throwSpeed = currentSpeed.magnitude * speedMultiplier;
            throwSpeed = Mathf.Clamp(throwSpeed, minSpeed, maxSpeed);

            // 던지는 방향은 컨트롤러의 속도를 기반으로 함
            rb.velocity = currentSpeed.normalized * throwSpeed;

            // 공이 더 자연스럽게 날아가도록 앵귤러 벨로시티 추가
            rb.angularVelocity = Random.insideUnitSphere * throwSpeed * 0.1f;  // 회전 효과 추가
        }
    }
}
