using NUnit.Framework;
using Game.Model;

public class EditMode
{
    private GameModel _gameModel;
    [SetUp]
    public void Setup()
    {
        _gameModel = new GameModel();
    }

    [TestCase(1, ExpectedResult = 1)]
    [TestCase(20, ExpectedResult = 20)]
    public int GivenAnIntPins_WhenRoll_ReturnScore(int pins)
    {
        _gameModel.Roll(pins);
        return _gameModel.HandleScore();
    }

    [Test]
    public void GiventAnIntOfPins_WhenRoll_CheckIfSpare()
    {
        _gameModel.Roll(5);
        _gameModel.Roll(5);
        _gameModel.Roll(3);

        for (int frame = 0, frameIndex = 0; frame < 21; frame++)
        {
            Assert.AreEqual(true, _gameModel.IsSpare(frameIndex));
        }
    }
}
