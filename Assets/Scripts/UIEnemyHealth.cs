using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealth : MonoBehaviour {

	[SerializeField] RectTransform healthSlider;

	public void SetLives(int maxLives, int lives){
		UpdateSlider (maxLives, lives);
	}

	public void UpdateSlider(int maxLives, int lives){
		if (healthSlider == null) {
			return;
		}
		float relativeScale = (float)lives / (float)maxLives;
		Vector3 scale = healthSlider.transform.localScale;
		scale.x = relativeScale;
		healthSlider.transform.localScale = scale;
	}
}
