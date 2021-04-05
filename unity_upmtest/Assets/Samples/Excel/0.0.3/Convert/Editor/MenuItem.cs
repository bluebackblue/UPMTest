

/** Samples.Excel.Convert.Editor
*/
namespace Samples.Excel.Convert.Editor
{
	/** MenuItem
	*/
	#if(UNITY_EDITOR)
	public class MenuItem
	{
		/** テスト。
		*/
		[UnityEditor.MenuItem("サンプル/Excel/Convert/Test")]
		private static void MenuItem_Test()
		{
			string t_path = BlueBack.AssetLib.FindFile.FindFileFistFromAssetsPath("","","^excel\\.xlsx$");

			BlueBack.Excel.Excel t_excel = new BlueBack.Excel.Excel(new BlueBack.Excel.EDR.Engine());
			t_excel.ReadOpen(t_path);
			BlueBack.JsonItem.JsonItem t_excel_jsonitem = BlueBack.Excel.ConvertToJson.ConvertToJson.Convert(t_excel);
			t_excel.Close();

			foreach(string t_sheetname in t_excel_jsonitem.GetAssociativeKeyList()){
				UnityEngine.Debug.Log("sheetname = " + t_sheetname);

				BlueBack.JsonItem.JsonItem t_sheet_jsonitem = t_excel_jsonitem.GetItem(t_sheetname);
				int t_line_max = t_sheet_jsonitem.GetListMax();
				UnityEngine.Debug.Log("line_max = " + t_line_max.ToString());

				for(int ii=0;ii<t_line_max;ii++){
					BlueBack.JsonItem.JsonItem t_line_jsonitem = t_sheet_jsonitem.GetItem(ii);
					UnityEngine.Debug.Log(t_line_jsonitem.ConvertToJsonString());
				}
			}
		}
	}
	#endif
}

