using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
	[Header("Tilemaps")]
	[Space(5)]
	
	[SerializeField]
	Tilemap _background;
	[SerializeField]
	Tilemap _map;
	
	[Space(20)]
	
	[Header("TileBases")]
	[Space(5)]
	
	[SerializeField]
	TileBase[] _dots;
	
	private TileBase _clickedBackgroundTile;
	private TileBase _clickedForegroundTile;

	private Vector3Int _gridPos;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousPos = VectorClamp(Camera.main.ScreenToWorldPoint(Input.mousePosition), -4, 3.5f, -5, 5);
			_gridPos = _background.WorldToCell(mousPos);

			//Debug.Log($"mousPos is \t{mousPos}");
			//Debug.Log($"gridPos is \t{gridPos}");
			//Debug.Log(clickedBackgroundTile.name);

			_clickedBackgroundTile = _background.GetTile(_gridPos);
			_clickedForegroundTile = _map.GetTile(_gridPos);

			if (_clickedBackgroundTile != null)
			{
				if (_clickedForegroundTile != null)
				{
					string name = GetName(_clickedForegroundTile);
				}
			}
		}
	}
	Vector3 VectorClamp(Vector3 rawVector, float minX, float maxX, float minY, float maxY)
	{
		Vector3 vector = new Vector3(Mathf.Clamp(rawVector.x, minX, maxX), Mathf.Clamp(rawVector.y, minY, maxY), -10);
		return vector;
	}
	string GetName(TileBase clickedTile) => clickedTile.name;
	public Vector3Int GetPosition() => _gridPos;
	
	public Tilemap GetMap() => _map;
	public Tilemap GetGrid() => _background;
	
	public TileBase GetFrontTile() => _clickedForegroundTile;
	public TileBase GetBackTile() => _clickedBackgroundTile;
	public TileBase[] GetDots() => _dots;
	
	public void BlueDraw(Vector3Int gridPosition, string name)
	{
		if (name.Contains("1"))
			_map.SetTile(gridPosition, _dots[1]);
		else if (name.Contains("2"))
			_map.SetTile(gridPosition, _dots[2]);
		else if (name.Contains("3"))
			_map.SetTile(gridPosition, _dots[3]);
	}
	public void GreenDraw(Vector3Int gridPosition, string name)
	{
		if (name.Contains("1"))
			_map.SetTile(gridPosition, _dots[5]);
		else if (name.Contains("2"))
			_map.SetTile(gridPosition, _dots[6]);
		else if (name.Contains("3"))
			_map.SetTile(gridPosition, _dots[7]);
	}
	public void RedDraw(Vector3Int gridPosition, string name)
	{
		if (name.Contains("1"))
			_map.SetTile(_gridPos, _dots[9]);
		else if (name.Contains("2"))
			_map.SetTile(_gridPos, _dots[10]);
		else if (name.Contains("3"))
			_map.SetTile(_gridPos, _dots[11]);
	}
	public void YellowDraw(Vector3Int gridPosition, string name)
	{
		if (name.Contains("1"))
			_map.SetTile(_gridPos, _dots[13]);
		else if (name.Contains("2"))
			_map.SetTile(_gridPos, _dots[14]);
		else if (name.Contains("3"))
			_map.SetTile(_gridPos, _dots[15]);
	}
	
}
