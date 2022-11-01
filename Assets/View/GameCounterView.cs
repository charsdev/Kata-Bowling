using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCounterView : MonoBehaviour
{
    private GameCounterPresenter _presenter;

    //[SerializeField] int _totalThrows;
    [SerializeField] Transform _bowlThrowMarkerContent;
    [SerializeField] BowlThrowMarkerView _bowlThrowMarkerPrefab;

    void Start()
    {
        List<BowlThrowMarkerView> arrayMarkers = new List<BowlThrowMarkerView>();
        for (int i = 0; i < 10; i++)
        {
            arrayMarkers .Add(Instantiate(_bowlThrowMarkerPrefab, _bowlThrowMarkerContent));
        }
        _presenter = new GameCounterPresenter(this, arrayMarkers);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetThrow(10);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GetThrow(2);
        }
    }

    public void GetThrow(int pinesFalled)
    {
        _presenter.OnTrhowedPine(pinesFalled);
    }

}
