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
        public AudioClip gemSound;
        public AudioSource source;
        //https://freesound.org/people/CJspellsfish/sounds/676401/ - get gem sound
        // https://freesound.org/people/AdminMP/sounds/383200/ - running away sound

        protected override void OnExecute() {
			
            navmeshAgent.SetDestination(target.value.transform.position);
            source = agent.GetComponent<AudioSource>();
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			
			
            if (!navmeshAgent.pathPending)
			{
				if(navmeshAgent.remainingDistance<= navmeshAgent.stoppingDistance)
				{
					if(!navmeshAgent.hasPath || navmeshAgent.velocity.sqrMagnitude == 0)
					{
						EndAction(true); //if nav mesh agent is closs enough to target and magnitude = 0 end task and add speed
						speedBonus.value++;

                        source.PlayOneShot(gemSound);
                        Object.Destroy(target.value);
					}
				}
			}
		}

	}
}