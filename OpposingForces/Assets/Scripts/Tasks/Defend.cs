using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions {

	public class Defend : ActionTask {
		public BBParameter<Transform> playerTransform;
		public BBParameter<Transform> kingTransform;
		public NavMeshAgent navAgent;
		public AudioClip defendSound;
		public AudioSource source;
        //https://freesound.org/people/mrickey13/sounds/518850/ - defence sound

        protected override void OnExecute() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			source = agent.GetComponent<AudioSource>();
            source.PlayOneShot(defendSound);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			navAgent.speed = 4;
			//puts the destination of navmesh between player and king
			navAgent.SetDestination(0.5f * (playerTransform.value.position + kingTransform.value.position));

			
		//checks if distance between king and player is close enough to be considered a win
			if(Vector3.Distance(kingTransform.value.position, playerTransform.value.position) <= 2) // win con is reaching king
			{
				Debug.Log("reached");
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //resets scene
			}
		}

	}
}