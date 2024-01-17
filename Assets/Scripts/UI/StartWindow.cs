using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour {
	[SerializeField] private Button startButton;
	[SerializeField] private TMP_Text targetText;

	 GameplayController gc;

	private void Init() {
		gc = GameplayController.Instance;
		startButton.onClick.AddListener(StartNewGame);
		targetText.text = $" Цели: {gc.OrdersTarget}";
	}

	public void Show() {
		Init();
		gameObject.SetActive(true);
	}

	private void StartNewGame()
	{
		gc.StartNewGame();
	}

	public void Hide() {
		gameObject.SetActive(false);
	}
}
