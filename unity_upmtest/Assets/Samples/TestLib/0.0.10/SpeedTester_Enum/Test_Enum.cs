

/** Samples.TestLib.SpeedTester_Enum
*/
namespace Samples.TestLib.SpeedTester_Enum
{
	/** Test_Enum
	*/
	public class Test_Enum : BlueBack.TestLib.SpeedTester.ITest
	{
		/** ActionType
		*/
		private enum ActionType
		{
			AA = 0,
			AB,
			AC,
			AD,
			AE,
			AF,
			AG,
			AH,
			AI,
			AJ,

			BA,
			BB,
			BC,
			BD,
			BE,
			BF,
			BG,
			BH,
			BI,
			BJ,

			CA,
			CB,
			CC,
			CD,
			CE,
			CF,
			CG,
			CH,
			CI,
			CJ,

			DA,
			DB,
			DC,
			DD,
			DE,
			DF,
			DG,
			DH,
			DI,
			DJ,

			MAX,
		}

		/** indexlist
		*/
		private ActionType[] indexlist = new ActionType[Config.MAX];
		
		/** result
		*/
		private int result;

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測直前に呼び出される。
		*/
		public void OnPreTestAction()
		{
			for(int ii=0;ii<this.indexlist.Length;ii++){
				this.indexlist[ii] = (ActionType)UnityEngine.Random.Range(0,(int)ActionType.MAX);
			}

			this.result = 0;
		}

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測処理。
		*/
		public void OnTestAction()
		{
			for(int ii=0;ii<this.indexlist.Length;ii++){
				switch(this.indexlist[ii]){
				case ActionType.AA:
				case ActionType.BA:
				case ActionType.CA:
				case ActionType.DA:
					{
						this.result += 10;
					}break;
				case ActionType.AB:
				case ActionType.BB:
				case ActionType.CB:
				case ActionType.DB:
					{
						this.result += 11;
					}break;
				case ActionType.AC:
				case ActionType.BC:
				case ActionType.CC:
				case ActionType.DC:
					{
						this.result += 12;
					}break;
				case ActionType.AD:
				case ActionType.BD:
				case ActionType.CD:
				case ActionType.DD:
					{
						this.result += 13;
					}break;
				case ActionType.AE:
				case ActionType.BE:
				case ActionType.CE:
				case ActionType.DE:
					{
						this.result += 14;
					}break;
				case ActionType.AF:
				case ActionType.BF:
				case ActionType.CF:
				case ActionType.DF:
					{
						this.result += 15;
					}break;
				case ActionType.AG:
				case ActionType.BG:
				case ActionType.CG:
				case ActionType.DG:
					{
						this.result += 16;
					}break;
				case ActionType.AH:
				case ActionType.BH:
				case ActionType.CH:
				case ActionType.DH:
					{
						this.result += 17;
					}break;
				case ActionType.AI:
				case ActionType.BI:
				case ActionType.CI:
				case ActionType.DI:
					{
						this.result += 18;
					}break;
				case ActionType.AJ:
				case ActionType.BJ:
				case ActionType.CJ:
				case ActionType.DJ:
					{
						this.result += 18;
					}break;
				}
			}
		}

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測終了直後に呼び出される。

			a_delta_time		: 処理秒数。
			return			: 表示文字列。

		*/
		public string OnTestResult(float a_delta_time)
		{
			return this.GetType().Name + " : " + a_delta_time.ToString("0.000") + " : result = " + this.result.ToString();
		}
	}
}

