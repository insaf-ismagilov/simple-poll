using System;
using System.Reflection;
using System.Threading.Tasks;
using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace SimplePoll.Migrations
{
	internal static class Program
	{
		private const string TablesPath = "SimplePoll.Migrations.Tables.";
		private const string IndexesPath = "SimplePoll.Migrations.Indexes.";
		private const string FunctionsPath = "SimplePoll.Migrations.Functions.";
		private const string PatchesPath = "SimplePoll.Migrations.Patches.";
		private const string DataPath = "SimplePoll.Migrations.Data.";

		private static int Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables()
				.Build();

			var connectionSettings = new ConnectionSettings();
			configuration.GetSection(nameof(ConnectionSettings)).Bind(connectionSettings);

			if (!RepeatTryWaitConnection(connectionSettings))
			{
				Console.WriteLine("Connection to the host has failed.");
				return -1;
			}

			if (bool.TryParse(configuration.GetSection("DropDatabase").Value, out var dropDb) && dropDb)
			{
				DropDatabase(connectionSettings);
			}
			
			var connectionString = connectionSettings.DatabaseConnectionString;

			EnsureDatabase.For.PostgresqlDatabase(connectionString);

			var upgrader =
				DeployChanges.To
					.PostgresqlDatabase(connectionString)
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(TablesPath),
						new SqlScriptOptions {ScriptType = ScriptType.RunOnce, RunGroupOrder = 1})
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(IndexesPath),
						new SqlScriptOptions {ScriptType = ScriptType.RunOnce, RunGroupOrder = 2})
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(PatchesPath),
						new SqlScriptOptions {ScriptType = ScriptType.RunOnce, RunGroupOrder = 3})
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(FunctionsPath),
						new SqlScriptOptions {ScriptType = ScriptType.RunAlways, RunGroupOrder = 4})
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(DataPath),
						new SqlScriptOptions {ScriptType = ScriptType.RunOnce, RunGroupOrder = 5})
					.LogToConsole()
					.Build();

			var result = upgrader.PerformUpgrade();

			if (!result.Successful)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(result.Error);
				Console.ResetColor();
#if DEBUG
				Console.ReadLine();
#endif
				return -1;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Success!");
			Console.ResetColor();
			return 0;
		}

		private static void DropDatabase(ConnectionSettings connectionSettings)
		{
			Console.WriteLine("Dropping database...");
			var defaultDbConnectionString = connectionSettings.DefaultDatabaseConnectionString;

			using var con = new NpgsqlConnection(defaultDbConnectionString);
			con.Open();

			var dropCommand = new NpgsqlCommand
			{
				Connection = con,
				CommandText = $@"SELECT pg_terminate_backend(pg_stat_activity.pid)
								FROM pg_stat_activity
								WHERE pg_stat_activity.datname = '{connectionSettings.Database}';
								
								drop database if exists ""{connectionSettings.Database}"";"
			};
			dropCommand.ExecuteNonQuery();
			Console.WriteLine("Database was successfully dropped.");
		}

		private static bool TryWaitConnection(ConnectionSettings connectionSettings)
		{
			Console.WriteLine("Trying to connect to the host...");
			
			var hostConnectionString = connectionSettings.HostConnectionString;

			try
			{
				using var con = new NpgsqlConnection(hostConnectionString);
				con.Open();
				Console.WriteLine("Succesful connection to the host has been established.");
				return true;
			}
			catch
			{
				return false;
			}
		}

		private static bool RepeatTryWaitConnection(ConnectionSettings connectionSettings)
		{
			const int tryCount = 2;

			for (var i = 0; i < tryCount; i++)
			{
				if (TryWaitConnection(connectionSettings))
					return true;

				Task.Delay(TimeSpan.FromSeconds(connectionSettings.WaitTimeoutSeconds)).Wait();
			}

			return false;
		}
	}
}