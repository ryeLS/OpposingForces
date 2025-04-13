using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FindGems : ConditionTask {
		public LayerMask gemLayers = -1;
		public float searchRadius = 5f;
		Transform bestGem;
		
		public BBParameter<GameObject> closestGem;

		protected override bool OnCheck() {
			//stores any colliders that the king is near within the search radius
			Collider[] collider = Physics.OverlapSphere(agent.transform.position, searchRadius, gemLayers);
			if(collider.Length > 0) //if there is at least 1 near the king then
			{
                float bestDistance = Mathf.Infinity;
                foreach (Collider colliders in collider) //check distance of each collider to see whats closest to best distance;
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