//using Game;
//using NUnit.Framework;

//public class EditMode
//{
//    private GameModel _gameModel;
//    private GamePresenter _gamePresenter;

//    [SetUp]
//    public void Setup()
//    {
//        _gameModel = new GameModel();
//    }

//    [Test]
//    public void GivenAScore_WhenIsFirstRoll_ReturnStrikeMark()
//    {
//        uint score = 10;
//        uint rollIndex = 1;
//        var mark = _gameModel.GetScoreMark(score, rollIndex);
//        Assert.AreEqual("X", mark);
//    }

//    [Test]
//    public void GivenAScore_WhenIsSecondRoll_ReturnSpareMark()
//    {
//        uint score = 10;
//        uint rollIndex = 2;
//        var mark = _gameModel.GetScoreMark(score, rollIndex);
//        Assert.AreEqual("/", mark);
//    }

//    [TestCase(1, 10, false, ExpectedResult = true)]
//    [TestCase(2, 10, false, ExpectedResult = false)]
//    [TestCase(1, 3, true, ExpectedResult = false)]
//    [TestCase(2, 3, false, ExpectedResult = false)]
//    [TestCase(3, 10, true, ExpectedResult = true)]
//    public bool CheckIfIsStrike(int turn, int fallPines, bool lastTurn)
//    {
//        _gameModel.IsLastTurn = lastTurn;
//        return _gameModel.IsStrike((uint)turn, (uint)fallPines);
//    }

//    [TestCase(10, ExpectedResult = false)]
//    [TestCase(5, ExpectedResult = false)]
//    [TestCase(3, ExpectedResult = false)]
//    [TestCase(1, ExpectedResult = false)]
//    [TestCase(0, ExpectedResult = true)]
//    public bool CheckIfIsGutter(int fallPines)
//    {
//        return _gameModel.IsGutter((uint)fallPines);
//    }


//    [TestCase(1, 10, 10, false, ExpectedResult = false)]
//    [TestCase(2, 10, 10 ,  false, ExpectedResult = true)]
//    [TestCase(2, 8, 8,  false, ExpectedResult = true)]
//    [TestCase(3, 9, 10,  false, ExpectedResult = false)]
//    [TestCase(3, 8, 8,  true, ExpectedResult = true)]
//    public bool CheckIfIsSpare(int turn, int fallPines, int leftPines, bool lastTurn)
//    {
//        _gameModel.LeftPines = (uint)leftPines;
//        _gameModel.IsLastTurn = lastTurn;
//        return _gameModel.IsSpare((uint)turn, (uint)fallPines);
//    }






//}
