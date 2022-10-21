using Lab2Solution;
using Npgsql;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace Lab4Test
{
    public class Tests
    {
        IBusinessLogic ibl;
        public ObservableCollection<Entry> entries;
       

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

            ibl.DeleteEntry(1);
        }

        [Test]
        public void AddEntryInvalidClueTest()
        {
            String clue = "Most depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed major";
            String answer = "CS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidClueLength);
        }

        [Test]
        public void AddEntryNullClueTest()
        {
            String clue = null;
            String answer = "CS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidClueLength);
        }

        [Test]
        public void AddEntryInvalidAnswerTest()
        {
            String clue = "Most depressed major";
            String answer = "CSCSCSCSCSCSCSCSCSCSCS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidAnswerLength);
        }

        [Test]
        public void AddEntryNullAnswerTest()
        {
            String clue = "Most depressed major";
            String answer = null;
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidAnswerLength);
        }

        [Test]
        public void AddEntryDifficultyExceedsMaxTest()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 3;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDifficulty);
        }

        [Test]
        public void AddEntryNegativeDifficultyTest()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = -1;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDifficulty);
        }

        [Test]
        public void AddEntryInvalidDate()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 2;
            String date = "13-200-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDate);
        }


        [Test]
        public void EditEntryTest()
        {
            ibl.AddEntry("Most depressed major", "CS", 2, "10-20-2022");

            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.EditEntry(clue, answer, difficulty, date, 1), EntryEditError.NoError);

            ibl.DeleteEntry(1);
        }

        [Test]
        public void EditEntryInvalidClueTest()
        {
            String clue = "Most depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed majorMost depressed major";
            String answer = "Comp sci";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.EditEntry(clue, answer, difficulty, date, 1), EntryEditError.InvalidFieldError);
        }

        [Test]
        public void EditEntryNullClueTest()
        {
            String clue = null;
            String answer = "CS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.EditEntry(clue, answer, difficulty, date, 1), EntryEditError.InvalidFieldError);
        }

        [Test]
        public void EditEntryInvalidAnswerTest()
        {
            String clue = "Most depressed major";
            String answer = "CSCSCSCSCSCSCSCSCSCSCS";
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.EditEntry(clue, answer, difficulty, date, 1), EntryEditError.InvalidFieldError);
        }

        [Test]
        public void EditEntryNullAnswerTest()
        {
            String clue = "Most depressed major";
            String answer = null;
            int difficulty = 2;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidAnswerLength);
        }

        [Test]
        public void EditEntryDifficultyExceedsMaxTest()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 3;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDifficulty);
        }

        [Test]
        public void EditEntryNegativeDifficultyTest()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = -1;
            String date = "10-20-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDifficulty);
        }

        [Test]
        public void EditEntryInvalidDate()
        {
            String clue = "Most depressed major";
            String answer = "CS";
            int difficulty = 2;
            String date = "13-200-2022";

            Assert.AreEqual(ibl.AddEntry(clue, answer, difficulty, date), InvalidFieldError.InvalidDate);
        }

        [Test]
        public void DeleteEntryTest()
        {
            ibl.AddEntry("Most depressed major", "CS", 2, "10-20-2022");
            Assert.AreEqual(ibl.DeleteEntry(1), EntryDeletionError.NoError);
        }

        [Test]
        public void DeleteEntryInvalidIdTest()
        {
            Assert.AreEqual(ibl.DeleteEntry(1), EntryDeletionError.EntryNotFound);
        }

        [Test]
        public void GetEntriesTest()
        {
            ibl.AddEntry("Most depressed major", "CS", 2, "10-20-2022");
            int count = ibl.GetEntries().Count();
            Assert.AreEqual(count, 1);
            ibl.DeleteEntry(1);
        }
    }
}