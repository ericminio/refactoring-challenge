using System;
namespace BowlingKata
{
	public class Sheet
	{
		private String hits;
		
		public static Sheet withHits(String hits)
		{
			Sheet sheet = new Sheet();
			sheet.hits = hits;
			return sheet;
		}
		
		private Char Hit(int index)
		{
			return this.hits[index];
		}
		
		private bool IsEmpty(Char hit)
		{
			return hit == '-';
		}
		
		private bool IsSpare(Char hit)
		{
			return hit == '/';
		}
		
		private bool IsStrike(Char hit)
		{
			return hit == 'X';
		}
		
		private int ValueOf(int i)
		{
			if (IsEmpty(Hit(i)))
			{
				return 0;
			}
			if (IsSpare(Hit(i)))
			{
				return 10 - ValueOf(i-1);
			}
			if (IsStrike(Hit(i)))
			{
				return 10;
			}
			return int.Parse(Hit(i).ToString());
		}
		
		private int Last()
		{
			return hits.Length-1;
		}
		private int BeforeLast()
		{
			return Last() - 1;
		}
		private int Penultian()
		{
			return BeforeLast() - 1;
		}
		private int Begin()
		{
			return 0;
		}
		private int End()
		{
			if (IsSpare(Hit(BeforeLast())))
			{
				return BeforeLast();
			}
			if (IsStrike(Hit(Penultian())))
			{
				return Penultian();
			}
			return Last();
		}
		
		private int ScoreOf(int i)
		{
			if (IsSpare(Hit(i)))
			{
				return ValueOf(i) + ValueOf(i + 1);
			}
			if (IsStrike(Hit(i)))
			{
				return ValueOf(i) + ValueOf(i + 1) + ValueOf(i + 2);
			}
			return ValueOf(i);
		}

		public int Score()
		{
			int score = 0;
			for (int i=Begin(); i<=End(); i++)
			{
				score += ScoreOf(i);
			}
			return score;
		}
	}
}

