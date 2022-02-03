using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenu : MonoBehaviour
{
	[SerializeField] 
	private GameObject _menuTile; //container to set menu visible/not

	//open menu
	public void Open()
	{
		_menuTile.gameObject.SetActive(true);
		gameObject.GetComponent<MapManager>().enabled = false;
		gameObject.GetComponent<Stepwise>().enabled = false;
	}

	//close menu
	public void Close()
	{
		_menuTile.gameObject.SetActive(false);
		gameObject.GetComponent<MapManager>().enabled = true;
		gameObject.GetComponent<Stepwise>().enabled = true;
	}
	
	//restart
	public void Restart() => SceneManager.LoadScene(0);
	
	//exit from game
	public void Exit() => Application.Quit();
}