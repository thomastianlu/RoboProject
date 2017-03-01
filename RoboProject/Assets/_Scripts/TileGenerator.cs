using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TileGenerator : MonoBehaviour {

    [SerializeField]
    private TileGeneratorDetector _topTileGenerator;
    private float _topTilePositionTopYLimit;
    private float _topTilePositionBottomYLimit;
    [SerializeField]
    private TileGeneratorDetector _bottomTileGenerator;
    private float _bottomTilePositionBottomYLimit;
    private float _bottomTilePositionMiddleYLimit;

    [SerializeField]
    private GameObject _tilePrefab;
    [SerializeField]
    private int _tilePoolAmount;
    [SerializeField]
    private List<GameObject> _tiles = new List<GameObject>();

    [SerializeField]
    private Transform _inactivePoolParent;

    // Use this for initialization
    void Start () {
        InitializeObjectPool();
        InitializeTileGeneratorPositions();
    }

    // Update is called once per frame
    void Update()
    {
        ManageTileGeneration();
    }

    void InitializeTileGeneratorPositions()
    {
        _topTilePositionTopYLimit = _topTileGenerator.transform.position.y;
        _bottomTilePositionBottomYLimit = _bottomTileGenerator.transform.position.y;
        _topTilePositionBottomYLimit = _topTilePositionTopYLimit - 2;
        _bottomTilePositionMiddleYLimit = _bottomTilePositionBottomYLimit + 2;
    }

    void InitializeObjectPool()
    {
        for (int i = 0; i < _tilePoolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(_tilePrefab);
            obj.SetActive(false);
            obj.transform.SetParent(_inactivePoolParent);
            _tiles.Add(obj);
        }
    }

    void ManageTileGeneration()
    {
        if (_topTileGenerator.shouldCreateTile)
        {
            GameObject newTile = GetPooledObject();
            if (newTile)
            {
                newTile.transform.position = _topTileGenerator.transform.position;
                newTile.SetActive(true);
                _topTileGenerator.shouldCreateTile = false;
                MoveTileGenerator(_topTileGenerator.transform, _topTilePositionTopYLimit, _topTilePositionBottomYLimit);
            }
        }

        if (_bottomTileGenerator.shouldCreateTile)
        {
            GameObject newTile = GetPooledObject();
            if (newTile)
            {
                newTile.transform.position = _bottomTileGenerator.transform.position;
                newTile.SetActive(true);
                _bottomTileGenerator.shouldCreateTile = false;
                MoveTileGenerator(_bottomTileGenerator.transform, _bottomTilePositionMiddleYLimit, _bottomTilePositionBottomYLimit);
            }
        }
    }

    void MoveTileGenerator(Transform tileGeneratorToMove, float YCoordinateTopLimit, float YCoordinateBottom)
    {
        int randomMovement = Random.Range(0, 2);
        randomMovement = randomMovement > 0 ? 1 : -1;

        if (tileGeneratorToMove.position.y + randomMovement >= YCoordinateBottom 
            && tileGeneratorToMove.position.y + randomMovement <= YCoordinateTopLimit)
        {
            tileGeneratorToMove.position += new Vector3(0f, randomMovement, 0f);
        }
    }

    GameObject GetPooledObject()
    {
        foreach (GameObject x in _tiles)
        {
            if (!x.activeInHierarchy)
            {
                return x;
            }
        }
        return null;
    }
}
