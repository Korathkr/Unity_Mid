using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class ItemSpawner : MonoBehaviour {
    public GameObject ItemPrefab; // 생성할 아이템의 원본 프리팹
    public Transform spawnPoint; // 아이템을 생성할 위치 (여기서는 Transform으로 변경)

    public float spawnInterval = 30.0f; // 아이템 생성 간격 (초)
    private float timer = 0.0f;

    void Update()
    {
        // 시간을 누적
        timer += Time.deltaTime;

        // 일정 간격마다 아이템 생성
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0.0f; // 타이머 초기화
        }
    }
    void SpawnItem()
    {
        // 아이템을 생성할 위치로부터 오프셋을 더해 월드 좌표를 얻음
        Vector3 spawnPosition = spawnPoint.transform.TransformPoint(spawnPoint.position.x, spawnPoint.position.y +3.0f, spawnPoint.position.z);

        // 아이템 생성 
        Instantiate(ItemPrefab, spawnPosition, Quaternion.identity);
    }
}