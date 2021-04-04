

/** Samples.AssetLib.EncodeCheck.Editor
*/
namespace Samples.AssetLib.EncodeCheck.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** �G���R�[�h�B
		*/
		[UnityEditor.MenuItem("�T���v��/AssetLib/Script/EncodeCheck")]
		private static void MenuItem_EncodeCheck()
		{
			string[] t_namelist = new string[]{
				"^sjis\\.txt$",

				"^utf8\\.txt$",
				"^utf8bom\\.txt$",

				"^utf16lebom\\.txt$",
				"^utf16bebom\\.txt$",

				"^utf32lebom\\.txt$",
				"^utf32bebom\\.txt$",
			};

			for(int ii=0;ii<t_namelist.Length;ii++){
				string t_path = BlueBack.AssetLib.FindFile.FindFileFistFromAssetsPath("",".*",t_namelist[ii]);
				string t_text = BlueBack.AssetLib.LoadText.LoadTextFromAssetsPath(t_path);
				UnityEngine.Debug.Log(t_path + "\n" + t_text);
			}
		}
	}
	#endif
}

