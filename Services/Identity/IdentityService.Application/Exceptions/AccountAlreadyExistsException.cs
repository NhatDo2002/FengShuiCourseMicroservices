namespace IdentityService.Application.Exceptions
{
    public class AccountAlreadyExistsException : InternalServerException
    {
        public AccountAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
