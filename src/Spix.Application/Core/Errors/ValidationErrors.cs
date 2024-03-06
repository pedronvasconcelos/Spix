using Spix.Domain.Core.SeedOfWork;

namespace Spix.Application.Core.Errors;

internal static class ValidationErrors
{
    internal static class User
    {
        internal static Error NotFound => new Error("user_not_found", "User not found.");   
        internal static Error EmailAlreadyInUse => new Error("email_already_in_use", "Email already in use.");
        internal static Error InvalidCredentials => new Error("invalid_credentials", "Invalid credentials.");
        internal static Error InvalidEmail => new Error("invalid_email", "Invalid email.");
        internal static Error InvalidPassword => new Error("invalid_password", "Invalid password.");
        internal static Error InvalidUsername => new Error("invalid_username", "Invalid username.");
        internal static Error ErrorCreatingUser => new Error("error_creating_user", "Error creating user.");
    }
    internal static class  Spixer
    {
        internal static Error NotFound => new Error("spixer_not_found", "Spixer not found.");
        internal static Error UserCantDelete => new Error("user_cant_delete", "User not authorized to delete this spixer.");
        internal static Error AlreadyLiked => new Error("spixer_already_liked", "Spixer already liked.");   
        internal static Error NotLiked => new Error("spixer_not_liked", "Spixer not liked.");       
    }

    internal static class Database
    {
        internal static Error Generic => new Error("db_error", "Database error.");   
    }
    
}
