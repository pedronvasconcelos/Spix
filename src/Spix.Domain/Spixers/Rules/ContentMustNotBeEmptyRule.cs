
using Spix.Domain.Abstraction;

namespace Spix.Domain.Spixers.Rules;

public class ContentMustNotBeEmptyRule : IBusinessRule
{
    private readonly string _content;

    public ContentMustNotBeEmptyRule(string content)
    {
        _content = content;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_content);

    public string Message => "Content cannot be empty.";
}

public class ContentMustNotExceedMaxLengthRule : IBusinessRule
{
    private const int MaxLength = 280;
    private readonly string _content;

    public ContentMustNotExceedMaxLengthRule(string content)
    {
        _content = content;
    }

    public bool IsBroken() => _content.Length > MaxLength;

    public string Message => $"Content exceeds maximum length of {MaxLength} characters.";
}