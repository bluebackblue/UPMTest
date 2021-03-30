

/** Samples.AssetLib.CreatePackage.Editor
*/
namespace Samples.AssetLib.CreatePackage.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		[UnityEditor.MenuItem("サンプル/AssetLib/Directory/CreatePackage")]
		private static void MenuItem_Sample_AssetLib_Directory_CreatePackage()
		{
			BlueBack.AssetLib.CreatePackage.CreatePackageFromAssetsPath("Samples/AssetLib","sample.unitypackage",UnityEditor.ExportPackageOptions.Recurse);
		}
	}
	#endif
}

