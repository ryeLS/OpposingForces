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
 
        protected override string OnInit() {
			return null;
		}

	
		protected override void OnExecute() {
			prevPosition = agent.transform.position;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            timer += Time.deltaTime;
            if (timer <= maxTime)
            {//motion of jumping once
                float yOffset = Mathf.Sin(timer * speed) * moveDistance;
               agent.transform.position = prevPosition + new Vector3(0, yOffset, 0);
            }
			if(timer > maxTime)
			{
				EndAction(true);
			}
        }

	}
}