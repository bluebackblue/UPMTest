

/** Samples.AssetLib.CreateAssetBundle.Editor
*/
namespace Samples.AssetLib.CreateAssetBundle.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		[UnityEditor.MenuItem("サンプル/AssetLib/CreateAssetBundle")]
		private static void MenuItem_Sample_AssetLib_CreateAssetBundle()
		{
			BlueBack.AssetLib.SaveText.SaveUtf8TextToAssetsPath("xxxDATAxxx","Samples/AssetLib/data.txt",true);
			BlueBack.AssetLib.RefreshAsset.Refresh();

			UnityEditor.AssetBundleBuild[] t_list = new UnityEditor.AssetBundleBuild[]{
				new UnityEditor.AssetBundleBuild(){
					assetBundleName = "sample.assetbundle",
					assetBundleVariant = "sample",
					assetNames = new string[]{
						"Assets/Samples/AssetLib/data.txt",
					},
					addressableNames = new string[]{
						"sample",
					},
				}	
			};

			BlueBack.AssetLib.CreateAssetBundle.CreateAssetBundleToAssetsPath("Samples/AssetLib",t_list,UnityEditor.BuildAssetBundleOptions.None,UnityEditor.EditorUserBuildSettings.activeBuildTarget);
			BlueBack.AssetLib.RefreshAsset.Refresh();
		}
	}
	#endif
}

