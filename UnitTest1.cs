using Lab2Solution;

namespace Lab4Test
{
    public class Tests
    {
        IBusinessLogic ibl;
        [SetUp]
        public void Setup()
        {
            ibl = new BusinessLogic();
        }

        [Test]
        public void AddEntryTest()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.NoError);
        }
    }
}