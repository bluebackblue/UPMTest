

/** Samples.SlackWebApi.IncomingWebhooks.Editor
*/
namespace Samples.SlackWebApi.IncomingWebhooks.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** Send_CoroutineDummy
		*/
		public class Send_CoroutineDummy
		{
			/** sendtext
			*/
			private BlueBack.SlackWebApi.IncomingWebhooks.SendText sendtext;

			/** constructor
			*/
			public Send_CoroutineDummy()
			{
				UnityEngine.Debug.Log("Start");

				//サンプル用。
				//「https://api.slack.com/apps」でWebhookURLを取得して下記のＵＲＬを差し替える。
				string t_webhookurl = "https://hooks.slack.com/services/T00000000/B0000000000/000000000000000000000000";

				//開発用。
				#if(DEF_USER_BLUEBACK)
				{
					BlueBack.JsonItem.JsonItem t_jsonitem = new BlueBack.JsonItem.JsonItem(BlueBack.AssetLib.LoadText.LoadTextFromAssetsPath("../../../config/SlackWebApi.txt"));
					t_webhookurl = t_jsonitem.GetItem("webhookurl").GetStringData();
				}
				#endif

				this.sendtext = new BlueBack.SlackWebApi.IncomingWebhooks.SendText(t_webhookurl	,"あいうえお");
			}

			/** Update
			*/
			public void Update()
			{
				if(this.sendtext != null){
					this.sendtext.Update();
					switch(this.sendtext.mode){
					case BlueBack.SlackWebApi.IncomingWebhooks.SendText.Mode.Request:
					case BlueBack.SlackWebApi.IncomingWebhooks.SendText.Mode.Work:
						{
						}return;
					}
				}

				//終了。
				UnityEditor.EditorApplication.update -= Update;
				
				{
					UnityEngine.Debug.Log("mode : " + this.sendtext.mode.ToString());

					if(this.sendtext.result != null){
						UnityEngine.Debug.Log("result : " + this.sendtext.result);
					}

					if(this.sendtext.errorstring != null){
						UnityEngine.Debug.Log("errorstring : " + this.sendtext.errorstring);
					}

					UnityEngine.Debug.Log(this.sendtext.webrequest.responseCode.ToString());
					foreach(var t_pair in this.sendtext.webrequest.GetResponseHeaders()){
						UnityEngine.Debug.Log(t_pair.Key + " : " + t_pair.Value);
					}
				}

				UnityEngine.Debug.Log("End");
				this.sendtext.DisposeWebRequest();
				this.sendtext = null;
			}
		}

		/** 送信。
		*/
		[UnityEditor.MenuItem("サンプル/SlackWebApi/IncomingWebhooks/Send")]
		private static void MenuItem_Send()
		{
			UnityEditor.EditorApplication.update += new Send_CoroutineDummy().Update;
		}
	}
	#endif
}

