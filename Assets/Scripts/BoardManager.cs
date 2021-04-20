using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;
    public List<Sprite> characters = new List<Sprite>();
    public GameObject tile, MainCamera;
    public int xSize, ySize, MaxToolsQt, ActualToolsQt,ActualEmtpyTile;
    public float TileDimension;

    private GameObject[,] tiles;
    private int TileName;

    public bool IsShifting { get; set; }     // Ne pas utiliser (permet d'éviter les alignements lors de la création (pas pertinent ici)

    void Start()
    {
        instance = GetComponent<BoardManager>();

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateBoard(offset.x, offset.y);

        transform.position = new Vector2(-TileDimension * (((float)xSize-1)/2), -TileDimension * (((float)ySize-1)/2));
        MainCamera.GetComponent<Camera>().orthographicSize = TileDimension * xSize;
    }
    
    private void CreateBoard(float xOffset, float yOffset)
    {
        tiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                tiles[x, y] = newTile;

                newTile.transform.parent = transform;
                newTile.name = "Tile n°" + TileName.ToString();
                TileName ++;

                if (ActualToolsQt < MaxToolsQt)
                {
                    Sprite newSprite = characters[Random.Range(0, characters.Count)];
                    newTile.GetComponent<SpriteRenderer>().sprite = newSprite;
                    if (newSprite == characters[1]) { ActualToolsQt++; }
                } else
                {
                    Sprite newSprite = characters[0];
                    newTile.GetComponent<SpriteRenderer>().sprite = newSprite;
                }
            }
        }
    }

    public IEnumerator FindNullTiles()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (tiles[x, y].GetComponent<SpriteRenderer>().sprite == null)
                {
                    yield return StartCoroutine(ShiftTilesDown(x, y));
                    break;
                }
            }
        }
    }

    private IEnumerator ShiftTilesDown(int x, int yStart, float shiftDelay = .03f)
    {
        IsShifting = true;
        List<SpriteRenderer> renders = new List<SpriteRenderer>();
        int nullCount = 0;

        for (int y = yStart; y < ySize; y++)
        {
            SpriteRenderer render = tiles[x, y].GetComponent<SpriteRenderer>();
            if (render.sprite == null)
            {
                nullCount++;
            }
            renders.Add(render);
        }

        for (int i = 0; i < nullCount; i++)
        {
            yield return new WaitForSeconds(2*shiftDelay);

            if (renders.Count == 1) { renders[0].sprite = GetNewSprite(i, renders.Count);}
            
            for (int k = 0; k < renders.Count - 1; k++)
            {
                renders[k].sprite = renders[k + 1].sprite;
                //renders[k + 1].sprite = GetNewSprite(x, ySize - 1, i, nullCount);
            }
            renders[renders.Count - 1].sprite = GetNewSprite(i, nullCount);
            
            if (renders[renders.Count - 1].sprite == characters[1]) { ActualToolsQt++;}
            ActualEmtpyTile--;
        }
        IsShifting = false;
    }


    private Sprite GetNewSprite(int i, int Count)
    {
        List<Sprite> possibleCharacters = new List<Sprite>();
        possibleCharacters.AddRange(characters);

        print("i " + i + " - Count " + Count + " - Actual EmptyTile " + ActualEmtpyTile + " - Avant l'aléatoire j'ai : " + ActualToolsQt + " ActualsToolsQt");

        if (ActualEmtpyTile == (MaxToolsQt - ActualToolsQt))
        {
            print("J'ai pas le choix => outil");
            return possibleCharacters[1];
        } else if (ActualToolsQt < MaxToolsQt)
        {
            print("Je suis aléatoire car j'ai MaxToolQt = " + MaxToolsQt + " et ActualsToolsQt = " + ActualToolsQt + " - Actual EmptyTile " + ActualEmtpyTile);
            return possibleCharacters[Random.Range(0, 1)];
        }
        else if (MaxToolsQt == ActualToolsQt) 
        {
            print("ai pas le choix => bois");
            return possibleCharacters[0];
        } else
        {
            print("i " + i + " - Count " + Count + " - J'ai pas de solution, problème");
            return possibleCharacters[Random.Range(0, 1)];
        }

        /*if ((nullCount - i) == (MaxToolsQt - ActualToolsQt))
        {
            print("i " + i + " - nullCount " + nullCount + " - J'ai pas le choix => outil");
            possibleCharacters = characters[1];
        }
        else if (ActualToolsQt < MaxToolsQt)
        {
            print("i " + i + " - nullCount " + nullCount + " - Je suis aléatoire car j'ai MaxToolQt = " + MaxToolsQt + " et ActualsToolsQt = " + ActualToolsQt);
            possibleCharacters = characters[Random.Range(0, characters.Count)];
        }
        else if (((nullCount - i) > (MaxToolsQt - ActualToolsQt)))
        {
            print("i " + i + " - nullCount " + nullCount + " - J'ai pas le choix => bois");
            possibleCharacters = characters[0];
        }
        else
        {
            print("i " + i + " - nullCount " + nullCount + " - J'ai pas de solution, problème");
        }*/

        //return possibleCharacters[Random.Range(0, 1)];
    }
}
