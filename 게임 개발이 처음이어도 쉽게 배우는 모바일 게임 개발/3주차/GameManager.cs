using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//�̱���

    public GameObject normalCat;
    public GameObject FatCat;
    public GameObject pirateCat;

    public GameObject RetryButton;

    public RectTransform levelFront;

    public Text levelTxt;

    int level = 0;
    int score = 0;

    private void Awake()
    {
        if (Instance == null) //Singleton
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);

        //Lv.1 : 20% Ȯ���� ����̸� �� �����Ѵ�.
        if(level == 1)
        {
            int p = Random.Range(0, 10); //10���� ����� ���� ����� �Լ�
            if (p < 2) Instantiate(normalCat); //10������ ��쿡�� 2������ ��쿡�� �����ϹǷ� 20% Ȯ���� �ȴ�. (0,1)
            Instantiate(normalCat);
        }
        //Lv.2 : 50% Ȯ���� ����̸� �� �����Ѵ�.
        if(level == 2)
        {
            int p = Random.Range(0, 10); //10���� ����� ���� ����� �Լ�
            if (p < 5) Instantiate(normalCat); //10������ ��쿡�� 5������ ��쿡�� �����ϹǷ� 50% Ȯ���� �ȴ�. (0,1,2,3,4)
            Instantiate(normalCat);
        }
        // Lv.3 �׶��� ����̸� �����Ѵ�.
        if (level == 3) //else������ �ϸ� lv.0�϶� �� ������ �ɸ��� ��.
        {
            Instantiate(FatCat);
        }
        else if (level == 4)
        {
            Instantiate(pirateCat);
        }
    }
    public void GameOver()
    {

        RetryButton.SetActive(true);
        Time.timeScale = 0f;
    }
    public void AddScroe()
    {
        score++; // == score += 1;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1f, 1f);
        //lv�� 12�̶�� �������� ��, �̹� 5�� �����ŭ�� 10�� text Score�� ǥ�ð� �ǰ�,
        //������ 2���� �� 0.4��ŭ�� �������ٿ� ǥ�����ָ� �Ǳ⶧���� score(12) - level(2) * 5(������ ���)�� �ȴ�.
        // /5.0f�� �����ִ� ������ (score-level *5)���� int���̱� ������ f �ڷ����� �̿��� �Ҽ���(�Ǽ�)���� ������ �ϴ� ��.
    }
}
