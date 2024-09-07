using System;
using CookingPrototype.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookingPrototype.UI {
	public class GoalsWindow : MonoBehaviour{
		[SerializeField] 
		private TMP_Text _goalValue = null;
		[SerializeField] 
		private Button _continueButton = null;

		private GameplayController _gc;

		private void OnEnable() {
			Init();
		}

		private void Start() {
			Init();
		}

		private void Init() {
			_gc = GameplayController.Instance;
			if(_gc != null)
				_goalValue.text = _gc.OrdersTarget.ToString();

			_continueButton.onClick.RemoveListener(StartGame);
			_continueButton.onClick.AddListener(StartGame);
		}

		private void StartGame() {
			_gc?.Play();
			Hide();
		}
		
		public void Show () {
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}