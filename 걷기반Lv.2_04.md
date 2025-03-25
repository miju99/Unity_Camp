## Unity 퀘스트 걷기반
### LV.2 제어문 - 04. 숫자..인가요?
>       Console.WriteLine("첫번째 수를 입력해 주세요.");
>       
>       string input = Console.ReadLine();
>       Console.WriteLine("첫번째로 입력받은 데이터는 " + input + "입니다.\n");
>       
>       Console.WriteLine("두번재 수를 입력해 주세요.");
>       
>       string input2 = Console.ReadLine();
>       Console.WriteLine("두번째로 입력받은 데이터는 " + input2 + "입니다.\n");
>       
>       float num;
>       bool word = Single.TryParse(input, out num);
>       float num2;
>       bool word2 = Single.TryParse(input2, out num2);
> 
#### 숫자를 두번 입력받아서 두번 다 숫자인지 확인
> * 프로그램을 처음 시작하면 “첫번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
> * “두번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
>> * 첫번째 수와 두번째 수 모두 숫자 라면 - “두 데이터는 모두 숫자입니다.”
>> * 모두 숫자가 아니라면 - “숫자가 아닙니다.”
>
>       if (word&&word2)
>       {
>           Console.WriteLine("두 데이터는 모두 숫자입니다.");
>       }
>       else
>       {
>           Console.WriteLine("숫자가 아닙니다.");
>       }

#### 숫자를 두번 입력받아서 두번 다 숫자인지 하나만 숫자인지 확인
> * 프로그램을 처음 시작하면 “첫번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
> * “두번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
>> * 첫번째 수와 두번째 수 모두 숫자 라면 - “두 데이터는 모두 숫자입니다.”
>> * 둘 중 하나만 숫자라면 - “하나의 데이터만 숫자입니다.”
>> * 숫자가 하나도 없다면 - “두 데이터 모두 숫자가 아닙니다.”
>
>       if (word&&word2)
>       {
>           Console.WriteLine("두 데이터는 모두 숫자입니다.");
>       }
>       else if(word||word2)
>       {
>           Console.WriteLine("하나만 데이터 숫자입니다.");
>       }
>       else
>       {
>           Console.WriteLine("두 데이터 모두 숫자가 아닙니다.");
>       }

#### 숫자를 두번 입력받아서 두 수를 비교
> * 프로그램을 처음 시작하면 “첫번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
> * “두번째 수를 입력해 주세요.” 메시지 출력
> * 메시지를 입력하고 Enter
>> * 둘 중 하나라도 숫자가 아니라면 - “두 개의 숫자를 입력해주세요.”
>> * 첫번째 수와 두번째 수 모두 숫자 라면
>>> * 첫번째 수와 두번째 수가 같다면 - ”xx 와(과) xx 은(는) 같습니다.”
>>> * 첫번째 수와 두번째 수가 다르다면
>>>> * 첫번째 수가 더 크다 - “xx 은(는) xx 보다 큽니다.”
>>>> * 첫번째 수가 작다 - “xx 은(는) xx 보다 작습니다.”
>
>       if (word || word2)
>       {
>           if (word && word2)
>           {
>               if (num != num2)
>               {
>                   if (num > num2)
>                   {
>                       Console.WriteLine(num + "은(는) " + num2 + "보다 큽니다.");
>                   }
>                   else if(num< num2)
>                   {
>                       Console.WriteLine(num + "은(는)" + num2 + "보다 작습니다.");
>                   }
>               }
>               else if (word == word2)
>               {
>                   Console.WriteLine(input + "와(과) " + input2 + "은(는) 같습니다.");
>               }
>           }
>           else
>           {
>               Console.WriteLine("두 개의 숫자를 입력해주세요.");
>           }
>       }
>       else
>       {
>           Console.WriteLine("두 개의 숫자를 입력해주세요.");
>       }
>
> 수정
> 
>       if(word && word2)
>       {
>           if (num == num2)
>           {
>               Console.WriteLine(num + "와(과) " + num2 + "은(는) 같습니다.");
>           }
>           else if (num > num2)
>           {
>               Console.WriteLine(num + "은(는)" + num2 + "은(는)보다 큽니다.");
>           }
>           else if (num < num2)
>           {
>               Console.WriteLine(num + "은(는)" + num2 + "보다 작습니다.");
>           }
>       }
>       else
>       {
>           Console.WriteLine("두 개의 숫자를 입력해주세요.");
>       }
