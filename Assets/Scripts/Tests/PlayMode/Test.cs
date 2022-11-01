using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Game.Presenter;
using Game.Model;
using Game.View;

public class Test
{

    GameUIView gameUIView;
    GameModel gameModel;
    GameUIPresenter gamePresenter;
    // A Test behaves as an ordinary method
    [Test]
    public void TestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
