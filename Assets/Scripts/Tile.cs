using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	private static Tile previousSelected = null;
	private static Tile actualSelected = null;

	private SpriteRenderer render;
	private bool isSelected = false;
	private bool matchFound = false;
	private bool superMatch = false;

	private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

	void Awake() {
		render = GetComponent<SpriteRenderer>();
    }

	private void Select() {
		isSelected = true;
		render.color = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
		//SFXManager.instance.PlaySFX(Clip.Select); => Play Sound
	}

	private void Deselect() {
		isSelected = false;
		render.color = Color.white;
		previousSelected = null;
	}

	void OnMouseDown()
	{
		if (render.sprite == null || BoardManager.instance.IsShifting)
		{
			return;
		}

		if (isSelected)
		{ //Déjà selectionné ?
			Deselect();
		}
		else
		{
			if (previousSelected == null)
			{ //C'est le premier à être sélectionné ?
				Select();
			}
			else
			{
				if (GetAllAdjacentTiles().Contains(previousSelected.gameObject))
				{
					SwapSprite(previousSelected.render);
					if (matchFound)
                    {
						actualSelected = gameObject.GetComponent<Tile>();
						if (superMatch)
                        {
							SuperMatchCombo();
							superMatch = false;
                        } else
                        {
							previousSelected.ClearMatch();
						}
						actualSelected.ClearMatch();
						StopCoroutine(BoardManager.instance.FindNullTiles());
						StartCoroutine(BoardManager.instance.FindNullTiles());
						matchFound = false;
						actualSelected = null;
						GUIManager.instance.MoveCounter--;
					}
					previousSelected.Deselect();
					
				}
				else
				{
					previousSelected.GetComponent<Tile>().Deselect();
					Select();
				}
			}
		}
	}

	public void SwapSprite(SpriteRenderer render2)
	{
		if (render.sprite.name != "sl_axe_bg" && render2.sprite.name != "sl_axe_bg") {
			return;
		}

		if (render.sprite.name == render2.sprite.name) { superMatch = true; }
		matchFound = true;
		Sprite tempSprite = render2.sprite;
		render2.sprite = render.sprite;
		render.sprite = tempSprite;
		//SFXManager.instance.PlaySFX(Clip.Swap); => Play sound
	}

	private GameObject GetAdjacent(Vector2 castDir)
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
		if (hit.collider != null)
		{
			return hit.collider.gameObject;
		}
		return null;
	}

	private List<GameObject> GetAllAdjacentTiles()
	{
		List<GameObject> adjacentTiles = new List<GameObject>();
		for (int i = 0; i < adjacentDirections.Length; i++)
		{
			adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
		}
		return adjacentTiles;
	}

	public void ClearMatch()
    {
		if (render.sprite.name == "sl_axe_bg")
        {
			BoardManager.instance.ActualToolsQt--;
		}

		if (render.sprite.name == "wood_bg") { GUIManager.instance.Score ++; }
		
		render.sprite = null;
		BoardManager.instance.ActualEmtpyTile++;
	}

	public void SuperMatchCombo()
    {
		for (int i = 0; i < adjacentDirections.Length; i++)
		{
			if (GetAdjacent(adjacentDirections[i]) != null)
			{
				GetAdjacent(adjacentDirections[i]).GetComponent<Tile>().ClearMatch();
			}
		}
	}
}