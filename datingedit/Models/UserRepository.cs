using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace datingedit.Models
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool GetUser(string navn, string adgangskode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM UserProfiles WHERE Navn = @Navn AND Adgangskode = @Adgangskode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Navn", navn);
                    command.Parameters.AddWithValue("@Adgangskode", adgangskode);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Ensures we're actually on a row
                            {
                                // Now you can safely access the data
                                UserProfile userprofile = new UserProfile()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                    Navn = reader.GetString(reader.GetOrdinal("Navn")),
                                    Adgangskode = reader.GetString(reader.GetOrdinal("Adgangskode")),
                                };
                                Console.WriteLine(userprofile.Id);
                                return true; // Assuming you want to return true if at least one user is found
                            }
                        }
                        return false; // Return false if no rows are found
                    }
                }
            }
        }

        public UserProfile GetUserProfile(string navn, string adgangskode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM UserProfiles WHERE Navn = @Navn AND Adgangskode = @Adgangskode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Navn", navn);
                    command.Parameters.AddWithValue("@Adgangskode", adgangskode);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) // Ensures we're actually on a row
                            {
                                // Now you can safely access the data
                                UserProfile userprofile = new UserProfile()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                    Navn = reader.GetString(reader.GetOrdinal("Navn")),
                                    Adgangskode = reader.GetString(reader.GetOrdinal("Adgangskode")),
                                };
                                return userprofile;
                            }
                        }
                        return new UserProfile();
                    }
                }
            }
        }

        public UserProfile GetUserProfileById(string userProfileId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT UserProfileId, Navn, Postnummer, Fødselsdag, Køn, Adgangskode FROM UserProfiles WHERE UserProfileId = @UserProfileId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserProfileId", userProfileId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Checks if there are any rows to read
                        {
                            // Creates and returns a UserProfile object populated with data from the database
                            return new UserProfile
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                Navn = reader.GetString(reader.GetOrdinal("Navn")),
                                Postnummer = reader.GetString(reader.GetOrdinal("Postnummer")),
                                Fødselsdag = reader.GetDateTime(reader.GetOrdinal("Fødselsdag")),
                                Køn = reader.GetString(reader.GetOrdinal("Køn")),
                                Adgangskode = reader.GetString(reader.GetOrdinal("Adgangskode"))
                            };
                        }
                    }
                }
            }
            return null; // Return null to indicate that the user profile was not found
        }



    }
}
