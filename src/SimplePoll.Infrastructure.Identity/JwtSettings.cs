﻿namespace SimplePoll.Infrastructure.Authorization
{
	public class JwtSettings
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string SigningKey { get; set; }
		public int LifetimeSeconds { get; set; }
	}
}