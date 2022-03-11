namespace Monkey.Parser;

public enum Precedence
{
    Blank,
    Lowest,
    Equals, // ==
    LessGreater, // > or <
    Sum, // +
    Product, // *
    Prefix, // -x or x-
    Call // function(x)
}