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
			Assert.That( "--------------------", Scores(0) );
		}
		
		[Test()]
		public void ASheetWithOneHitScoresOne() 
		{
			Assert.That( "1-------------------", Scores(1) );
		}
		[Test()]
		public void CanScoreOpenFrames()
		{
			Assert.That( "22222222222222222222", Scores(40) );
		}
		[Test()]
		public void CanScoreSpareAtBeginning()
		{
			Assert.That( "1/------------------", Scores(10) );
		}
		[Test()]
		public void SpareCountTheFollowingHitInHisScore()
		{
			Assert.That( "1/1-----------------", Scores(12) );
		}
		[Test()]
		public void CanScoreSpareAtTheEnd() 
		{
			Assert.That( "------------------1/2", Scores(12) );
		}	
		[Test()]
		public void CanScoreStrikeAtTheBeginning()
		{
			Assert.That( "X------------------", Scores(10) );
		}
		[Test()]
		public void StrikeCountTheTwoFollowingHitsInIsScore()
		{
			Assert.That( "X12----------------", Scores(16) );
		}
		[Test()]
		public void CanScoreStrikeAtTheEnd() 
		{
			Assert.That( "------------------X12", Scores(13) );
		}
			
		[Test()]
		public void TheKillingExamples() 
		{
			Assert.That("XXXXXXXXXXXX", Scores(300) );
			Assert.That("1/XX9/-5X--X4/5/X", Scores(149) );
			Assert.That("X6-8/459/8--88/9-8/6", Scores(123) );
		}
		
		
		
		private Constraint Scores(int expected)
		{
			return new ScoreConstraint(expected);
		}
		
	}
	
	public class ScoreConstraint:Constraint
	{
		private int expected;
		private Sheet sheetUnderTest;
		public ScoreConstraint(int expected)
		{
			this.expected = expected;
		}
		public override bool Matches(Object actual)
		{
			this.sheetUnderTest = Sheet.withHits((String) actual);
			return this.sheetUnderTest.Score() == this.expected;
		}
		public override void WriteDescriptionTo(MessageWriter writer)
		{
			writer.WriteExpectedValue(this.expected);
		}
		public override void WriteActualValueTo(MessageWriter writer)
		{
			writer.WriteActualValue(this.sheetUnderTest.Score());
		}
		
	}
	
	
	
	
	
}

