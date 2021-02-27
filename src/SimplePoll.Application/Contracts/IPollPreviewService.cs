using System.Threading.Tasks;
using SimplePoll.Application.Models.Responses.Polls;

namespace SimplePoll.Application.Contracts
{
	public interface IPollPreviewService
	{
		Task<PollPreview> GetByIdAsync(int id);
	}
}