 namespace Spix.Api.Core;
 
public static class ApiRoutes
{
    public static class Spixer
    {
        public const string CreateSpixer = "spixers";
        public const string LikeSpixer = "spixers/like";
        public const string UnlikeSpixer = "spixers/unlike";
        public const string DeleteSpixer = "spixers/{spixerId}";
        public const string GetSpixerDetails = "spixers/{spixerId}";    
    }

    public static class Authentication
    {
        public const string Register = "authentication/register";    
    }
}
