namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class SecurityToken
{
    public int Id { get; set; }
    
    public string? Username { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }
}