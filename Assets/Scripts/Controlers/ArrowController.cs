using UnityEngine;

public class ArrowController : MonoBehaviour {

	[SerializeField] private float speedRotation = 100f;

	[SerializeField] private float startAngle = 25f;
	[SerializeField] private float endAngle = 155f;

	private void Start() {
		gameObject.SetActive(false);
		transform.rotation = Quaternion.Euler(0, 0, startAngle);
	}
	
	public void MoveArrow() {
		
		if (transform.rotation.eulerAngles.z >= endAngle) {
			speedRotation = -Mathf.Abs(speedRotation);
		} else if (transform.rotation.eulerAngles.z <= startAngle) {
			speedRotation = Mathf.Abs(speedRotation);
		}

		transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime);
	}
}