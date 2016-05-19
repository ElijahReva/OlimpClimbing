using System.Collections;
using System.Linq;
using NUnit.Framework;
using OlimClimbing.Phones;

namespace Phones.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [SetUp]
        public void Init()
        {

        }

        //[Test(Description = "Test cases for digital tree")]
        //[TestCaseSource(typeof(DigitalCasesFactory),nameof(DigitalCasesFactory.TestCases))]
        //public bool AssertDigitalTree(string[] phones)
        //{
        //    var tree = new Program.DigitalTree();
        //    return phones.All(phone => tree.Add(phone));
        //}
    }

    public static class DigitalCasesFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData((object)new string[] { "911", "97625999", "91125426" }).Returns(false);
                yield return new TestCaseData((object)new string[] {"1", "23", "4", "4", "234"}).Returns(false);
                yield return new TestCaseData((object)new string[] {"123", "124", "12"}).Returns(false);
                yield return new TestCaseData((object)new string[] {"123", "124", "13"}).Returns(true);
            }
        }
    }
}
