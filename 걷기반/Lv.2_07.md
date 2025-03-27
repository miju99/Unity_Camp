## Unity 퀘스트 걷기반
### LV.2 제어문 - 07. 이름 찾기!
#### 이름 입력하기
이름을 입력하여 3글자 이상 10글자 이하의 이름을 입력할 수 있는 프로그램을 작성합니다.
> * 최초 메시지 출력 - “이름을 입력해주세요. (3~10글자)”
> * 이름이 3글자 미만, 10글자 초과라면 - “이름을 확인해주세요.”
> * 올바르게 입력했다면  - “안녕하세요! 제 이름은 xxx 입니다.”
> * 문자열의 .Length 기능을 이용하면 현재 문자열이 몇글자인지 알 수 있습니다.
> * 
>        string myStr = "test";
>        int length = myStr.Length;
>        
>        결과 : length - 4

>        Console.WriteLine("이름을 입력해주세요. (3~10글자)");
>        
>        string input  = Console.ReadLine();
>        
>        int length = input.Length;
>        
>        if (3 <= length&& length<10)
>        {
>            Console.WriteLine("안녕하세요! 제 이름은 " + input + "입니다.");
>        }
>        else
>        {
>            Console.WriteLine("이름을 확인해주세요.");
>        }

#### 조건에 맞을때까지 이름 입력
1번의 프로그램을 작성하면 3~10글자의 이름을 입력하지 않았을때 이름을 확인해주세요. 메시지 이후 프로그램이 종료됩니다.<br>
이름을 올바르게 입력할때까지 실행되도록 적용해보세요.
> * 반복문과 bool 을 이용하여 만들 수 있습니다.
>
> 힌트 코드를 조금 참고했다. do while문을 활용하는 데 미숙했다.
> 
>        bool Check;
>        
>        do
>        {
>            Console.WriteLine("이름을 입력해 주세요. (3~10글자)");
>            string input = Console.ReadLine();
>            int length = input.Length;
>        
>            if (3 <= length && length <= 10)
>            {
>                Console.WriteLine("안녕하세요! 제 이름은 " + input + "입니다.");
>            }
>            else
>            {
>                Console.WriteLine("이름을 확인해주세요.");
>            }
>            Check = input.Length >=3 && input.Length <= 10;
>        }
>        while (!Check); //논리 부정 연산자 : 참을 거짓으로, 거짓을 참으로 바꾸는 연산자

#### 반복시 기존 내용 지우기
2번의 프로그램을 작성하면 매번 새로운 텍스트가 생기게 됩니다.<br>
Console.Clear(); 기능을 활용하면 기존에 Console 에 표시되던 메시지를 지울 수 있습니다.

>        bool Check;
>        
>        do
>        {
>            Console.WriteLine("이름을 입력해 주세요. (3~10글자)");
>            string input = Console.ReadLine();
>            int length = input.Length;
>            Console.Clear();
>        
>            if (3 <= length && length <= 10)
>            {
>                Console.WriteLine("안녕하세요! 제 이름은 " + input + "입니다.");
>            }
>            else
>            {
>                Console.WriteLine("이름을 확인해주세요.");
>            }
>            Check = input.Length >= 3 && input.Length <= 10;
>        }
>        while (!Check);
