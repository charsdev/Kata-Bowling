using Game;
using NUnit.Framework;

public class EditMode
{
    private GameModel _gameModel;

    [SetUp]
    public void Setup()
    {
        _gameModel = new GameModel();
    }

    [TestCase(1, 10, ExpectedResult = "X")]
    [TestCase(5, 0, ExpectedResult = "-")]
    public string GivenAScore_WhenIsFirstRoll_ReturnStrikeOrGutterMark(int rollIndex, int score)
    {
        _gameModel.SaveResult(rollIndex, score);
        return _gameModel.GetScoreMark(rollIndex);
    }

    [Test]
    public void GivenAScore_ReturnSpareMark()
    {
        _gameModel.CleanPines(5);
        _gameModel.SaveResult(1, 5);
        Assert.AreEqual("/", _gameModel.GetScoreMark(1));
    }

    [TestCase(0, 10, ExpectedResult = true)]
    [TestCase(1, 10, ExpectedResult = true)]
    [TestCase(2, 3, ExpectedResult = false)]
    [TestCase(2, 8, ExpectedResult = false)]
    [TestCase(3, 10, ExpectedResult = true)]
    public bool CheckIfIsStrike(int turn, int fallPines)
    {
        _gameModel.SaveResult(turn, fallPines);
        return _gameModel.IsStrike(turn);
    }


    [TestCase(0, 10, ExpectedResult = false)]
    [TestCase(1, 10, ExpectedResult = false)]
    [TestCase(2, 3, ExpectedResult = false)]
    [TestCase(2, 0, ExpectedResult = true)]
    [TestCase(3, 0, ExpectedResult = true)]
    public bool CheckIfIsGutter(int turn, int fallPines)
    {
        _gameModel.SaveResult(turn, fallPines);
        return _gameModel.IsGutter(turn);
    }


    [TestCase(2, 3, ExpectedResult = false)]
    [TestCase(9, 1, ExpectedResult = true)]
    [TestCase(0, 10, ExpectedResult = true)]
    [TestCase(5, 5, ExpectedResult = true)]
    public bool CheckIfIsSpare(int fallPines, int leftPines)
    {
        _gameModel.CleanPines(leftPines);
        _gameModel.SaveResult(1, fallPines);
        return _gameModel.IsSpare(1);
    }

}
