using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth
	{

	class AuthResponce
		{
		public string Message { get; protected set; }
		public int ID { get; protected set; }

		public AuthResponce (int _id, string _message)
			{
			ID = _id;
			Message = _message;
			}
		}


	public class UserEntry
		{
		[JsonPropertyName("login")]
		public string Login { get; protected set; }

		[JsonPropertyName("password")]
		public string Password { get; protected set; }

		[JsonPropertyName("rule")]
		public string Rule { get; protected set; }

		public UserEntry (string _login, string _password)
			{
			Login = _login;
			Password = _password;
			}
		}

	static class Auth
		{
		static string fileName = "./users.json";
		static JsonSerializerOptions options = new JsonSerializerOptions() { AllowTrailingCommas = true, IgnoreNullValues = false };

		public static AuthResponce ruthUser (string login, string password, string repeat)
			{
			if ( password != repeat )
				return new AuthResponce(1, "Passwords don't match");
			UserEntry user = new UserEntry(login, password);

			List<UserEntry> users = readAllUsers();
			if ( users.Count == 0 || !users.Contains(user) )
				return new AuthResponce(2, "User doesn't exists");

			return new AuthResponce(0, "Successful logged");
			}


		public static AuthResponce registerUser (UserEntry user)
			{
			List<UserEntry> users = readAllUsers();
			if ( users.Contains(user) )
				return new AuthResponce(3, "User already in system");

			//TODO: add field checks
			users.Append(user);
			writeUsers(users);
			return new AuthResponce(0, "Successful registered");
			}

		public static List<UserEntry> readAllUsers ()
			{
			if ( !File.Exists(fileName) )
				File.Create(fileName).Close();
			string json = File.ReadAllText(fileName);
			List<UserEntry> users = JsonSerializer.Deserialize<List<UserEntry>>(json, options);
			if ( users == null )
				{
				users = new List<UserEntry>();
				JsonSerializer.Serialize<List<UserEntry>>(users, options);
				}
			return users;
			}

		public static void writeUsers (List<UserEntry> users)
			{
			if ( !File.Exists(fileName) )
				File.Create(fileName).Close();
			JsonSerializer.Serialize<List<UserEntry>>(users, options);
			}
		}
	}
