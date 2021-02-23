using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using DbUp.Support;
using Microsoft.Extensions.Configuration;

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
				.Build();

			var connectionString = configuration.GetConnectionString("SimplePoll");

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
	}
}