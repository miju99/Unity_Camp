using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += Vector3.up * 0.5f; //y값만 올라가는 로직(강아지가 위로 밥을 던짐)
        if (transform.position.y > 27.0f)
        {
            Destroy(gameObject); // y값이 화면을 나가면 food가 사라짐
        }
    }
}
