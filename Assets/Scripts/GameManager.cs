using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public bool isGameover = false; // 게임 오버 상태
    public Text scoreText; // 점수를 출력할 UI 텍스트
    public Text LifeText; // 목숨
    public Text ShieldText; // 쉴드
    public Text CoinText; // 코인
    public GameObject gameoverUI; // 게임 오버시 활성화 할 UI 게임 오브젝트
    public int jumpMax; // 최대 점프 수
    public bool isTimerActive = false; // 타이머
    public float ScrollingSpeed = 10.0f;

    public int coin = 0; // 코인 점수
    private int score = 0; // 게임 점수
    public int life = 3; // 목숨
    public int shield = 0; // 쉴드

    // 게임 시작과 동시에 싱글톤을 구성
    void Awake() {
        jumpMax = 2;
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update() {
        // 게임 오버 상태에서 게임을 재시작할 수 있게 하는 처리
        if(isGameover && Input.GetMouseButtonDown(0))
        {
            // 게임오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        ShieldText.gameObject.SetActive(true);
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore) {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            // 점수를 증가
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }

    // 목숨을 증가시키는 메서드
    public void AddLife(int addLife)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            if (life < 3)
            {
                // 목숨을 증가
                life += addLife;
                LifeText.text = "Life : " + life;
            }
        }
    }

    // 쉴드를 증가시키는 메서드
    public void AddShield(int addShield)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            if (shield < 3)
            {
                // 쉴드 증가
                shield += addShield;
                ShieldText.text = "Shield : " + shield;
            }
        }
    }

    // 쉴드를 감소시키는 메서드
    public void SubShield(int subShield)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            // 점수를 증가
            shield -= subShield;
            ShieldText.text = "Shield : " + shield;
        }
    }

    // 코인 증가시키는 메서드
    public void AddCoin(int addCoin)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            if (coin >= 100)
            {
                coin = 0;
                CoinText.text = "Coin : " + coin;
                scoreText.text = "Score : " + score;
            }
            // 점수를 증가
            coin += addCoin;
            score += addCoin;
            CoinText.text = "Coin : " + coin;
            scoreText.text = "Score : " + score;
        }
    }

    // 목숨을 감소시키는 메서드
    public void SubLife(int subLife)
    {
        // 게임오버가 아니라면
        if (!isGameover)
        {
            // 점수를 증가
            life -= subLife;
            LifeText.text = "Life : " + life;
        }
    }

  

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead() {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}