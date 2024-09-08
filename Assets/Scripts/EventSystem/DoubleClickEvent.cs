
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem {
	public class DoubleClickEvent : MonoBehaviour {
		[SerializeField] [Range(0.02f, 0.3f)]
		private float _maxDeltaTimeToTriggerInSeconds;
		private float _timeFromPreviousTap;
		private bool IsTapRecently => _timeFromPreviousTap > 0 && 
		                              _timeFromPreviousTap <= _maxDeltaTimeToTriggerInSeconds;

		[SerializeField]
		private UnityEvent OnDoubleClick = new UnityEvent();

		private Coroutine timerRoutine;

		[UsedImplicitly]
		public void OnPointerUp() {
			if ( IsTapRecently ) {
				OnDoubleClick.Invoke();
				_timeFromPreviousTap = 0;
				StopCoroutine(timerRoutine);
				timerRoutine = null;
				return;
			}

			_timeFromPreviousTap = 0;
			
			if ( timerRoutine == null ) {
				timerRoutine = StartCoroutine(TimerRoutine());
			}
		}

		public void AddListenerOnDoubleClick(UnityAction action) => OnDoubleClick.AddListener(action);
		public void RemoveListenerOnDoubleClick(UnityAction action) => OnDoubleClick.AddListener(action);

		private IEnumerator TimerRoutine() {
			while ( true ) {
				_timeFromPreviousTap += Time.deltaTime;
				yield return null;
			}
		}
	}
}