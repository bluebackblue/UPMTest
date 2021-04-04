

/** Samples.TestLib.SpeedTester_FloatInt
*/
namespace Samples.TestLib.SpeedTester_FloatInt
{
	/** Test_Int
	*/
	public class Test_Int : BlueBack.TestLib.SpeedTester.ITest
	{
		/** list
		*/
		private int[] list;

		/** result
		*/
		private int result;

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測直前に呼び出される。
		*/
		public void OnPreTestAction()
		{
			//list
			this.list = new int[Config.MAX];
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii] = ii;
			}

			//result
			this.result = 0;
		}

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測処理。
		*/
		public void OnTestAction()
		{
			int t_total = 0;
			for(int ii=0;ii<this.list.Length;ii++){
				t_total += this.list[ii];
			}
			this.result = t_total;
		}

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測終了直後に呼び出される。

			a_delta_time		: 処理秒数。
			return			: 表示文字列。

		*/
		public string OnTestResult(float a_delta_time)
		{
			return "Test_Int : " + a_delta_time.ToString("0.000") + " : result = " + this.result.ToString();
		}
	}
}

