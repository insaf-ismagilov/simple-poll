using System.Threading.Tasks;
using SimplePoll.Domain.Requests;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Domain.Contracts.Services
{
	public interface IIdentityService
	{
		Task<ServiceResponse<AuthenticateResult>> SignInAsync(SignInRequest request);
		Task<ServiceResponse> SignUpAsync(SignUpRequest request);
	}
}