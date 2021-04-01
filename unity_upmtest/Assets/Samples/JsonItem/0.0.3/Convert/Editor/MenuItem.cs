

/** Samples.JsonItem.Convert.Editor
*/
namespace Samples.JsonItem.Convert.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** Item
		*/
		private struct Item
		{
			public int x;
			public bool yy;
			public float zzz;
		}

		/** シーンを開く。
		*/
		[UnityEditor.MenuItem("サンプル/JsonItem/Convert/Test")]
		private static void MenuItem_Sample_AssetLib_Convert_Test()
		{
			Item t_from_item = new Item()
			{
				x = 100,
				yy = true,
				zzz = 99.99f,
			};

			//JsonItemにコンバート。
			BlueBack.JsonItem.JsonItem t_jsonitem = BlueBack.JsonItem.Convert.ObjectToJsonItem(t_from_item);

			//JSON文字列にコンバート。
			string t_jsonstring = t_jsonitem.ConvertToJsonString();
			UnityEngine.Debug.Log("ConvertToJsonString : " + t_jsonstring);

			//オブジェクトにコンバート。
			Item t_to_item = t_jsonitem.ConvertToObject<Item>();
			UnityEngine.Debug.Log("ConvertToObject : x = " + t_to_item.x.ToString());
			UnityEngine.Debug.Log("ConvertToObject : yy = " + t_to_item.yy.ToString());
			UnityEngine.Debug.Log("ConvertToObject : zzz = " + t_to_item.zzz.ToString());

			//JsonItemから直接取り出す。
			t_jsonitem = new BlueBack.JsonItem.JsonItem(t_jsonstring);
			UnityEngine.Debug.Log("JsonItem : x = " + t_jsonitem.GetItem("x").CastToInt32().ToString());
			UnityEngine.Debug.Log("JsonItem : yy = " + t_jsonitem.GetItem("yy").GetBoolData().ToString());
			UnityEngine.Debug.Log("JsonItem : zzz = " + t_jsonitem.GetItem("zzz").CastToSingle().ToString());
		}
	}
	#endif
}

