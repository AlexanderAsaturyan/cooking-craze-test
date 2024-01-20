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

		public void OnPointerClick(PointerEventData eventData)
		{
			if ( eventData.clickCount == 2 )
			{
				_onDoubleClicked?.Invoke();
			}
		}
	}
}
