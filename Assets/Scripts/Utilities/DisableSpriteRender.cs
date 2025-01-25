using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour that disables the SpriteRenderer of the GameObject it is attached to when it is enabled.
/// </summary>
public class DisableSpriteRender : MonoBehaviour{
	private void OnEnable() => GetComponent<SpriteRenderer>().enabled = false;
	private void Start() {
		Debug.Log("a");
	}
}
