using Transformers;
using StrTransformer = Transformers.StringTransformer;

namespace StringTransformer.Tests
{
    public class StringTranformerTestsV2
    {
        private StrTransformer _transformer;

        [SetUp]
        public void Setup()
        {
            ITranformerRule<string>[] rules = {
                new NumberModRule(3, "fizz"),
                new NumberModRule(5, "buzz"),
                new NumberModRule(4, "muzz"),
                new NumberModRule(7, "guzz")
            };
            _transformer = new(rules);
        }

        [TestCase("1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420")]
        public void TestTransformation(string input)
        {
            var result = _transformer.Transform(input);

            Assert.That(result, Is.EqualTo("1, 2, fizz, muzz, buzz, fizz, guzz, muzz, fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, fizz-buzz-muzz-guzz"));
        }
    }
}