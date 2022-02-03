using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
	[SerializeField] 
	private Text _text;

	private PointDrawer _winner;
	
	private void Start()
	{
		_winner = gameObject.GetComponent<PointDrawer>();
	}

	private void Update()
	{
		if (_winner.GetWinner() == PointDrawer.Winner.Blue)
		{
			_text.text = "Blue Win";
			Time.timeScale = 0;
		}
		else if (_winner.GetWinner() == PointDrawer.Winner.Green)
		{
			_text.text = "Green Win";
			Time.timeScale = 0;
		}
		else if (_winner.GetWinner() == PointDrawer.Winner.Red)
		{
			Time.timeScale = 0;
			_text.text = "Red Win";
		}
		else if (_winner.GetWinner() == PointDrawer.Winner.Yellow)
		{
			Time.timeScale = 0;
			_text.text = "Yellow Win";
		}
		else
			_text.text = "";
	}

}
