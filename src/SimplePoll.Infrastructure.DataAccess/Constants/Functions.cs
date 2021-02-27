namespace SimplePoll.Infrastructure.DataAccess.Constants
{
	public static class Functions
	{
		public static class UserRepository
		{
			public const string GetById = "public.users_get_by_id";
			public const string GetByEmail = "public.users_get_by_email";
			public const string Add = "public.users_add";
			public const string Update = "public.users_update";
		}

		public static class PollRepository
		{
			public const string Create = "public.polls_create";
			public const string Update = "public.polls_update";
			public const string GetById = "public.polls_get_by_id";
			public const string GetAll = "public.polls_get_all";
		}

		public static class PollAnswerRepository
		{
			public const string Add = "public.poll_answers_add";
			public const string GetById = "public.poll_answers_get_by_id";
			public const string GetByPollId = "public.poll_answers_get_by_poll_id";
		}
	}
}