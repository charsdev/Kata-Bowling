using Game;
using NUnit.Framework;

public class EditMode
{
    private GameModel _gameModel;
    private GamePresenter _gamePresenter;

    [SetUp]
    public void Setup()
    {
        _gameModel = new GameModel();
    }

    [Test]
    public void GivenAScore_WhenIsFirstRoll_ReturnStrikeMark()
    {
        uint score = 10;
        uint rollIndex = 1;
        var mark = _gameModel.GetScoreMark(score, rollIndex);
        Assert.AreEqual("X", mark);
    }

    [Test]
    public void GivenAScore_WhenIsSecondRoll_ReturnSpareMark()
    {
        uint score = 10;
        uint rollIndex = 2;
        var mark = _gameModel.GetScoreMark(score, rollIndex);
        Assert.AreEqual("/", mark);
    }

    
}
