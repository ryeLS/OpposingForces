using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class MoveToGem : ActionTask {
		public NavMeshAgent navmeshAgent;
		public BBParameter<GameObject> target;
		public BBParameter<float> speedBonus;

		protected override void OnExecute() {
			
            navmeshAgent.SetDestination(target.value.transform.position);
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			
			
            if (!navmeshAgent.pathPending)
			{
				if(navmeshAgent.remainingDistance<= navmeshAgent.stoppingDistance)
				{
					if(!navmeshAgent.hasPath || navmeshAgent.velocity.sqrMagnitude == 0)
					{
						EndAction(true);
						speedBonus.value++;
						Object.Destroy(target.value);
					}
				}
			}
		}

	}
}