

/** Samples.TimeScale.Exsample
*/
namespace Samples.TimeScale.Exsample
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** timescale
		*/
		private BlueBack.TimeScale.TimeScale timescale;

		/** ポーズ。
		*/
		public bool pause;
		
		/** ポーズを１フレーム解除する。
		*/
		public bool stepplay_request;

		/** テキスト。
		*/
		public UnityEngine.UI.Text uitext_fixed;
		public UnityEngine.UI.Text uitext_delta;

		/** fixedcount
		*/
		public int fixedcount;

		/** Awake
		*/
		private void Awake()
		{
			UnityEngine.Time.fixedDeltaTime = 1.0f / 60.0f;
			UnityEngine.Application.targetFrameRate = 60;
			UnityEngine.QualitySettings.vSyncCount = -1;

			//timescale
			this.timescale = new BlueBack.TimeScale.TimeScale();

			//ui_text
			this.uitext_fixed = UnityEngine.GameObject.Find("Fixed").GetComponent<UnityEngine.UI.Text>();
			this.uitext_delta = UnityEngine.GameObject.Find("Delta").GetComponent<UnityEngine.UI.Text>();

			//fixedcount
			this.fixedcount = 0;
		}

		/** FixedUpdate
		*/
		private void FixedUpdate()
		{
			this.fixedcount++;
			this.uitext_fixed.text = this.fixedcount.ToString();
		}

		/** LateUpdate
		*/
		private void LateUpdate()
		{
			//ポーズ。
			if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space) == true){
				this.pause ^= true;
			}

			//ステップ。
			if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Return) == true){
				this.stepplay_request = true;
			}

			//ポーズ設定。
			this.timescale.SetPause(this.pause);
			
			//uitext_delta
			if(this.pause == true){
				if(UnityEngine.Time.deltaTime > 0.0f){
					this.uitext_delta.text = UnityEngine.Time.deltaTime.ToString() + " : " + this.timescale.GetTimeScale().ToString();
				}
			}else{
				this.uitext_delta.text = UnityEngine.Time.deltaTime.ToString();
			}

			//ポーズを１フレーム解除する。
			if(this.stepplay_request == true){
				this.stepplay_request = false;
				this.timescale.StepPlay();
			}
		}

		/** OnDestroy
		*/
		private void OnDestroy()
		{
			if(this.timescale != null){
				this.timescale.Dispose();
				this.timescale = null;
			}
		}
	}
}

