using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
	[SerializeField] 
	private Text _text;

	private PointDrawer _winner;
	
	private void Start() => _winner = gameObject.GetComponent<PointDrawer>();

	private void Update()
	{
		
		if (_winner.GetWinner()==PointDrawer.Winner.No)
			return;
		
		_text.gameObject.SetActive(true);
		
		if (_winner.GetWinner() == PointDrawer.Winner.Blue)
			_text.text = "Blue Win";
		else if (_winner.GetWinner() == PointDrawer.Winner.Green)
			_text.text = "Green Win";
		else if (_winner.GetWinner() == PointDrawer.Winner.Red)
			_text.text = "Red Win";
		else if (_winner.GetWinner() == PointDrawer.Winner.Yellow)
			_text.text = "Yellow Win";
		else
			_text.text = "";
	}

	public Text GetText() => _text;
}
