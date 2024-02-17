using Spix.Domain.Abstraction;
using Spix.Domain.Users.Rules;

namespace Spix.Domain.Users;

public class UserAttributes : ValueObjects
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public UserLanguage Language { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public UserAttributes(string firstName,
        string lastName,
         UserLanguage language,
        DateTime birthDate,
        string country,
        string city)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        Language = language;
        SetBirthDate(birthDate);
        SetCountry(country);
        SetCity(city);
    }

    public void SetFirstName(string firstName)
    {
        i 
        FirstName = firstName;
    }
    public void SetLastName(string lastName)
    {
         
        LastName = lastName;
    }

    public void SetBirthDate(DateTime birthDate)
    {
        CheckRule(new BirthdateCannotBeInFutureRule(birthDate));
        BirthDate = birthDate;

    }

    public void SetCountry(string country)
    {
        Country = country;
    }

    public void SetCity(string city)
    {
        City = city;
    }

}
