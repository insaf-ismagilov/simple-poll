using System.Threading.Tasks;
using SimplePoll.Application.Models.Requests;
using SimplePoll.Domain.Responses;

namespace SimplePoll.Application.Contracts
{
	public interface IIdentityService
	{
		Task<ServiceResponse<AuthenticateResult>> SignInAsync(SignInRequest request);
		Task<ServiceResponse> SignUpAsync(SignUpRequest request);
	}
}