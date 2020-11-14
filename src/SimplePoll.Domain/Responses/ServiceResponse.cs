namespace SimplePoll.Domain.Responses
{
	public class ServiceResponse
	{
		public bool Successful { get; }
		public string ErrorMessage { get; }

		public ServiceResponse(bool successful, string errorMessage) => (Successful, ErrorMessage) = (successful, errorMessage);

		public static ServiceResponse Success() => new ServiceResponse(true, null);
		public static ServiceResponse Error(string message = null) => new ServiceResponse(false, message);
	}

	public class ServiceResponse<T> : ServiceResponse
	{
		public T Data { get; }

		public ServiceResponse(bool successful, T data, string errorMessage) : base(successful, errorMessage) => Data = data;
		
		public static ServiceResponse<T> Success(T data = default) => new ServiceResponse<T>(true, data, null);
		public static ServiceResponse<T> Error(string message = null, T data = default) => new ServiceResponse<T>(false, data, message);
	}
}