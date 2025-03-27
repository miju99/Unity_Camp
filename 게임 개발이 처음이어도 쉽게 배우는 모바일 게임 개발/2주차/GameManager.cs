using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text �����ϱ� ���� �ʿ��� ���ӽ����̽�

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//�̱���

    public GameObject square; //prefab�� �����ϱ� ���� ������ ����.
    public GameObject EndPanel;

    public Text timeTxt; //Inspector ������Ʈ�� time txt�� �߰��ϱ� ���� ���� ����
    public Text NowScore; //TimeTxt(����)�� NowScore�� ���� �� �ֵ��� ���� ����
    public Text BestScore;
    public Animator anim;

    float time = 0.0f; //�ð��� ��� ���� �ʱ�ȭ

    string key = "BestScore"; //BestScore��� �ϴ� �ڷᰡ Ket��� ������ �� ��. ("BestScore"�� ������ ���� ��Ÿ, ���� ������ ������ ���� ���� �����ϱ� ���� ������ �Է�)

    bool isPlay = true; //�̼��� ������ ���� �޶����� ������ �����ϱ� ���� bool �ڷ����� ���� ����

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
        Time.timeScale = 1.0f; //������ �ٽ� ���۵Ǹ� �ð��� �帣�� ��.
        InvokeRepeating("MakeSquare", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay) //is paly���� true�϶��� ����ȴ�. �� �� ��Ȯ�� ���� �����ϱ� ����
        {
            time += Time.deltaTime;//�ð��� (0�ʿ���) ���� �������� ����
            timeTxt.text = time.ToString("N2"); //float �ڷ������� �Ǿ��ִ� time�� text�� �ֱ� ���� string���� �ٲ�
        }
    }
    
    void MakeSquare()//prefab Square�� �ݺ������� �����ϱ� ���� �Լ�
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false; //���� ������ �Ǹ� isPlay�� ���� false�� �ȴ�.
        anim.SetBool("isDie",true);//�ִϸ��̼��� ����ǰԲ� �ϴ� ����
        Invoke("TimeStop", 0.5f); //GameOver�� �ǰ� 0.5f�ð� �� TimeStop�� ����ǵ��� �ϴ� �Լ�(�ִϸ��̼� ������ ���� ����)
        NowScore.text = time.ToString("N2"); //time (����)�� NowScore�� �־��ִ� �Լ�

        //�ְ� ������ �ִٸ�
        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                //�ְ� ����< ���� ���� -> ���� ������ �ְ� ������ �����Ѵ�.
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
            //�ְ� ������ ���ٸ�
            //���� ������ �����Ѵ�.
            EndPanel.SetActive(true); //EndPanel�� ���ִ� ���
    }

    void TimeStop() //�ִϸ��̼��� ����Ǳ⵵ ���� ������ ��������� ������ �ִϸ��̼� ���� �ð��� Ȯ�����ֱ� ���� �Լ�
    {
        Time.timeScale = 0.0f; //������ �����ִ� ���
    }

}
