
namespace IdentityService.Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler 
        : ICommandHandler<UpdateAccountCommand, UpdateAccountResult>
    {
        public async Task<UpdateAccountResult> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            return new UpdateAccountResult(true);
        }
    }
}
