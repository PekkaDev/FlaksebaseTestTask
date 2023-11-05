using Transformers;
using StrTransformer = Transformers.StringTransformer;

namespace StringTransformer.Tests
{
    public class StringTranformerTestsV3
    {
        private StrTransformer _transformer;

        [SetUp]
        public void Setup()
        {
            ITranformerRule<string>[] rules = {
                new ComplexNumberModeRule(
                    "good-boy",
                    new NumberModRule(3, "dog"),
                    new NumberModRule(5, "cat")),
                new NumberModRule(4, "muzz"),
                new NumberModRule(7, "guzz")
            };
            _transformer = new(rules);
        }

        [TestCase("1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420")]
        public void TestTransformation(string input)
        {
            var result = _transformer.Transform(input);

            /// В примере тестового задания вместо ожидаемого "dog-muzz" при замене числа 12 
            /// выводится "fizz-muzz" что является скорее всего опечаткой.
            /// Следуя логике из тестового задания
            /// "...Если делится на 3 без остатка - заменить на "dog",..." 
            /// я изменили ожидаемый вывод при замене числа 12 с "fizz-muzz" на "dog-muzz".
            Assert.That(result, Is.EqualTo("1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz"));
        }
    }
}