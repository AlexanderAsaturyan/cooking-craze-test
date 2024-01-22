using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour, IPointerClickHandler
		{
		private Action _onDoubleClicked;	

		FoodPlace _place = null;
		float     _timer = 0f;
		private float _lastTimeClick;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
			_onDoubleClicked += TryTrashFood;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		public void TryTrashFood()
		{
			if( _place.CurFood?.CurStatus == Food.FoodStatus.Overcooked )
			{
				_place.FreePlace();
			}
		}

		public void OnPointerClick(PointerEventData eventData) {
			float currentTimeClick = eventData.clickTime;
			if ( Mathf.Abs(currentTimeClick - _lastTimeClick) < 0.4f ) {
				_onDoubleClicked?.Invoke();
			}
			_lastTimeClick = currentTimeClick;
		}
	}
}
