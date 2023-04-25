



// A(6) 7 8 9 10 j(11) q(12) k(13)
//클로버(c), 다이아(d), 하트(h) 스페이드(s)
//                0      1      2       3     4      5      6       7
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

String[] dec = {"06c", "07c", "08c", "09c", "10c", "11c", "12c", "13c",
                "06d", "07d", "08d", "09d", "10d", "11d", "12d", "13d",
                "06h", "07h", "08h", "09h", "10h", "11h", "12h", "13h",
                "06s", "07s", "08s", "09s", "10s", "11s", "12s", "13s"};

List<string> mycard = new List<string>();
List<int> mycard_onlynum = new List<int>();
List<string> mycard_onlyshape = new List<string>();
List<int> randnum_list=new List<int>();

Random rand = new Random();

int paircount = 0;

bool isflush = false;
bool ismount = false;
bool isstraight = false;


for (int i = 0; i < 5; i++)
{
    int randnnum = rand.Next(0, 32);

    if (!randnum_list.Contains(randnnum))
    {
        randnum_list.Add(randnnum);
        i++;

    }
}




mycard.Add(dec[randnum_list[0]]); // 11d
mycard.Add(dec[randnum_list[1]]); // 11d
mycard.Add(dec[randnum_list[2]]); // 11d
mycard.Add(dec[randnum_list[3]]); // 11d
mycard.Add(dec[randnum_list[4]]); // 11d

Console.WriteLine(mycard[0] + "" + mycard[1] +"" +mycard[2] +""+ mycard[3] + ""+mycard[4]);


//문자열 및 숫자 자르고 입력 순차적으로 값이 들어감
for (int i = 0; i < mycard.Count; i++)
{
    mycard_onlynum.Add(Convert.ToInt32(mycard[i].Substring(0, 2)));
    mycard_onlyshape.Add(mycard[i].Substring(2, 1));
}

mycard_onlynum.Sort();
mycard_onlyshape.Sort();

//출력=========================================
    for (int i = 0; i < mycard.Count; i++)
{
    Console.WriteLine(mycard_onlynum[i] + " " +mycard_onlyshape[i]);

}



// 첫번째 마지막 비교
//mycard_onlyshape[i]

//Flush==================================================================================
    if (mycard_onlyshape[0] == mycard_onlyshape[mycard_onlyshape.Count-1])
        isflush= true;



//Mount============================================================================================
if ((mycard_onlynum[0] == 6) && (mycard_onlynum[1] == 10) && (mycard_onlynum[2] == 11) && (mycard_onlynum[3] == 12) && (mycard_onlynum[4] == 13))
        ismount=true;




//Straight=======================================================================================
for (int i = 0; i < mycard_onlynum.Count-1; i++)
{

    if (mycard_onlynum[i + 1] - mycard_onlynum[i] == 1)
    {
        isstraight = true;
    }
    else
    {
        
        break;

    }
}

//Pair==============================================================
for (int i = 0; i < mycard_onlynum.Count-1; i++)
{
    for (int j = i+1; j < mycard_onlynum.Count; j++)
    {
        if (mycard_onlynum[i] == mycard_onlynum[j])
        {
            paircount++;
        }

    }

}




if (isflush && ismount)
{
    Console.WriteLine("로티플");
}
else if(isflush && isstraight)
{
    Console.WriteLine("스트레이트플러쉬");
}
else if(paircount==6)
{
    Console.WriteLine("포카드");
}
else if (paircount==4)
{
    Console.WriteLine("풀하우스");
}
else if(isflush)
{
    Console.WriteLine("플러쉬");
}
else if(ismount)
{
    Console.WriteLine("마운트");
}
else if (paircount == 1)
        {
            Console.WriteLine("원페어");
        }
else if (paircount == 2)
        {
           Console.WriteLine("투페어");
        }
else if (paircount == 3)
        {
            Console.WriteLine("트리플");
        }


//return 전체 반복문을 종료
//break 존재하는 현 반복문만 종료

//if ((mycard_onlynum[0]== 6) && mycard_onlynum[1]==10)
//{
//    ismount = true;
//    Console.WriteLine("mount");
//
//}
//else
//{
//    Console.WriteLine("no mount");
//}







//문자열 자르기
//Console.WriteLine(mycard[0].Substring(0, 2));
//
//int a = Convert.ToInt32(mycard[0].Substring(0, 2));
//int b = Convert.ToInt32(mycard[1].Substring(0, 2));
//int c = Convert.ToInt32(mycard[2].Substring(0, 2));
//int d = Convert.ToInt32(mycard[2].Substring(0, 2));
