using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public float MapSize;
    public float distanceBetwenTiels;

    public GameObject test;

    public List<GameObject> startCornerParts;
    public List<GameObject> endCornerParts;
    public List<GameObject> StartCornerPartEnds;
    public List<GameObject> EndCornerPartEnds;
    public List<GameObject> StartPageParts;
    public List<GameObject> EndPageParts;
    public List<GameObject> rightSideParts;
    public List<GameObject> leftSideParts;
    public List<GameObject> NormalParts;

    private void Start()
    {
        CreateMap();
    }

    void CreateMap()
    {
        for (int y = 0; y < MapSize; y++)
        {
            for (int x = 0; x < MapSize; x++)
            {
                Vector3 positioOnTheWorldMap = new Vector3(x * distanceBetwenTiels,transform.position.y,y * distanceBetwenTiels);
                Vector2 mapIndex = new Vector2(x,y);
                SetTile(mapIndex,positioOnTheWorldMap);
            }
        }

    }

    void SetTile(Vector2 Index,Vector3 position)
    {
        GameObject Tile;

        if(Index.y == 0 && Index.x == 0)
        {
           Tile = GetRandomTile(TileType.StartCornerPart);
        }
        else if(Index.y == 0)
        {
            Tile = GetRandomTile(TileType.StartPagePart);
        }
        else if(Index.y == 0 && Index.x == MapSize)
        {
            Tile = GetRandomTile(TileType.StartCornerPartEnd);
        }
        else if(Index.x == 0)
        {
            Tile = GetRandomTile(TileType.rightSidePart);
        }
        else if(Index.x == MapSize)
        {
            Tile = GetRandomTile(TileType.LeftSidePart);
        }
        else if(Index.y == MapSize && Index.x == 0)
        {
            Tile = GetRandomTile(TileType.EndCornerPart);
        }
        else if(Index.y == MapSize)
        {
            Tile = GetRandomTile(TileType.EndPagePart);
        }
        else if(Index.y == MapSize && Index.x == MapSize)
        {
            Tile = GetRandomTile(TileType.EndCornerPartEnd);
        }
        else
        {
            Tile = GetRandomTile(TileType.NormalPart);
        }

        Tile.transform.position = position;
        Instantiate(Tile,transform);
    }



    GameObject GetRandomTile(TileType tileType)
    {
        switch (tileType)
        {
            case TileType.StartCornerPart:
                return startCornerParts[Random.Range(0, StartPageParts.Count)];
                break;
            case TileType.EndCornerPart:
                return endCornerParts[Random.Range(0,endCornerParts.Count)];
                break;
            case TileType.StartCornerPartEnd:
                return StartCornerPartEnds[Random.Range(0,StartCornerPartEnds.Count)];
                break;
            case TileType.EndCornerPartEnd:
                return EndCornerPartEnds[Random.Range(0,EndCornerPartEnds.Count)];
                break;
            case TileType.StartPagePart:
                return StartPageParts[Random.Range(0,StartPageParts.Count)];
                break;
            case TileType.EndPagePart:
                return EndPageParts[Random.Range(0, EndPageParts.Count)];
                break;
            case TileType.rightSidePart:
                return rightSideParts[Random.Range(0,rightSideParts.Count)];
                break;
            case TileType.LeftSidePart:
                return leftSideParts[Random.Range(0,leftSideParts.Count)];
                break;
            case TileType.NormalPart:
                return NormalParts[Random.Range(0,NormalParts.Count)];
                break;
            default:
                return null;
                break;
        }
    }
    
    enum TileType
    {
        StartCornerPart,
        EndCornerPart,
        StartCornerPartEnd,
        EndCornerPartEnd,
        StartPagePart,
        EndPagePart,
        rightSidePart,
        LeftSidePart,
        NormalPart,
    }
}
