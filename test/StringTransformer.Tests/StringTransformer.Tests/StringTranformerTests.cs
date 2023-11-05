using Transformers;
using StrTransformer = Transformers.StringTransformer;

namespace StringTransformer.Tests
{
    public class StringTranformerTests
    {
        private StrTransformer _transformer;

        [SetUp]
        public void Setup()
        {
            ITranformerRule<string>[] rules = {
                new NumberModRule(3, "fizz"),
                new NumberModRule(5, "buzz")
            };
            _transformer = new(rules);
        }

        [TestCase("1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15")]
        public void TestTransformation(string input)
        {
            var result = _transformer.Transform(input);

            Assert.That(result, Is.EqualTo("1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizz-buzz"));
        }
    }
}