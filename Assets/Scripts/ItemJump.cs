using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemJump : MonoBehaviour
{
    private float timer = 0.0f;
    private float cool = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�̸Ӱ� Ȱ��ȭ�Ǿ��� ���� Ÿ�̸Ӹ� �����մϴ�.
        if (GameManager.instance.isTimerActive)
        {
            timer += Time.deltaTime;
            // 10�ʰ� ������ Ÿ�̸Ӹ� ��Ȱ��ȭ�ϰ� jumpMax�� 2�� �����մϴ�.
            if (timer >= cool)
            {
                GameManager.instance.isTimerActive = false;
                GameManager.instance.jumpMax = 2;
                timer = 0.0f; // Ÿ�̸� �ʱ�ȭ
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.instance.isTimerActive = true;
            // OnCollisionEnter2D �̺�Ʈ�� �߻��ϸ� jumpMax�� 4�� �����ϰ� Ÿ�̸Ӹ� Ȱ��ȭ�մϴ�.
            GameManager.instance.jumpMax = 4;
            // �������� �ı��մϴ�.
            Destroy(gameObject);
        }
    }
}