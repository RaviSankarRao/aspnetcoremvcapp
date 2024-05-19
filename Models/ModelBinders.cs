namespace aspnetcoremvcapp.Models
{
    public static class ModelBinders
    {
        // Prevent over-posting
        // Allow only those properties as part of post body which you want to modify 
        public const string MovieCreate = "Id,Title,ReleaseDate,Genre,Price";
        public const string MovieUpdate = "Id,Title,ReleaseDate,Genre,Price";
    }
}
