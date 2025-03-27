using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text 선언하기 위해 필요한 네임스페이스

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//싱글톤

    public GameObject square; //prefab을 생성하기 위해 변수에 넣음.
    public GameObject EndPanel;

    public Text timeTxt; //Inspector 컴포넌트에 time txt를 추가하기 위한 변수 생성
    public Text NowScore; //TimeTxt(점수)를 NowScore에 넣을 수 있도록 변수 생성
    public Text BestScore;
    public Animator anim;

    float time = 0.0f; //시간을 담는 변수 초기화

    string key = "BestScore"; //BestScore라고 하는 자료가 Ket라는 변수에 들어간 것. ("BestScore"라 일일이 적다 오타, 등의 이유로 오류가 나는 것을 방지하기 위해 변수로 입력)

    bool isPlay = true; //미세한 차이의 값이 달라지는 현상을 방지하기 위해 bool 자료형의 변수 생성

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f; //게임이 다시 시작되면 시간이 흐르게 함.
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay) //is paly값이 true일때만 실행된다. 좀 더 정확한 값을 도출하기 위함
        {
            time += Time.deltaTime;//시간이 (0초에서) 점점 더해지는 로직
            timeTxt.text = time.ToString("N2"); //float 자료형으로 되어있는 time을 text에 넣기 위해 string으로 바꿈
        }
    }
    
    void MakeSquare()//prefab Square를 반복적으로 생성하기 위한 함수
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false; //게임 오버가 되면 isPlay의 값이 false가 된다.
        anim.SetBool("isDie",true);//애니메이션이 실행되게끔 하는 로직
        Invoke("TimeStop", 0.5f); //GameOver가 되고 0.5f시간 후 TimeStop이 실행되도록 하는 함수(애니메이션 실행을 위한 지연)
        NowScore.text = time.ToString("N2"); //time (점수)를 NowScore에 넣어주는 함수

        //최고 점수가 있다면
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                //최고 점수< 현재 점수 -> 현재 점수를 최고 점수에 저장한다.
                PlayerPrefs.SetFloat(key,time);
                BestScore.text = time.ToString("N2");
            }
            else
            {
                BestScore.text = best.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            BestScore.text = time.ToString("N2");
        }
            //최고 점수가 없다면
            //현재 점수를 저장한다.
            EndPanel.SetActive(true); //EndPanel을 켜주는 기능
    }

    void TimeStop() //애니메이션이 실행되기도 전에 게임이 멈춰버리기 때문에 애니메이션 실행 시간을 확보해주기 위한 함수
    {
        Time.timeScale = 0.0f; //게임을 멈춰주는 기능
    }

}
