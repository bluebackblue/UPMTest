

/** Samples.AssetLib.Script.Editor
*/
namespace Samples.AssetLib.Script.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** 「Enum.cs」を作成。
		*/
		[UnityEditor.MenuItem("サンプル/AssetLib/Script/CreateEnumToAssetsPath")]
		private static void MenuItem_CreateEnumToAssetsPath()
		{
			System.Collections.Generic.List<BlueBack.AssetLib.SaveEnumItem> t_list = new System.Collections.Generic.List<BlueBack.AssetLib.SaveEnumItem>();
			{
				t_list.Add(new BlueBack.AssetLib.SaveEnumItem("TypeA","タイプＡ"));
				t_list.Add(new BlueBack.AssetLib.SaveEnumItem("TypeB","タイプＢ"));
				t_list.Add(new BlueBack.AssetLib.SaveEnumItem("TypeC","タイプＣ"));
				t_list.Add(new BlueBack.AssetLib.SaveEnumItem("None",-1,"なし"));
			}

			string[] t_template_header = new string[]{
				"",
				"",
				"/** 自動生成",
				"*/",
				"",
				"",
				"/** Namespace",
				"*/",
				"namespace Namespace",
				"{",
				"	/** Enum",
				"	*/",
				"	public enum Enum",
				"	{",
			};

			string[] t_template_loop = new string[]{
				"		/** <<C>>。",
				"		*/",
				"		<<V>>,",
				"",
			};

			string[] t_template_loopend = new string[]{
				"		/** <<C>>。",
				"		*/",
				"		<<V>>,",
			};

			string[] t_template_footer = new string[]{
				"	}",
				"}",
				"",
			};

			BlueBack.AssetLib.SaveEnum.SaveEnumToAssetsPath(t_list,"Samples/AssetLib/Enum.cs",t_template_header,t_template_loop,t_template_loopend,t_template_footer);
		}
	}
	#endif
}

