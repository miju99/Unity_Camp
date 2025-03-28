using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;//싱글톤

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

        //Lv.1 : 20% 확률로 고양이를 더 생성한다.
        if(level == 1)
        {
            int p = Random.Range(0, 10); //10가지 경우의 수를 만드는 함수
            if (p < 2) Instantiate(normalCat); //10가지의 경우에서 2가지의 경우에만 생성하므로 20% 확률이 된다. (0,1)
            Instantiate(normalCat);
        }
        //Lv.2 : 50% 확률로 고양이를 더 생성한다.
        if(level == 2)
        {
            int p = Random.Range(0, 10); //10가지 경우의 수를 만드는 함수
            if (p < 5) Instantiate(normalCat); //10가지의 경우에서 5가지의 경우에만 생성하므로 50% 확률이 된다. (0,1,2,3,4)
            Instantiate(normalCat);
        }
        // Lv.3 뚱뚱한 고양이를 생성한다.
        if (level == 3) //else문으로 하면 lv.0일때 이 조건이 걸리게 됨.
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
        //lv이 12이라고 가정헀을 때, 이미 5의 배수만큼인 10은 text Score로 표시가 되고,
        //나머지 2레벨 즉 0.4만큼만 게이지바에 표시해주면 되기때문에 score(12) - level(2) * 5(나눠준 배수)가 된다.
        // /5.0f로 나눠주는 이유는 (score-level *5)값이 int값이기 때문에 f 자료형을 이용해 소수점(실수)으로 나오게 하는 것.
    }
}
