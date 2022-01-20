using System.Collections;

// var rollsScore = new List<int>{ 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 0 }; // 50
// var rollsScore = new List<int>{ 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3, 7, 3 }; // 130
// var rollsScore = new List<int>{ 1, 0, 2, 3, 4, 6, 2, 5, 10, 0, 10, 0, 1, 1, 3, 3, 6, 3, 10, 10, 10 }; // 105
 var rollsScore = new List<int>{ 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10, 10 }; // 300
var framesScore = new SortedList();

var currentRoll = 1;
var spares = 0;
var strikes = 0;
var acc = 0; 

private bool IsLastFrame(int currentRoll) => currentRoll >= 19;
private bool IsLastRoll(int currentRoll) => currentRoll == rollsScore.Count();
private bool IsLastRollInFrame(int currentRoll) => currentRoll % 2 == 0;
private bool IsSpare(int currentScore, int previousScore) => currentScore + previousScore == 10 && previousScore != 10;
private bool IsStrike(int currentScore, int previousScore) => currentScore + previousScore == 10 && currentScore == 0;

foreach(var score in rollsScore)
{
    acc += score;
    if(!IsLastFrame(currentRoll))
    {
        if(IsLastRollInFrame(currentRoll))
        {
            if(IsSpare(score, rollsScore[currentRoll - 2]))
            {
                spares++;
            }
            else if(IsStrike(score, rollsScore[currentRoll - 2]))
            {
               
            }
            else 
            {
                Console.WriteLine($"1 - currentRoll={currentRoll} - acc={acc}");
                framesScore.Add(framesScore.Count, acc);
                if(strikes > 0) {
                    strikes--;
                    framesScore.Add(framesScore.Count, (acc - 10));
                }
                acc = 0;
            }
        }
        else
        {
            if(spares > 0)
            {
                spares--;
                Console.WriteLine($"2 - currentRoll={currentRoll} - acc={acc}");
                framesScore.Add(framesScore.Count, acc);
                acc = score;
            }

            if(score == 10)
            {
                strikes++;
            }
            
            if(strikes > 0 && (score != 10 || strikes == 3))
            {
                Console.WriteLine($"3 - currentRoll={currentRoll} - acc={acc}");
                framesScore.Add(framesScore.Count, acc);
                acc = (acc - 10);
                strikes--;
            }
        }
    }
    else
    {
        if(IsLastRoll(currentRoll))
        {
            Console.WriteLine($"4 - currentRoll={currentRoll} - acc={acc}");
            framesScore.Add(framesScore.Count, acc);
            acc = 0;
        }

        if(spares > 0)
        {
            spares--;
            Console.WriteLine($"5 - currentRoll={currentRoll} - acc={acc}");
            framesScore.Add(framesScore.Count, acc);
            acc = score;
        }

        if(strikes > 0)
        {
            Console.WriteLine($"3 - currentRoll={currentRoll} - acc={acc}");
            framesScore.Add(framesScore.Count, acc);
            acc = (acc - 10);
            strikes--;
        }
    }
    currentRoll++;
}

foreach(var s in framesScore)
{
    var entry = (DictionaryEntry)s;
    Console.WriteLine($"Frame {entry.Key} -> {entry.Value}");    
}

Console.WriteLine($"Total: {framesScore.Values.Cast<int>().Sum()}");