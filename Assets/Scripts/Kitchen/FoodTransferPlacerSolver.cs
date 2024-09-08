using System;
using UnityEngine;

namespace CookingPrototype.Kitchen {
	
	[RequireComponent(typeof(FoodTransfer), typeof(FoodPlace))]
	public class FoodTransferPlacerSolver : MonoBehaviour {

		[SerializeField]
		private FoodPlacer _foodPlacer;
		
		private FoodTransfer _foodTransfer;
		private FoodPlace _foodPlace;
		
		private void Awake() {
			_foodTransfer = GetComponent<FoodTransfer>();
			_foodPlace = GetComponent<FoodPlace>();

			if ( _foodPlacer == null )
				throw new NullReferenceException($"Must to initialize {nameof(_foodPlacer)} field.");
		}

		public void OnPointerUp() {
			if ( _foodPlace.IsFree ) {
				_foodPlacer.TryPlaceFoodAt(_foodPlace);
				return;
			}

			_foodTransfer.TryTransferFood();
		}
	}
}