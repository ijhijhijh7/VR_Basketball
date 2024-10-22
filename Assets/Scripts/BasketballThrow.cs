using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BasketballThrow : MonoBehaviour
{
    public float maxSpeed = 100f;             // �ִ� �ӵ�
    public float minSpeed = 20f;              // �ּ� �ӵ�
    public float speedMultiplier = 30f;       // �ӵ� ������ ���� ���

    private Vector3 previousPosition;        // ���� �������� ��Ʈ�ѷ� ��ġ
    private Vector3 currentSpeed;            // ���� ��Ʈ�ѷ� �ӵ� ����

    private XRGrabInteractable grabInteractable;   // �󱸰��� ����� XR Grab Interactable
    private Rigidbody rb;                          // �󱸰��� Rigidbody

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();   // XR Grab Interactable ������Ʈ ��������
        rb = GetComponent<Rigidbody>();                          // �󱸰��� Rigidbody
    }

    private void FixedUpdate()
    {
        // ��� ���� ���� ��Ʈ�ѷ��� ��ġ ��ȭ�� �ӵ� ���
        if (grabInteractable.isSelected && grabInteractable.interactorsSelecting.Count > 0)
        {
            // ��Ʈ�ѷ� ��ġ ��� �ӵ� ���
            Vector3 currentPosition = grabInteractable.interactorsSelecting[0].transform.position;
            currentSpeed = (currentPosition - previousPosition) / Time.fixedDeltaTime;
            previousPosition = currentPosition;
        }
    }

    public void OnRelease(SelectExitEventArgs args)
    {
        // ���� ���� �� ��Ʈ�ѷ��� �ӵ��� ������ ����
        if (rb != null && grabInteractable.interactorsSelecting.Count > 0)
        {
            float throwSpeed = currentSpeed.magnitude * speedMultiplier;
            throwSpeed = Mathf.Clamp(throwSpeed, minSpeed, maxSpeed);

            // ������ ������ ��Ʈ�ѷ��� �ӵ��� ������� ��
            rb.velocity = currentSpeed.normalized * throwSpeed;

            // ���� �� �ڿ������� ���ư����� �ޱַ� ���ν�Ƽ �߰�
            rb.angularVelocity = Random.insideUnitSphere * throwSpeed * 0.1f;  // ȸ�� ȿ�� �߰�
        }
    }
}
