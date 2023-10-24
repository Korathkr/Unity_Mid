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
        // 타이머가 활성화되었을 때만 타이머를 갱신합니다.
        if (GameManager.instance.isTimerActive)
        {
            timer += Time.deltaTime;
            // 10초가 지나면 타이머를 비활성화하고 jumpMax를 2로 설정합니다.
            if (timer >= cool)
            {
                GameManager.instance.isTimerActive = false;
                GameManager.instance.jumpMax = 2;
                timer = 0.0f; // 타이머 초기화
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.instance.isTimerActive = true;
            // OnCollisionEnter2D 이벤트가 발생하면 jumpMax를 4로 설정하고 타이머를 활성화합니다.
            GameManager.instance.jumpMax = 4;
            // 아이템을 파괴합니다.
            Destroy(gameObject);
        }
    }
}