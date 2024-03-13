namespace WebApi.Services;

using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Models;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Username = "test", Password = "test" }
    };

    // private readonly IJwtUtils _jwtUtils;

    // public UserService(IJwtUtils jwtUtils)
    // {
    //     _jwtUtils = jwtUtils;
    // }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        // var token = _jwtUtils.GenerateJwtToken(user);

        var token = "";

        return new AuthenticateResponse(user, token);
    }


}