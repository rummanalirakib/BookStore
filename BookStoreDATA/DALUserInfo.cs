/* ************************************************************
 * For students to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * ************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Windows;
using System.Windows.Media;

namespace BookStoreDATA
{
    public class DALUserInfo
    {
        public static int userId = 0;
        public int LogIn(string userName, string password)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select UserID from UserData where "
                    + " UserName = @UserName and Password = @Password ";
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                //int userId;

                if (cmd.ExecuteScalar() == null)
                {
                    userId = -1;
                }
                else
                    userId = (int)cmd.ExecuteScalar();
                if (userId > 0) return userId;
                else return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        public string GetFullName(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select FullName from UserData where " +
                    " UserID=@userID";
                cmd.Parameters.AddWithValue("@UserID", userID);
                conn.Open();
                string fullName;
                if (cmd.ExecuteScalar() == null)
                {
                    return "";
                }
                else
                {
                    fullName = (string)cmd.ExecuteScalar();
                }
                return fullName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return "";
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public bool SetDeliveryInformation(int userId, string city, string state, string address)
        {
            bool checkIfStringsAreEmpty = string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(address);

            if (!checkIfStringsAreEmpty)
            {
                bool stateHasDigits = state.Any(char.IsDigit);

                int stateCharCount = state.ToCharArray().Count();

                if (!stateHasDigits && stateCharCount == 2)
                { 
                    var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO DeliveryInformation VALUES(@userId, @city, @state, @address)";
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@city", city);
                        cmd.Parameters.AddWithValue("@state", state);
                        cmd.Parameters.AddWithValue("@address", address);
                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return false;
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
            
            
        }

        public bool DeleteUserDeliveryInformation(int UserID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE FROM DeliveryInformation WHERE UserID = @userID";
                cmd.Parameters.AddWithValue("@userID", UserID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return true;
        }

        public bool SetUserPaymentInformation(int userId, string cardNum, string cvv, string expDate)
        {
            bool checkIfStringsAreEmpty = string.IsNullOrWhiteSpace(cardNum) || string.IsNullOrWhiteSpace(cvv) || string.IsNullOrWhiteSpace(expDate);

            if (!checkIfStringsAreEmpty)
            {
                bool cvvDigits = cvv.All(char.IsDigit);

                bool cardDigits = cardNum.Replace(" ", "").All(char.IsDigit);

                bool expDateDigits = expDate.All(char.IsDigit);

                int cvvDigitCount = cvv.ToCharArray().Count();

                int cardDigitCount = cardNum.Replace(" ", "").ToCharArray().Count();

                int expDateCharCount = expDate.ToCharArray().Count();

                if (cvvDigits && cvvDigitCount == 3 && cardDigits && cardDigitCount == 16 && expDateDigits && expDateCharCount == 4)
                {
                    var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO PaymentInformation VALUES(@userId, @cardNum, @cvv, @expDate)";
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@cardNum", cardNum);
                        cmd.Parameters.AddWithValue("@cvv", cvv);
                        cmd.Parameters.AddWithValue("@expDate", expDate);
                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        return false;
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                    }
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }


        }

        public bool DeleteUserPaymentInformation(int UserID)
        {
            var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {
                cmd.CommandText = "DELETE FROM PaymentInformation WHERE UserID = @userID";
                cmd.Parameters.AddWithValue("@userID", UserID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return true;
        }

        public string GetDeliveryInformation(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            string selectSql = "select * from DeliveryInformation where UserID = @userID";
            SqlCommand cmd = new SqlCommand(selectSql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            string deliveryAddres = "";
            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        deliveryAddres = reader["Address"].ToString();
                        deliveryAddres += ", ";
                        deliveryAddres += reader["City"].ToString();
                        deliveryAddres += ", ";
                        deliveryAddres += reader["State"].ToString();
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return deliveryAddres;
        }
        public bool NewUser(string firstname, string lastname, string pwd)
        {
            string selectQuery = "SELECT MAX(UserID) FROM UserData"; // Query to retrieve the maximum UserID
            string insertQuery = "INSERT INTO UserData (UserID, FullName, UserName, Password, Type, Manager) VALUES (@UserID, @FullName, @UserName, @Password, @Type, @Manager)";
            int len = pwd.Length;
            // Following loop is to check firstname, lastname and password, and then update password
            if (firstname == "" || lastname == "" || pwd == "")
            {
                MessageBox.Show("Please fill in all slots");
                return false;
            }
            else if (!char.IsLetter(firstname[0]) || !char.IsLetter(lastname[0]))
            {
                MessageBox.Show("first/lastname should start with a letter");
                return false;
            }
            else if (!char.IsLetter(pwd[0]))
            {
                MessageBox.Show("A valid password should start with a letter");
                return false;
            }
            else
            {
                int j = 0;
                int k = 0;
                for (int i = 0; i < len; i++)
                {
                    char c = pwd[i];
                    if (char.IsLetter(c))
                    {
                        j++;
                    }
                    else if (char.IsDigit(c))
                    {
                        k++;
                    }
                }
                int l = j + k;
                if (l < 6)
                {
                    MessageBox.Show("A valid password needs to have at least six characters.");
                    return false;
                }
                else if (j == 0)
                {
                    MessageBox.Show("A valid password needs to have at least a letter.");
                    return false;

                }
                else if (k == 0)
                {
                    MessageBox.Show("A valid password needs to have at least a number.");
                    return false;

                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                        try
                        {
                            connection.Open();

                            // Retrieve the maximum UserID
                            object result = selectCommand.ExecuteScalar();
                            int previousUserId = Convert.ToInt32(result);

                            // Calculate the new UserID
                            int newUserId = previousUserId + 1;

                            string fullName = $"{firstname} {lastname}";
                            // Create the username from the first letter of the first name and the last name in lowercase
                            string username = $"{firstname[0]}{lastname}".ToLower();

                            // Set the parameters for the insert command
                            insertCommand.Parameters.AddWithValue("@UserID", newUserId);
                            insertCommand.Parameters.AddWithValue("@FullName", fullName);
                            insertCommand.Parameters.AddWithValue("@UserName", username);
                            insertCommand.Parameters.AddWithValue("@Password", pwd);
                            insertCommand.Parameters.AddWithValue("@Type", "RG");
                            insertCommand.Parameters.AddWithValue("@Manager", "False");

                            // Execute the insert command
                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("User created successfully with UserID #" + newUserId + "  and Username: " + username);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Failed to create user.");
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error creating user: " + ex.Message);
                            return false;
                        }
                    }

                }
            }
            return true;
        }

        public int PasswordChange(string newpwd, int x)
        {
            string updateQuery = "UPDATE UserData SET Password = @NewPassword WHERE UserId = @UserId";

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@NewPassword", newpwd);
                command.Parameters.AddWithValue("@UserId", x);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully for User #" + x);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Please try again");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message);
                }
            }
            return 1;
        }

        public bool EditUser(string firstname, string lastname, string username)
        {
            string updateQuery = "UPDATE UserData SET UserName = @UserName, FullName = @FullName WHERE UserId = @UserId";

            if (firstname == "" || lastname == "" || username == "")
            {
                MessageBox.Show("Please fill in all slots");
                return false;
            }
            else if (firstname != "" && !char.IsLetter(firstname[0]))
            {
                MessageBox.Show("Firstname should start with a letter");
                return false;
            }
            else if (lastname != "" && !char.IsLetter(lastname[0]))
            {
                MessageBox.Show("Lastname should start with a letter");
                return false;
            }
            else if (username != "" && !char.IsLetter(username[0]))
            {
                MessageBox.Show("Username should start with a letter");
                return false;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {

                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    if (userId > 0)
                    {
                        string fullName = $"{firstname} {lastname}";
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@UserId", userId);
                    }
                    else
                    {
                        MessageBox.Show("Please login before editing user info");
                        return false;
                    }
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User information updated successfully for User #" + userId);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user information. Please try again");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating user information: " + ex.Message);
                        return false;
                    }

                }

            }
        return true;
        }

        public Boolean logout()
        {
            if (userId <= 0)
            {
                MessageBox.Show("No logged in user found");
                return false;
            }
            else
            {

                MessageBox.Show("User #" + userId + " has been successfully logged out");
                userId = 0;
                return true;
            }
        }

         public string GetPaymentInformation(int userID)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            string selectSql = "select * from PaymentInformation where UserID = @userID";
            SqlCommand cmd = new SqlCommand(selectSql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            string paymentInfo = "";
            try
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paymentInfo = reader["CardNo"].ToString();
                        paymentInfo += ", ";
                        paymentInfo += reader["Cvv"].ToString();
                        paymentInfo += ", ";
                        paymentInfo += reader["ExpiryDate"].ToString();
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            return paymentInfo;
        }

        public void DeleteUser(string userName, string password)
        {
            try
            {

                string deleteQuery = "DELETE FROM UserData WHERE UserName = @UserName AND Password = @Password";

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User account deleted successfully.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. User account not deleted.", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

        public void ViewUserInfo(string userName)
        {
            try
            {

                string query = "SELECT UserID, Type, Manager, FullName FROM UserData WHERE UserName = @UserName";



                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["UserID"]);
                                string userType = reader["Type"].ToString();
                                string manager = reader["Manager"].ToString();
                                string fullname = reader["FullName"].ToString();


                                string message = $"User ID: {userId}\nType: {userType}\nManager: {manager}\nFullName: {fullname}";
                                MessageBox.Show(message, "User Information");
                            }
                            else
                            {
                                MessageBox.Show("User not found!", "Error");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
            }
        }

    }
}
