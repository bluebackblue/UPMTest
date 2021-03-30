

/** Samples.TestLib.FloatIntSpeedTest
*/
namespace Samples.TestLib.FloatIntSpeedTest
{
	/** Test_Float
	*/
	public class Test_Float : BlueBack.TestLib.SpeedTester.ITest
	{
		/** list
		*/
		private float[] list;

		/** result
		*/
		private float result;

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測直前に呼び出される。
		*/
		public void OnPreTestAction()
		{
			//list
			this.list = new float[Config.MAX];
			for(int ii=0;ii<this.list.Length;ii++){
				this.list[ii] = ii;
			}

			//result
			this.result = 0.0f;
		}

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測処理。
		*/
		public void OnTestAction()
		{
			float t_total = 0.0f;
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
			return "Test_Float : " + a_delta_time.ToString("0.000") + " : result = " + this.result.ToString("0.0");
		}
	}
}

