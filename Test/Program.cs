using System;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

String[] dec = {"1a", "2a", "3a", "4a", "5a", "6a", "7a", "8a", "9a", "10a",
                "1b", "2b", "3b", "4b", "5b", "6b", "7b", "8b", "9b", "10b" };


List<string> mycard = new List<string>();
List<int> mycard_onlynum = new List<int>();
List<string> mycard_onlyshape = new List<string>();
List<int> randnum_list = new List<int>();

Random random = new Random();

//플레이어  4명
//2장씩 겹치지 않고 분배

for (int i = 0; i < 2; i++)
{

    int a = random.Next(0, 20);

    if (!randnum_list.Contains(a))
    {
        randnum_list.Add(a);
    }


    Console.WriteLine(randnum_list);



}


for (int i = 0; i < mycard.Count; i++)
{
    mycard_onlynum.Add(Convert.ToInt32(mycard[i].Substring(0, 1)));
    mycard_onlyshape.Add(mycard[i].Substring(1, 1));

}


mycard_onlynum.Sort();
mycard_onlyshape.Sort();


for (int i = 0; i < mycard.Count; i++)
{
    Console.WriteLine(mycard_onlynum + "" + mycard_onlyshape);

}






//38광땡

//13광떙 18광떙

//94 재경기

//1~10떙

//