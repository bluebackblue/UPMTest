

/** Samples.Pad.Simple
*/
namespace Samples.Pad.Simple
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** Update用。
		*/
		private BlueBack.Pad.Pad pad;

		/** FixedUpdate用。
		*/
		private BlueBack.Pad.Pad pad_fixedupdate;

		/** Start
		*/
		private void Start()
		{
			//Param
			BlueBack.Pad.UIM.Param t_param = new BlueBack.Pad.UIM.Param(BlueBack.Pad.UIM.Param.ParamType.PS_ALL);

			//Update用。
			this.pad = new BlueBack.Pad.Pad(BlueBack.Pad.Mode.Update,new BlueBack.Pad.Param(),new BlueBack.Pad.UIM.Engine(t_param));

			//FixedUpdate用。
			this.pad_fixedupdate = new BlueBack.Pad.Pad(BlueBack.Pad.Mode.FixedUpdate,new BlueBack.Pad.Param(),new BlueBack.Pad.UIM.Engine(t_param));
		}

		/** Update
		*/
		private void Update()
		{
			if(this.pad.dir_r.down == true){
				UnityEngine.Debug.Log("Update : Right");
			}
			if(this.pad.dir_d.down == true){
				UnityEngine.Debug.Log("Update : Down");
			}
			if(this.pad.dir_l.down == true){
				UnityEngine.Debug.Log("Update : Left");
			}
			if(this.pad.dir_u.down == true){
				UnityEngine.Debug.Log("Update : Up");
			}
		}

		/** FixedUpdate
		*/
		private void FixedUpdate()
		{
			if(this.pad_fixedupdate.dir_r.down == true){
				UnityEngine.Debug.Log("Update : Right");
			}
			if(this.pad_fixedupdate.dir_d.down == true){
				UnityEngine.Debug.Log("Update : Down");
			}
			if(this.pad_fixedupdate.dir_l.down == true){
				UnityEngine.Debug.Log("Update : Left");
			}
			if(this.pad_fixedupdate.dir_u.down == true){
				UnityEngine.Debug.Log("Update : Up");
			}
		}
	}
}

