using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TileGenerator : MonoBehaviour {

    [SerializeField]
    private TileGeneratorDetector _topTileGenerator;
    [SerializeField]
    private TileGeneratorDetector _bottomTileGenerator;

    [SerializeField]
    private GameObject _tilePrefab;
    [SerializeField]
    private int _tilePoolAmount;
    [SerializeField]
    private List<GameObject> _tiles = new List<GameObject>();

    [SerializeField]
    private Transform _inactivePoolParent;
    [SerializeField]
    private Transform _activePoolParent;


    // Use this for initialization
    void Start () {
        InitializeObjectPool();
	}

    // Update is called once per frame
    void Update()
    {
        ManageTileGeneration();
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
            }
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
