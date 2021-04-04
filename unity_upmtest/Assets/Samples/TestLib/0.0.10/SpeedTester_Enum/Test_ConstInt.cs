

/** Samples.TestLib.SpeedTester_Enum
*/
namespace Samples.TestLib.SpeedTester_Enum
{
	/** Test_ConstInt
	*/
	public class Test_ConstInt : BlueBack.TestLib.SpeedTester.ITest
	{
		/** ActionType
		*/
		private struct ActionType
		{
			public const int AA = 0;
			public const int AB = 1;
			public const int AC = 2;
			public const int AD = 3;
			public const int AE = 4;
			public const int AF = 5;
			public const int AG = 6;
			public const int AH = 7;
			public const int AI = 8;
			public const int AJ = 9;

			public const int BA = 10;
			public const int BB = 11;
			public const int BC = 12;
			public const int BD = 13;
			public const int BE = 14;
			public const int BF = 15;
			public const int BG = 16;
			public const int BH = 17;
			public const int BI = 18;
			public const int BJ = 19;

			public const int CA = 20;
			public const int CB = 21;
			public const int CC = 22;
			public const int CD = 23;
			public const int CE = 24;
			public const int CF = 25;
			public const int CG = 26;
			public const int CH = 27;
			public const int CI = 28;
			public const int CJ = 29;

			public const int DA = 30;
			public const int DB = 31;
			public const int DC = 32;
			public const int DD = 33;
			public const int DE = 34;
			public const int DF = 35;
			public const int DG = 36;
			public const int DH = 37;
			public const int DI = 38;
			public const int DJ = 39;

			public const int MAX = 40;
		}

		/** indexlist
		*/
		private int[] indexlist = new int[Config.MAX];
		
		/** result
		*/
		private int result;

		/** [BlueBack.TestLib.SpeedTester.ITest.PreTest]計測直前に呼び出される。
		*/
		public void OnPreTestAction()
		{
			for(int ii=0;ii<this.indexlist.Length;ii++){
				this.indexlist[ii] = UnityEngine.Random.Range(0,ActionType.MAX);
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

