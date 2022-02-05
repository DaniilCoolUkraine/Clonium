using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenu : MonoBehaviour
{
	[SerializeField] 
	private GameObject _menuTile; //container to set menu visible/not

	[SerializeField] 
	private GameObject _musicManager; //container to store audio source
	
	[SerializeField]
	private Text _text;

	//open menu
	public void Open()
	{
		_text.gameObject.SetActive(false);
		_menuTile.gameObject.SetActive(true);
		gameObject.GetComponent<MapManager>().enabled = false;
		gameObject.GetComponent<Stepwise>().enabled = false;
	}

	//close menu
	public void Close()
	{
		_text.gameObject.SetActive(true);
		_menuTile.gameObject.SetActive(false);
		gameObject.GetComponent<MapManager>().enabled = true;
		gameObject.GetComponent<Stepwise>().enabled = true;
	}
	
	//restart
	public void Restart() => SceneManager.LoadScene(0);
	
	//exit from game
	public void Exit() => Application.Quit();
	
	//mute music
	public void Muter() => _musicManager.gameObject.SetActive(false);
	
	//unmute music
	public void Unmuter() => _musicManager.gameObject.SetActive(true);
}