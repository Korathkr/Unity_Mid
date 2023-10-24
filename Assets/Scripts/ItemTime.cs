using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTime : MonoBehaviour
{
    public AudioClip TimeStop;
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ
    private float timer = 0.0f;
    private float cool = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
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
                GameManager.instance.ScrollingSpeed = 10.0f;
                timer = 0.0f; // Ÿ�̸� �ʱ�ȭ
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.instance.ScrollingSpeed = 8.0f;
            GameManager.instance.isTimerActive = true;
            playerAudio.clip = TimeStop;
            playerAudio.Play();
            // OnCollisionEnter2D �̺�Ʈ�� �߻��ϸ� jumpMax�� 4�� �����ϰ� Ÿ�̸Ӹ� Ȱ��ȭ�մϴ�.
            // �������� �ı��մϴ�.
            Destroy(gameObject);
        }
    }
}
