

using Unity.VisualScripting;

public class Quizz
{
    public Questions[] Quizzes { get; set; }
}
public class Questions
{
    #region f/p
    public static bool RandomDone { get; set; } = false;
    public int _ID { get; set; } = 0;
    int index = 0;
    public string Question { get; set; }
    public string Answer { get; set; }
    public string[] BadAnswers { get; set; }
    public string Category { get; set; }
    public string Difficulty { get; set; }

    public string[] Answers 
    {
        get => MixAnswers(Answer);
    }
    #endregion

    #region methods
    #region test
    //public string[] MixAnswers(string goodAnswer)
    //{
    //    Random random = new Random();
    //    int _index = random.Next(0, BadAnswers.Length);
    //    string[] _temp = new string[BadAnswers.Length + 1];
    //    for (int i = 0; i < BadAnswers.Length+1; i++)
    //    {
    //        if (i == _index)
    //            _temp[i] = goodAnswer;
    //        else
    //        {
    //            if (i == BadAnswers.Length)
    //                _temp[i] = BadAnswers[_index];
    //            else
    //                _temp[i] = BadAnswers[i];
    //        }

    //    }
    //    return _temp ;
    //}
    #endregion

    public string[] MixAnswers(string answer)
    {
        //Random random = new Random();
        string[] answerArray = new string[BadAnswers.Length +1];
        if(RandomDone == false)
        {
            index = UnityEngine.Random.Range(0, answerArray.Length -1);
            RandomDone = true;
        }

        for (int i = 0; i < BadAnswers.Length; i++)
        {
            answerArray[i] = BadAnswers[i];
        }
        string _temp = answerArray[index];
        answerArray[index] = answer;
        answerArray[BadAnswers.Length] = _temp;
        return answerArray;
    }
    #endregion
}
