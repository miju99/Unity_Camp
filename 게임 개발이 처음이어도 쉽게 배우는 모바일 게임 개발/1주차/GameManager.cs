using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI; //UI와 관련된 패키지를 사용하겠다.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton을 만들기 위한 키워드(public static) + 클래스 네임,나 자신(GameManager) + 변수 이름(instance)
                                       //Singleton : 나 하나밖에 없다, 이 프로젝트의 GameManager이라고 하는 객체는 나 하나밖에 없으며, 여러 스크립트에서 접근이 가능하게 만들어주는 기능.
    public GameObject rain;
    public GameObject EndPanel;

    public Text totalScoreTxt; //텍스트 타입의 내용을 가지고 오겠다. (유니티의 Inspector 창에 만들어짐)
    public Text timeTxt; //유니티의 Inspector 창의 컴포넌트 생성

    int totalScore; //총 점수를 더해줄 변수

    float totalTime = 30.0f; //타이머 기능을 위한 전체 시간값

    private void Awake()
    {
        Instance = this; //this 키워드를 통해 나 자신의 데이터를 넣어준다.
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);//함수를 반복적으로 실행해주는 함수(생성할 오브젝트/몇 초 이후에 생성할지/얼마나 자주 생성할지(주기)
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)//totaltime이 0보다 클 때(게임이 정상적으로 실행되어야 할 때)
        {
            totalTime -= Time.deltaTime;//30의 시간에 흘러간 시간만큼 빼는 로직 (기기마다 프레임 값이 달라서(시간을 계산해주는 연산이 프레임이 높으면 많이 계산되기 때문에) 프레임대비로 맞춰준 값이 deltaTime
        }
        else
        {
            totalTime = 0f; //-값이 되어 오류가 나는 상황을 방지.
            EndPanel.SetActive(true); //SetActive == 활성화해주겠다. Panel이 보여야하니까 true값을 넣음.
            Time.timeScale = 0f; //Time의 크기를 0으로 만든다는 뜻 == 첫번째 프레임과 그 다음 프레임의 시간의 차이가 없어진다 == 게임 시간이 멈추게 된다.
        }
        timeTxt.text = totalTime.ToString("N2"); //text컴포넌트 안의 text에 totalTime이라고하는 숫자 데이터를 string으로 함수를 호출해서 문자열로 바꿔준 다음 넣어주는 과정 (N2는 소수점 둘째자리까지만 나오게 하는 명령어)
    }

    void MakeRain() //반복적으로 실행되는 로직을 하나로 묶어 놓은 단위 : 함수
    {
        Instantiate(rain); //게임오브젝틀르 생성하는 함수(생성하고 싶은 게임 오브젝트)
    }

    public void AddScore(int score)//점수를 올려주는 함수 int score(매개 변수:이 함수를 다른 곳에서 호출했을 때 데이터를 넘겨주기 위한 공간)
    { 
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString(); //int자료형인 totalScore를 string 자료형인 text로 가져오기 위해 .ToString()함수를 이용함.(int -> String)
    }
}
