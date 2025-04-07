using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FindGems : ConditionTask {
		public LayerMask gemLayers = -1;
		public float searchRadius = 5f;
		Transform bestGem;
		float bestDistance = Mathf.Infinity;
		public BBParameter<GameObject> closestGem;

		protected override bool OnCheck() {
			Collider[] collider = Physics.OverlapSphere(agent.transform.position, searchRadius, gemLayers);
			if(collider.Length > 0)
			{
				foreach (Collider colliders in collider)
				{
					float distanceToTarget = Vector3.Distance(agent.transform.position, colliders.gameObject.transform.position);
					if(distanceToTarget < bestDistance)
					{
						bestDistance = distanceToTarget;
						closestGem.value = colliders.gameObject;
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}