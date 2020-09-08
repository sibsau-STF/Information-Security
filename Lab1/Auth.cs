using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth
	{

	public class AuthResponse
		{
		public string Message { get; protected set; }

		public int ID { get; protected set; }

		public UserEntry UserData { get; protected set; }

		public AuthResponse (int id, string message, UserEntry user)
			{
			ID = id;
			Message = message;
			UserData = user;
			}

		public AuthResponse (int id, string message) : this(id, message, null)
			{
			}

		}


	public class UserEntry
		{
		[JsonPropertyName("login")]
		public string Login { get;  set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }

		[JsonPropertyName("banned")]
		public bool IsBanned { get;  set; }

		[JsonPropertyName("restrict")]
		public bool RestrictPassword { get;  set; }

		[JsonPropertyName("rule")] // Admin, User
		public string Rule { get;  set; }

		public UserEntry ()
			{
			Login = "blank";
			Password = "blank";
			Rule = "blank";
			IsBanned = false;
			RestrictPassword = false;

			}
		public UserEntry (string login, string password, string rule, bool banned, bool restrict)
			{
			Login = login;
			Password = password;
			Rule = rule;
			IsBanned = banned;
			RestrictPassword = restrict;
			}

		public UserEntry (string login, string password, string rule="User"): this(login, password, rule, false, false)
			{
			}
		}

	public abstract class BaseAuth
		{
		public abstract AuthResponse authUser (string login, string password);

		public abstract AuthResponse registerUser (UserEntry user);

		public abstract AuthResponse changeUser (UserEntry newUser);

		public abstract List<UserEntry> readAllUsers ();

		public abstract void writeUsers (List<UserEntry> users);
		}

	public class JsonAuth: BaseAuth
		{
		public static BaseAuth Instance { get; protected set; }
		string fileName = "./users.json";
		JsonSerializerOptions options =
			new JsonSerializerOptions() { 
				AllowTrailingCommas = true,
				IgnoreNullValues = false,
				WriteIndented = true,
				};

		public JsonAuth (string filePath)
			{
			if ( filePath == "" )
				throw new ArgumentException("Specified empty file path");
			fileName = filePath;
			Instance = this;
			}

		public override AuthResponse authUser (string login, string password)
			{
			UserEntry user = new UserEntry(login, password);

			List<UserEntry> users = readAllUsers();
			UserEntry userData = users.Find(usr => usr.Login == user.Login);
			if ( userData == null )
				return new AuthResponse(2, "User doesn't exists");
			if ( userData.Password != password )
				return new AuthResponse(1, "Wrong password");

			return new AuthResponse(0, "Successful logged", userData);
			}

		public override AuthResponse registerUser (UserEntry user)
			{
			List<UserEntry> users = readAllUsers();
			if ( users.Any(usr => usr.Login == user.Login ))
				return new AuthResponse(3, "User already in system");

			//TODO: add field checks
			users.Append(user);
			writeUsers(users);
			return new AuthResponse(0, "Successful registered");
			}

		public override AuthResponse changeUser (UserEntry newUser)
			{
			List<UserEntry> users = readAllUsers();
			var userData = users.Find(usr => usr.Login == newUser.Login);
			if (userData == null)
				return new AuthResponse(2, "User doesn't exists");

			users.Remove(userData);
			users.Add(newUser);
			writeUsers(users);
			return new AuthResponse(0, "Successfuly changed data");
			}

		public override List<UserEntry> readAllUsers ()
			{
			if ( !File.Exists(fileName) )
				File.Create(fileName).Close();
			string json = File.ReadAllText(fileName);
			List<UserEntry> users;
			if ( json == "")
				{
				users = new List<UserEntry>();
				users.Add(new UserEntry("Admin", "", "Admin"));
				json = JsonSerializer.Serialize<List<UserEntry>>(users, options);
				File.WriteAllText(fileName, json);
				}
			else
				{
				users = JsonSerializer.Deserialize<List<UserEntry>>(json, options);
				}
			return users;
			}

		public override void writeUsers (List<UserEntry> users)
			{
			if ( !File.Exists(fileName) )
				File.Create(fileName).Close();
			string json = JsonSerializer.Serialize<List<UserEntry>>(users, options);
			File.WriteAllText(fileName, json);
			}
		}
	}
