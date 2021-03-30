

/** Samples.AssetLib.Directory.Editor
*/
namespace Samples.AssetLib.Directory.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/CreateDirectory")]
		private static void MenuItem_Sample_AssetLib_Directory_CreateDirectory()
		{
			BlueBack.AssetLib.CreateDirectory.CreateDirectoryToAssetsPath("Samples/AssetLib/NewDirectory");
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/DeleteDirectory")]
		private static void MenuItem_Sample_AssetLib_Directory_DeleteDirectory()
		{
			BlueBack.AssetLib.DeleteDirectory.DeleteDirectoryFromAssetsPath("Samples/AssetLib/NewDirectory");
			BlueBack.AssetLib.DeleteFile.DeleteFileFromAssetsPath("Samples/AssetLib/NewDirectory.meta");
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}

		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/DirectoryNameList")]
		private static void MenuItem_Sample_AssetLib_Directory_DirectoryNameList()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.DorectoryNameList.CreateAllDirectoryNameListFromAssetsPath("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}

		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/FileNameList")]
		private static void MenuItem_Sample_AssetLib_Directory_FileNameList()
		{
			System.Collections.Generic.List<string> t_list = BlueBack.AssetLib.FileNameList.CreateAllFileNameListFromAssetsPath("");
			for(int ii=0;ii<t_list.Count;ii++){
				UnityEngine.Debug.Log(t_list[ii]);
			}
		}
	}
	#endif
}

