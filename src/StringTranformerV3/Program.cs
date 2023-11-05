using Transformers;

ITranformerRule<string>[] rules = { new ComplexNumberModeRule(
                                        "good-boy",
                                        new NumberModRule(3, "dog"),
                                        new NumberModRule(5, "cat")),
                                    new NumberModRule(4, "muzz"),
                                    new NumberModRule(7, "guzz")};

var transformer = new StringTransformer(rules);

var input = Console.ReadLine();

Console.WriteLine(transformer.Transform(input!));