using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI; //UI�� ���õ� ��Ű���� ����ϰڴ�.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//Singleton�� ����� ���� Ű����(public static) + Ŭ���� ����,�� �ڽ�(GameManager) + ���� �̸�(instance)
                                       //Singleton : �� �ϳ��ۿ� ����, �� ������Ʈ�� GameManager�̶�� �ϴ� ��ü�� �� �ϳ��ۿ� ������, ���� ��ũ��Ʈ���� ������ �����ϰ� ������ִ� ���.
    public GameObject rain;
    public GameObject EndPanel;

    public Text totalScoreTxt; //�ؽ�Ʈ Ÿ���� ������ ������ ���ڴ�. (����Ƽ�� Inspector â�� �������)
    public Text timeTxt; //����Ƽ�� Inspector â�� ������Ʈ ����

    int totalScore; //�� ������ ������ ����

    float totalTime = 30.0f; //Ÿ�̸� ����� ���� ��ü �ð���

    private void Awake()
    {
        Instance = this; //this Ű���带 ���� �� �ڽ��� �����͸� �־��ش�.
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 1f);//�Լ��� �ݺ������� �������ִ� �Լ�(������ ������Ʈ/�� �� ���Ŀ� ��������/�󸶳� ���� ��������(�ֱ�)
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0f)//totaltime�� 0���� Ŭ ��(������ ���������� ����Ǿ�� �� ��)
        {
            totalTime -= Time.deltaTime;//30�� �ð��� �귯�� �ð���ŭ ���� ���� (��⸶�� ������ ���� �޶�(�ð��� ������ִ� ������ �������� ������ ���� ���Ǳ� ������) �����Ӵ��� ������ ���� deltaTime
        }
        else
        {
            totalTime = 0f; //-���� �Ǿ� ������ ���� ��Ȳ�� ����.
            EndPanel.SetActive(true); //SetActive == Ȱ��ȭ���ְڴ�. Panel�� �������ϴϱ� true���� ����.
            Time.timeScale = 0f; //Time�� ũ�⸦ 0���� ����ٴ� �� == ù��° �����Ӱ� �� ���� �������� �ð��� ���̰� �������� == ���� �ð��� ���߰� �ȴ�.
        }
        timeTxt.text = totalTime.ToString("N2"); //text������Ʈ ���� text�� totalTime�̶���ϴ� ���� �����͸� string���� �Լ��� ȣ���ؼ� ���ڿ��� �ٲ��� ���� �־��ִ� ���� (N2�� �Ҽ��� ��°�ڸ������� ������ �ϴ� ��ɾ�)
    }

    void MakeRain() //�ݺ������� ����Ǵ� ������ �ϳ��� ���� ���� ���� : �Լ�
    {
        Instantiate(rain); //���ӿ�����Ʋ�� �����ϴ� �Լ�(�����ϰ� ���� ���� ������Ʈ)
    }

    public void AddScore(int score)//������ �÷��ִ� �Լ� int score(�Ű� ����:�� �Լ��� �ٸ� ������ ȣ������ �� �����͸� �Ѱ��ֱ� ���� ����)
    { 
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString(); //int�ڷ����� totalScore�� string �ڷ����� text�� �������� ���� .ToString()�Լ��� �̿���.(int -> String)
    }
}
