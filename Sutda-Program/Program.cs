



                //1    2   3    4    5    6    7    8    9   10
string[] deck = {"a", "b","c", "d", "e", "f", "g", "h", "i","j",
                 "A", "B","C", "D", "E", "F", "G", "H", "I", "J"};


Dictionary<string, int> jokbo = new Dictionary<string, int>()
{
    //dictionary에 10땡 까지 추가하기
    { "aA" , 200 },{ "bB" , 220 },{ "cC" , 240 },{ "dD" , 260 },{ "eE" , 280 },{ "fF" , 300 },{ "gG" , 320 },{ "hH" , 340 },{ "iI" , 360 },{ "jJ" , 380 },


};


List<string> computer1 = new List<string>();
List<string> player0 = new List<string>();


player0.Add(deck[0]);
player0.Add(deck[1]);

computer1.Add(deck[0]);
computer1.Add(deck[1]);



string player0_value=player0[0]+player0[1];
Console.WriteLine(player0_value);

Console.WriteLine(jokbo[player0_value]);

