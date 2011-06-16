using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.SyntaxHelpers;
namespace BowlingKata
{
	
	[TestFixture()]
	public class ScoreTest:AssertionHelper
	{
		[Test()]
		public void EmptySheetAsAScoreOfZero ()
		{			
			ScoreAssert( "--------------------", 0 );
		}
		
		private void ScoreAssert(String hits, int score)
		{
			Assert.That( ScoreOf(Sheet.withHits(hits)), Is.EqualTo(score) );
		}
		
		private int ScoreOf(Sheet sheet)
		{
			return sheet.Score();
		}
		
		[Test()]
		public void ASheetWithOneHitScoresOne() 
		{
			ScoreAssert( "1-------------------", 1 );
		}
		[Test()]
		public void CanScoreOpenFrames()
		{
			ScoreAssert( "22222222222222222222", 40 );
		}
		[Test()]
		public void CanScoreSpareAtBeginning()
		{
			ScoreAssert( "1/------------------", 10 );
		}
		[Test()]
		public void SpareCountTheFollowingHitInHisScore()
		{
			ScoreAssert( "1/1-----------------", 12 );
		}
		[Test()]
		public void CanScoreSpareAtTheEnd() 
		{
			ScoreAssert( "------------------1/2", 12 );
		}	
		[Test()]
		public void CanScoreStrikeAtTheBeginning()
		{
			ScoreAssert( "X------------------", 10 );
		}
		[Test()]
		public void StrikeCountTheTwoFollowingHitsInIsScore()
		{
			ScoreAssert( "X12----------------", 16 );
		}
		[Test()]
		public void CanScoreStrikeAtTheEnd() 
		{
			ScoreAssert( "------------------X12", 13 );
		}
			
		[Test()]
		public void TheKillingExamples() 
		{
			ScoreAssert( "XXXXXXXXXXXX", 300 );
			ScoreAssert( "1/XX9/-5X--X4/5/X", 149 );
			ScoreAssert( "X6-8/459/8--88/9-8/6", 123 );
		}
		
	}
	
}

