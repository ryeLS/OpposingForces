using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class DistanceBetweenKing : ConditionTask {
		public BBParameter<Transform> playerTransform;
		public BBParameter<Transform> kingTransform;

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() { //checks if king is close enough to player
			if (Vector3.Distance(kingTransform.value.position, playerTransform.value.position) <= 6) return true;
			else return false;
		}
	}
}