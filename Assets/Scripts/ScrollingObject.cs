using UnityEngine;

// 게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour {

    private void Update()
    {
        // 게임오버가 아니라면
        if (!GameManager.instance.isGameover)
        {
            // 게임 오브젝트를 왼쪽으로 일정 속도로 평행 이동하는 처리
            transform.Translate(Vector3.left * GameManager.instance.ScrollingSpeed * Time.deltaTime);
        }
    }
}