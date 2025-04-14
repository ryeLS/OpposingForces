using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class Jump : ActionTask {
        float moveDistance = 2f;
        public float timer = 0f;
        float maxTime = 0.7f;
        float speed = 4f;
        Vector3 prevPosition;
        public AudioClip jumpSound;
        public AudioSource source;
        //https://freesound.org/s/462958/ - jump sound

        protected override string OnInit() {
			return null;
		}

	
		protected override void OnExecute() {
			prevPosition = agent.transform.position; //store previous position to snap back to
            source = agent.GetComponent<AudioSource>();
            source.PlayOneShot(jumpSound);
        }

		
		protected override void OnUpdate() {
            timer += Time.deltaTime;
            if (timer <= maxTime) //timer so this action only occurs for a short time
            {//motion of jumping once
                float yOffset = Mathf.Sin(timer * speed) * moveDistance;
               agent.transform.position = prevPosition + new Vector3(0, yOffset, 0);
            }
			if(timer > maxTime)
			{
				timer = 0;//reset timer and end task
				EndAction(true);
			}
        }

	}
}