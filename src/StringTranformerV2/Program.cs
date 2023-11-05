using Transformers;

ITranformerRule<string>[] rules = { new NumberModRule(3, "fizz"),
                                    new NumberModRule(5, "buzz"),
                                    new NumberModRule(4, "muzz"),
                                    new NumberModRule(7, "guzz")};

var transformer = new StringTransformer(rules);

var input = Console.ReadLine();

Console.WriteLine(transformer.Transform(input!));